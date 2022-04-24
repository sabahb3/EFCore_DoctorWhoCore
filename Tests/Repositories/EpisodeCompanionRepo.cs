using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.Repositories;

public class EpisodeCompanionRepo
{
    private DbContextOptionsBuilder<DoctorWhoDbContext> _optionsBuilder
        = new DbContextOptionsBuilder<DoctorWhoDbContext>();

    private EpisodeCompanionRepository _episodeCompanionRepository;

    [Fact]
    public async Task ShouldAddCompanionToEpisode()
    {
        _optionsBuilder.UseInMemoryDatabase("newCompanion");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var episode =await context.tblEpisodes.FindAsync(1);
            context.Entry(episode!).Collection(e => e.EpisodesCompanions).Load();
            Assert.Equal(2,episode!.EpisodesCompanions.Count);
            _episodeCompanionRepository = new EpisodeCompanionRepository(context);
            await _episodeCompanionRepository.AddCompanionToEpisode(1, "Test", "Test");
            Assert.Equal(3,episode!.EpisodesCompanions.Count);
        }
    }

    [Fact]
    public async Task ShouldReturnCompanionEpisode()
    {
        _optionsBuilder.UseInMemoryDatabase("GetCompanion");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            _episodeCompanionRepository = new EpisodeCompanionRepository(context);
            var compaions = _episodeCompanionRepository.GetCompanionsEpisode(1);
            Assert.Equal("Ameera Ameer, Aya Khalid",compaions);
        }
    }
}