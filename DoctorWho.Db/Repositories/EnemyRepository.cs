using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EnemyRepository
{
    private DoctorWhoDbContext _context;

    public EnemyRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public async Task CreateEnemy(string enemyName, string description)
    {
        var enemy = new Enemy
        {
            EnemyName = enemyName,
            Description = description
        };
        _context.tblEnemies.Add(enemy);
       await _context.SaveChangesAsync();
    }

    public async Task UpdateEnemyName(int enemyId, string enemyName)
    {
        var enemy = await _context.tblEnemies.FindAsync(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                enemy.EnemyName = enemyName;
                updateContext.Entry(enemy).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEnemyDescription(int enemyId, string description)
    {
        var enemy = await _context.tblEnemies.FindAsync(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                enemy.Description = description;
                updateContext.Entry(enemy).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task UpdateEnemy(int enemyId, string enemyName, string description)
    {
        var enemy = await _context.tblEnemies.FindAsync(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                enemy.EnemyName = enemyName;
                enemy.Description = description;
                updateContext.Entry(enemy).State = EntityState.Modified;
               await updateContext.SaveChangesAsync();
            }
    }

    public async Task DeleteEnemy(int enemyId)
    {
        var enemy = await _context.tblEnemies.FindAsync(enemyId);
        if (enemy != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblEnemies.Remove(enemy);
                await deleteContext.SaveChangesAsync();
            }
    }

    public async Task<Enemy?> GetEnemyById(int enemyId)
    {
        return await _context.tblEnemies.FindAsync(enemyId);
    }
}