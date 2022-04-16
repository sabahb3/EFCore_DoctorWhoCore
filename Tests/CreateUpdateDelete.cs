using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests;

public class CreateUpdateDelete
{
    private DbContextOptionsBuilder<DoctorWhoDbContext> _optionsBuilder
        = new DbContextOptionsBuilder<DoctorWhoDbContext>();

    [Fact]
    public void ShouldAddNewAuthor()
    {
        _optionsBuilder.UseInMemoryDatabase("NewAuthor");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var author = new Author
            {
                AuthorName = "newAuthor"
            };
            context.tblAuthors.Add(author);
            context.SaveChanges();
            Assert.Equal(6,author.AuthorId);
        }
    }
    
    [Fact]
    public void ShouldUpdateAuthor()
    {
        _optionsBuilder.UseInMemoryDatabase("updatedContext");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var newAuthor = new Author
            {
                AuthorName = "newAuthor"
            };
            context.tblAuthors.Add(newAuthor);
            context.SaveChanges();
            var author = context.tblAuthors.Find(6);
            if (author != null)
            {
                using (var updatedContext = new DoctorWhoDbContext(_optionsBuilder.Options) )
                {
                    author.AuthorName = "UpdatedName";
                    updatedContext.Entry(author).State = EntityState.Modified;
                    updatedContext.SaveChanges();
                }
            }
            Assert.NotEqual("newAuthor",newAuthor.AuthorName);
        }
    }
    
    [Fact]
    public void ShouldDeleteAuthor()
    {
        _optionsBuilder.UseInMemoryDatabase("DeleteAuthor");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var author = new Author
            {
                AuthorName = "newAuthor"
            };
            context.tblAuthors.Add(author);
            context.SaveChanges();
            Assert.Equal(6,author.AuthorId);
            using (var deletedAuthor = new DoctorWhoDbContext(_optionsBuilder.Options))
            {
                deletedAuthor.Remove(author);
                deletedAuthor.SaveChanges();
            }

            using (var checkContext = new DoctorWhoDbContext(_optionsBuilder.Options))
            {
                var found = checkContext.tblAuthors.Find(6);
                Assert.Null(found);
            }
        }
    }

    
}