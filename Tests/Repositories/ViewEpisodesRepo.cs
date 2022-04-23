using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.Repositories;

public class ViewEpisodesRepo
{
    private ViewEpisodesRepository _viewEpisodesRepository;
    [Fact]
    public async Task ShouldExecuteView()
    {
        using (var context = new DoctorWhoDbContext())
        {
            context.Database.EnsureCreated();
            _viewEpisodesRepository = new ViewEpisodesRepository(context);
            var episode = await _viewEpisodesRepository.ExecuteView();
            Assert.Equal(5,episode.Count());
        }
    }
}