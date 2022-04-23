using System.Linq;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
namespace Tests.Repositories;

public class authorRepo
{
    private DbContextOptionsBuilder<DoctorWhoDbContext> _optionsBuilder
        = new DbContextOptionsBuilder<DoctorWhoDbContext>();

    private AuthorRepository _authorRepository;

    [Fact]
    public async void ShouldAddNewAuthor()
    {
        _optionsBuilder.UseInMemoryDatabase("NewAuthor");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var count = await context.tblAuthors.CountAsync();
            Assert.Equal(5,count);
            _authorRepository = new AuthorRepository(context);
            await _authorRepository.CreateAuthor("new Author");
            count=await context.tblAuthors.CountAsync();
            Assert.Equal(6,count);
        }
    }
    [Fact]
    public async void ShouldUpdateAuthor()
    {
        _optionsBuilder.UseInMemoryDatabase("UpdateAuthor");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var author = await context.tblAuthors.FindAsync(1);
            if (author!=null)
            {
                var currentName = author.AuthorName;
                _authorRepository = new AuthorRepository(context);
                await _authorRepository.UpdateAuthor(1,"Updated name");
                Assert.NotEqual(currentName,author.AuthorName);
            }

        }
    }
    [Fact]
    public async void ShouldDeleteAuthor()
    {
        _optionsBuilder.UseInMemoryDatabase("DeleteAuthor");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var author = await context.tblAuthors.FindAsync(1);
            if (author!=null)
            {
                _authorRepository = new AuthorRepository(context);
                await _authorRepository.DeleteAuthor(1);
            }

            using (var checkDeleted = new DoctorWhoDbContext(_optionsBuilder.Options))
            {
                var deletedAuthor = await checkDeleted.tblAuthors.FindAsync(1);
                Assert.Null(deletedAuthor);
            }

        }
    }
}