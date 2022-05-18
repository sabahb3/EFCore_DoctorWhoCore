using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class CompanionRepository
{
    private DoctorWhoDbContext _context;

    public CompanionRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public async Task CreateCompanion(string companionName, string whoPlayed)
    {
        var companion = new Companion
        {
            CompanionName = companionName,
            WhoPlayed = whoPlayed
        };
        _context.tblCompanions.Add(companion);
       await _context.SaveChangesAsync();
    }

    public async Task UpdateCompanionName(int companionId, string companionName)
    {
        var companion = await _context.tblCompanions.FindAsync(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                companion.CompanionName = companionName;
                updateContext.Entry(companion).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateCompanionWhoPlayed(int companionId, string whoPlayed)
    {
        var companion =await _context.tblCompanions.FindAsync(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                companion.WhoPlayed = whoPlayed;
                updateContext.Entry(companion).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateCompanion(int companionId, string companionName, string whoPlayed)
    {
        var companion =await _context.tblCompanions.FindAsync(companionId);
        if (companion != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                companion.CompanionName = companionName;
                companion.WhoPlayed = whoPlayed;
                updateContext.Entry(companion).State = EntityState.Modified;
               await updateContext.SaveChangesAsync();
            }
    }

    public async Task DeleteCompanion(int companionId)
    {
        var companion = await _context.tblCompanions.FindAsync(companionId);
        if (companion != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblCompanions.Remove(companion);
               await deleteContext.SaveChangesAsync();
            }
    }

    public async Task<Companion?> GetCompanionById(int companionId)
    {
        return await _context.tblCompanions.FindAsync(companionId);
    }
}