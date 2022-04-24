using System;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace Tests.Repositories;

public class DoctorRepo
{
    private DbContextOptionsBuilder<DoctorWhoDbContext> _optionsBuilder
        = new DbContextOptionsBuilder<DoctorWhoDbContext>();

    private DoctorRepository _doctorRepository;

    [Fact]
    public async Task ShouldCreateNewDoctor()
    {
        _optionsBuilder.UseInMemoryDatabase("NewDoctor");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var count = await context.tblDoctors.CountAsync();
            Assert.Equal(5,count);
            _doctorRepository = new DoctorRepository(context);
            var doctor = new Doctor
            {
                DoctorName = "new Doctor",
                DoctorNumber = "Sixth doctor",
                BirthDate = new DateTime(2010,4,3)
            };
            await _doctorRepository.CreateDoctor(doctor);
            count=await context.tblDoctors.CountAsync();
            Assert.Equal(6,count);
        }
    }

    [Fact]
    public async Task ShouldUpdateDoctorNumber()
    {
        _optionsBuilder.UseInMemoryDatabase("UpdateDoctor");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var doctor = await context.tblDoctors.FindAsync(1);
            if (doctor!=null)
            {
                var currentName = doctor.DoctorName;
                _doctorRepository = new DoctorRepository(context);
                await _doctorRepository.UpdateDoctorNumber(1,"Updated number");
                Assert.NotEqual(currentName,doctor.DoctorNumber);
            }

        }
    }

    [Fact]
    public async Task ShouldReturnAllDoctors()
    {
        _optionsBuilder.UseInMemoryDatabase("ReturnDoctors");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            _doctorRepository = new DoctorRepository(context);
            var doctors = await _doctorRepository.GetAllDoctor();
            Assert.Equal(5,doctors.Count());

        }
    }
}