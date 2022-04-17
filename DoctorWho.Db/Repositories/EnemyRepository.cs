using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EnemyRepository
{
    private DoctorWhoDbContext _context;

    public EnemyRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }

    public void CreateEnemy(string enemyName, string description)
    {
        var enemy = new Enemy
        {
            EnemyName = enemyName,
            Description = description
        };
        _context.tblEnemies.Add(enemy);
        _context.SaveChanges();
    }

    public void UpdateEnemyName(int enemyId, string enemyName)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                enemy.EnemyName = enemyName;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEnemyDescription(int enemyId, string description)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                enemy.Description = description;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void UpdateEnemy(int enemyId, string enemyName, string description)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                enemy.EnemyName = enemyName;
                enemy.Description = description;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void DeleteEnemy(int enemyId)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblEnemies.Remove(enemy);
                deleteContext.SaveChanges();
            }
    }

    public Enemy? GetEnemyById(int enemyId)
    {
        return _context.tblEnemies.Find(enemyId);
    }
}