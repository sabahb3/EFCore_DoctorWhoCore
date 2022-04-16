using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho;

public class DoctorCUD
{
    private static DoctorWhoDbContext _context = new();

    public static void CreateDoctor(string doctorNumber, string doctorName, DateTime birthDate)
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

    public static void CreateDoctor(string doctorNumber, string doctorName, DateTime birthDate, DateTime firstEpisode)
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

    public static void CreateDoctor(string doctorNumber, string doctorName, DateTime birthDate, DateTime firstEpisode,
        DateTime lastEpisode)
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

    public static void UpdateDoctorNumber(int doctorId, string doctorNumber)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.DoctorNumber = doctorNumber;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateDoctorName(int doctorId, string doctorName)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.DoctorName = doctorName;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateDoctorBirthDate(int doctorId, DateTime birthDate)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.BirthDate = birthDate;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateDoctorFirstEpisode(int doctorId, DateTime firstEpisode)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.FirstEpisodeDate = firstEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateDoctorLastEpisode(int doctorId, DateTime lastEpisode)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.LastEpisodeDate = lastEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateDoctor(int doctorId, string doctorNumber, string doctorName)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                doctor.BirthDate = birthDate;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate,
        DateTime firstEpisode)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                doctor.BirthDate = birthDate;
                doctor.FirstEpisodeDate = firstEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate,
        DateTime firstEpisode, DateTime lastEpisode)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                doctor.BirthDate = birthDate;
                doctor.FirstEpisodeDate = firstEpisode;
                doctor.LastEpisodeDate = lastEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void DeleteDoctor(int doctorId)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var deleteContext = new DoctorWhoDbContext())
            {
                deleteContext.tblDoctors.Remove(doctor);
                deleteContext.SaveChanges();
            }
    }
}