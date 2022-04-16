using System.Collections.Generic;
using System.Linq;
using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests;

public class UserDefinedTypes
{
    private DbContextOptionsBuilder<DoctorWhoDbContext> _optionsBuilder
        = new DbContextOptionsBuilder<DoctorWhoDbContext>();

    [Theory]
    [InlineData(1, "Ameera Ameer, Aya Khalid")]
    [InlineData(2,"Samar Samer")]
    [InlineData(3,"Ameera Ameer")]
    [InlineData(4,"Samar Samer")]
    [InlineData(5,null)]
    public void ShouldReturnAllCompanionsOfEpisode(int episodeId, string? companions)
    {
        _optionsBuilder.UseInMemoryDatabase("UsingCompanionsFunction");
        using (var context = new DoctorWhoDbContext())
        {
            context.Database.EnsureCreated();
            var actualCompanions = DoctorWhoDbContext.fnCompanions(episodeId);
            Assert.Equal(companions,actualCompanions);
        }
    }
    
    [Theory]
    [InlineData(1, "Poliomyelitis")]
    [InlineData(2,"Tuberculosis, Poliomyelitis")]
    [InlineData(3,"Tuberculosis")]
    [InlineData(4,"Smallpox")]
    [InlineData(5,null)]
    public void ShouldReturnAllEnemiesOfEpisode(int episodeId, string? companions)
    {
        _optionsBuilder.UseInMemoryDatabase("UsingEnemiesFunction");
        using (var context = new DoctorWhoDbContext())
        {
            context.Database.EnsureCreated();
            var actualCompanions = DoctorWhoDbContext.fnEnemies(episodeId);
            Assert.Equal(companions,actualCompanions);
        }
    }

    [Fact]
    public void ShouldReturnViewResult()
    {
        _optionsBuilder.UseInMemoryDatabase("UsingView");
        using (var context = new DoctorWhoDbContext())
        {
            context.Database.EnsureCreated();
            var episodes = context.ViewEpisodes.ToList();
            Assert.Equal(5,episodes.Count());
            foreach (var episode in episodes)
            {
                Assert.Equal(DoctorWhoDbContext.fnCompanions(episode.EpisodeId),episode.Companions);
                Assert.Equal(DoctorWhoDbContext.fnEnemies(episode.EpisodeId),episode.Enemies);

            }
        }

    }
}