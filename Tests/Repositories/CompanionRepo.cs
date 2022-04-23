using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace Tests.Repositories;

public class CompanionRepo
{
    private DbContextOptionsBuilder<DoctorWhoDbContext> _optionsBuilder
        = new DbContextOptionsBuilder<DoctorWhoDbContext>();

    private CompanionRepository _companionRepository;

    [Fact]
    public async Task ShouldAddNewCompanion()
    {
        _optionsBuilder.UseInMemoryDatabase("NewCompanion");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var count = await context.tblCompanions.CountAsync();
            Assert.Equal(5,count);
            _companionRepository = new CompanionRepository(context);
            await _companionRepository.CreateCompanion("new Companion","new who played");
            count=await context.tblCompanions.CountAsync();
            Assert.Equal(6,count);
        }
    }
    [Fact]
    public async Task ShouldUpdateCompanionName()
    {
        _optionsBuilder.UseInMemoryDatabase("UpdateCompanion");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var companion = await context.tblCompanions.FindAsync(1);
            if (companion != null)
            {
                var currentName = companion.CompanionName;
                _companionRepository = new CompanionRepository(context);
                await _companionRepository.UpdateCompanionName(1, "updated companion name");
                Assert.NotEqual(currentName,companion.CompanionName);
            }
        }
    }
    [Fact]
    public async Task ShouldUpdateCompanionWhoPlayed()
    {
        _optionsBuilder.UseInMemoryDatabase("UpdateCompanion");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var companion = await context.tblCompanions.FindAsync(1);
            if (companion != null)
            {
                var whoPlayed = companion.WhoPlayed;
                _companionRepository = new CompanionRepository(context);
                await _companionRepository.UpdateCompanionWhoPlayed(1, "updated who played");
                Assert.NotEqual(whoPlayed,companion.WhoPlayed);
            }
        }
    }
    [Fact]
    public async Task ShouldUpdateCompanion()
    {
        _optionsBuilder.UseInMemoryDatabase("UpdateCompanion");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var companion = await context.tblCompanions.FindAsync(1);
            if (companion != null)
            {
                var name = companion.CompanionName;
                var whoPlayed = companion.WhoPlayed;
                _companionRepository = new CompanionRepository(context);
                await _companionRepository.UpdateCompanion(1,"Updated name", "updated who played");
                Assert.NotEqual(name,companion.CompanionName);
                Assert.NotEqual(whoPlayed,companion.WhoPlayed);
            }
        }
    }
    [Fact]
    public async Task ShouldDeleteAuthor()
    {
        _optionsBuilder.UseInMemoryDatabase("DeleteCompanion");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var companion = await context.tblCompanions.FindAsync(1);
            if (companion!=null)
            {
                _companionRepository = new CompanionRepository(context);
                await _companionRepository.DeleteCompanion(1);
            }

            using (var checkDeleted = new DoctorWhoDbContext(_optionsBuilder.Options))
            {
                var deletedCompanion = await checkDeleted.tblCompanions.FindAsync(1);
                Assert.Null(deletedCompanion);
            }

        }
    }
    [Fact]
    public async Task ShouldReturnCompanion()
    {
        _optionsBuilder.UseInMemoryDatabase("GetCompanion");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            _companionRepository = new CompanionRepository(context);
            var companion = await _companionRepository.GetCompanionById(1);
            Assert.NotNull(companion);
            Assert.Equal(1,companion!.CompanionId);
            Assert.Equal("Ameera Ameer", companion.CompanionName);
            Assert.Equal("Ameera Surakji", companion.WhoPlayed);
        }

    }
}