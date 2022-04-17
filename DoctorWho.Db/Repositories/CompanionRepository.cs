using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class CompanionRepository
{
    private DoctorWhoDbContext _context;

    public CompanionRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public void CreateCompanion(string companionName, string whoPlayed)
    {
        var companion = new Companion
        {
            CompanionName = companionName,
            WhoPlayed = whoPlayed
        };
        _context.tblCompanions.Add(companion);
        _context.SaveChanges();
    }

    public void UpdateCompanionName(int companionId, string companionName)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                companion.CompanionName = companionName;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateCompanionWhoPlayed(int companionId, string whoPlayed)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                companion.WhoPlayed = whoPlayed;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateCompanion(int companionId, string companionName, string whoPlayed)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                companion.CompanionName = companionName;
                companion.WhoPlayed = whoPlayed;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void DeleteCompanion(int companionId)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblCompanions.Remove(companion);
                deleteContext.SaveChanges();
            }
    }

    public Companion? GetCompanionById(int companionId)
    {
        return _context.tblCompanions.Find(companionId);
    }
}