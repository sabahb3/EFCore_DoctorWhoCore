using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho;

public class EnemyCUD
{
    private static DoctorWhoDbContext _context = new();

    public static void CreateEnemy(string enemyName, string description)
    {
        var enemy = new Enemy
        {
            EnemyName = enemyName,
            Description = description
        };
        _context.tblEnemies.Add(enemy);
        _context.SaveChanges();
    }

    public static void UpdateEnemyName(int enemyId, string enemyName)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                enemy.EnemyName = enemyName;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateEnemyDescription(int enemyId, string description)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                enemy.Description = description;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void UpdateEnemy(int enemyId, string enemyName, string description)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
            using (var updateContext = new DoctorWhoDbContext())
            {
                enemy.EnemyName = enemyName;
                enemy.Description = description;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void DeleteEnemy(int enemyId)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
            using (var deleteContext = new DoctorWhoDbContext())
            {
                deleteContext.tblEnemies.Remove(enemy);
                deleteContext.SaveChanges();
            }
    }
}