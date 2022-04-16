using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho;

public class CompanionCUD
{
    private static DoctorWhoDbContext _context = new();

    public static void CreateCompanion(string companionName, string whoPlayed)
    {
        var companion = new Companion
        {
            CompanionName = companionName,
            WhoPlayed = whoPlayed
        };
        _context.tblCompanions.Add(companion);
        _context.SaveChanges();
    }

    public static void UpdateCompanionName(int companionId, string companionName)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                companion.CompanionName = companionName;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateCompanionWhoPlayed(int companionId, string whoPlayed)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                companion.WhoPlayed = whoPlayed;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateCompanion(int companionId, string companionName, string whoPlayed)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                companion.CompanionName = companionName;
                companion.WhoPlayed = whoPlayed;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void DeleteCompanion(int companionId)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
            using (var deleteContext = new DoctorWhoDbContext())
            {
                deleteContext.tblCompanions.Remove(companion);
                deleteContext.SaveChanges();
            }
    }
}