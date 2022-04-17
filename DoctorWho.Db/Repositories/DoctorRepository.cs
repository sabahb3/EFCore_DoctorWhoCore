using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class DoctorRepository
{
    private DoctorWhoDbContext _context;

    public DoctorRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public void CreateDoctor(Doctor doctor)
    {
        _context.tblDoctors.Add(doctor);
        _context.SaveChanges();
    }

    public void UpdateDoctorNumber(int doctorId, string doctorNumber)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctorName(int doctorId, string doctorName)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorName = doctorName;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctorBirthDate(int doctorId, DateTime birthDate)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.BirthDate = birthDate;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctorFirstEpisode(int doctorId, DateTime firstEpisode)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.FirstEpisodeDate = firstEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctorLastEpisode(int doctorId, DateTime lastEpisode)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.LastEpisodeDate = lastEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctor(int doctorId, string doctorNumber, string doctorName)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                doctor.BirthDate = birthDate;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate,
        DateTime firstEpisode)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                doctor.BirthDate = birthDate;
                doctor.FirstEpisodeDate = firstEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate,
        DateTime firstEpisode, DateTime lastEpisode)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
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

    public  void DeleteDoctor(int doctorId)
    {
        var doctor = _context.tblDoctors.Find(doctorId);
        if (doctor != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblDoctors.Remove(doctor);
                deleteContext.SaveChanges();
            }
    }
}