using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class DoctorRepository
{
    private DoctorWhoDbContext _context;

    public DoctorRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public async Task CreateDoctor(Doctor doctor)
    {
        _context.tblDoctors.Add(doctor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDoctorNumber(int doctorId, string doctorNumber)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctorName(int doctorId, string doctorName)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorName = doctorName;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctorBirthDate(int doctorId, DateTime birthDate)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.BirthDate = birthDate;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctorFirstEpisode(int doctorId, DateTime firstEpisode)
    {
        var doctor =await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.FirstEpisodeDate = firstEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctorLastEpisode(int doctorId, DateTime lastEpisode)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.LastEpisodeDate = lastEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctor(int doctorId, string doctorNumber, string doctorName)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                doctor.BirthDate = birthDate;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate,
        DateTime firstEpisode)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                doctor.BirthDate = birthDate;
                doctor.FirstEpisodeDate = firstEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateDoctor(int doctorId, string doctorNumber, string doctorName, DateTime birthDate,
        DateTime firstEpisode, DateTime lastEpisode)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                doctor.DoctorNumber = doctorNumber;
                doctor.DoctorName = doctorName;
                doctor.BirthDate = birthDate;
                doctor.FirstEpisodeDate = firstEpisode;
                doctor.LastEpisodeDate = lastEpisode;
                updateContext.Entry(doctor).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task DeleteDoctor(int doctorId)
    {
        var doctor = await _context.tblDoctors.FindAsync(doctorId);
        if (doctor != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblDoctors.Remove(doctor);
               await deleteContext.SaveChangesAsync();
            }
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctor()
    {
        var doctors = await _context.tblDoctors.ToListAsync();
        return doctors;
    }
}