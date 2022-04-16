using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho;

public class DoctorCUD
{
    private static DoctorWhoDbContext _context = new();
    
    public static void CreateDoctor(string doctorNumber, string doctorName,DateTime birthDate)
    {
        var doctor = new Doctor
        {
            DoctorNumber = doctorNumber,
            DoctorName = doctorName,
            BirthDate = birthDate
        };
        _context.tblDoctors.Add(doctor);
        _context.SaveChanges();
    }
    public static void CreateDoctor(string doctorNumber, string doctorName,DateTime birthDate,DateTime firstEpisode)
    {
        var doctor = new Doctor
        {
            DoctorNumber = doctorNumber,
            DoctorName = doctorName,
            BirthDate = birthDate,
            FirstEpisodeDate = firstEpisode
        };
        _context.tblDoctors.Add(doctor);
        _context.SaveChanges();
    }
    public static void CreateDoctor(string doctorNumber, string doctorName,DateTime birthDate,DateTime firstEpisode,DateTime lastEpisode)
    {
        var doctor = new Doctor
        {
            DoctorNumber = doctorNumber,
            DoctorName = doctorName,
            BirthDate = birthDate,
            FirstEpisodeDate = firstEpisode,
            LastEpisodeDate = lastEpisode
        };
        _context.tblDoctors.Add(doctor);
        _context.SaveChanges();
    }

}