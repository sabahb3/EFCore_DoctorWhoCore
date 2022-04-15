using System.Linq;
using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests;

public class SeedingData
{
    private DbContextOptionsBuilder<DoctorWhoDbContext> _optionsBuilder
        = new DbContextOptionsBuilder<DoctorWhoDbContext>();
    [Fact]
    public void ShouldEnemiesTableHasFiveRecodes()
    {
        _optionsBuilder.UseInMemoryDatabase("HasSeedingData");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureCreated();
            Assert.Equal(5,context.tblEnemies.Count());
        }
    }
    
    [Fact]
    public void ShouldCompanionsTableHasFiveRecodes()
    {
        _optionsBuilder.UseInMemoryDatabase("HasSeedingData");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureCreated();
            Assert.Equal(5,context.tblCompanions.Count());
        }
    }
    
    [Fact]
    public void ShouldEpisodesTableHasFiveRecodes()
    {
        _optionsBuilder.UseInMemoryDatabase("HasSeedingData");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureCreated();
            Assert.Equal(5,context.tblEpisodes.Count());
        }
    }
    
    [Fact]
    public void ShouldAuthorsTableHasFiveRecodes()
    {
        _optionsBuilder.UseInMemoryDatabase("HasSeedingData");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureCreated();
            Assert.Equal(5,context.tblAuthors.Count());
        }
    }
    
    [Fact]
    public void ShouldDoctorTableHasFiveRecodes()
    {
        _optionsBuilder.UseInMemoryDatabase("HasSeedingData");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureCreated();
            Assert.Equal(5,context.tblDoctors.Count());
        }
    }
    [Fact]
    public void ShouldJoinEntitesableHasFiveRecodes()
    {
        _optionsBuilder.UseInMemoryDatabase("HasSeedingData");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureCreated();
            
            Assert.Equal(5,context.Set<EpisodeCompanion>().Count());
            Assert.Equal(5,context.Set<EpisodeEnemy>().Count());

        }
    }
    
}