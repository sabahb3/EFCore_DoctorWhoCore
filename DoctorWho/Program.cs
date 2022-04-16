// See https://aka.ms/new-console-template for more information

using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

class Program
{
    private static DoctorWhoDbContext _context = new DoctorWhoDbContext();
    public static void Main()
    {
        ExecuteView();
        Console.WriteLine();
        var companions = GetCompanionsEpisode(1);
        Console.WriteLine(companions);
        Console.WriteLine();
        var enemies = GetEnemiesEpisode(1);
        Console.WriteLine(enemies);
        // CreateAuthor("New Author");
        // UpdateAuthor(7, "UpdatedName");
        // DeleteAuthor(7);

        // CreateCompanion("CompanionTest", "playedTest");
        // UpdateCompanionName(6, "Test1");
        // UpdateCompanionWhoPlayed(6, "whoPlayedTest");
        // UpdateCompanion(6, "testTest", "whoPlayedTest");
        // DeleteCompanion(6);
        
        // CreateEnemy("TestName","TestDescription");
        // UpdateEnemyName(6,"TestName1");
        // UpdateEnemyDescription(6,"TestDescription1");
        // UpdateEnemy(6,"TestName2","TestDescription2");
        DeleteEnemy(6);
    }

    public static void ExecuteView()
    {
        var episodesView = _context.ViewEpisodes.ToList();
    }

    public static string GetCompanionsEpisode(int episodeId)
    {
        var result = DoctorWhoDbContext.fnCompanions(episodeId);
        return result;
    }
    
    public static string GetEnemiesEpisode(int episodeId)
    {
        var result = DoctorWhoDbContext.fnEnemies(episodeId);
        return result;
    }

    public static void CreateAuthor(string authorName)
    {
        var author = new Author
        {
            AuthorName = authorName
        };
        _context.tblAuthors.Add(author);
        _context.SaveChanges();
    }

    public static void UpdateAuthor(int authorId, string authorName)
    {
        var author = _context.tblAuthors.Find(authorId);
        if (author != null)
        {
            using (var updateContext = new DoctorWhoDbContext())
            {
                author.AuthorName = authorName;
                updateContext.Entry(author).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
        }
    }

    public static void DeleteAuthor(int authorId)
    {
        var author = _context.tblAuthors.Find(authorId);
        if (author!=null)
        {
            using (var deleteContext= new DoctorWhoDbContext())
            {
                deleteContext.tblAuthors.Remove(author);
                deleteContext.SaveChanges();
            }   
        }
    }
    
    public static void CreateCompanion(string companionName, string whoPlayed)
    {
        var companion = new Companion
        {
           CompanionName = companionName,
           WhoPlayed = whoPlayed,
        };
        _context.tblCompanions.Add(companion);
        _context.SaveChanges();
    }
    public static void UpdateCompanionName(int companionId, string companionName)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
        {
            using (var updateContext = new DoctorWhoDbContext())
            {
                companion.CompanionName = companionName;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
        }
    }
    public static void UpdateCompanionWhoPlayed(int companionId, string whoPlayed)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
        {
            using (var updateContext = new DoctorWhoDbContext())
            {
                companion.WhoPlayed = whoPlayed;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
        }
    }
    public static void UpdateCompanion(int companionId,string companionName, string whoPlayed)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion != null)
        {
            using (var updateContext = new DoctorWhoDbContext())
            {
                companion.CompanionName = companionName;
                companion.WhoPlayed = whoPlayed;
                updateContext.Entry(companion).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
        }
    }
    public static void DeleteCompanion(int companionId)
    {
        var companion = _context.tblCompanions.Find(companionId);
        if (companion!=null)
        {
            using (var deleteContext= new DoctorWhoDbContext())
            {
                deleteContext.tblCompanions.Remove(companion);
                deleteContext.SaveChanges();
            }   
        }
    }
    public static void CreateEnemy(string enemyName, string description)
    {
        var enemy = new Enemy
        {
           EnemyName = enemyName,
           Description = description,
        };
        _context.tblEnemies.Add(enemy);
        _context.SaveChanges();
    }
    public static void UpdateEnemyName(int enemyId, string enemyName)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
        {
            using (var updateContext = new DoctorWhoDbContext())
            {
                enemy.EnemyName = enemyName;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
        }
    }
    public static void UpdateEnemyDescription(int enemyId, string description)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
        {
            using (var updateContext = new DoctorWhoDbContext())
            {
                enemy.Description = description;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
        }
    }
    public static void UpdateEnemy(int enemyId,string enemyName, string description)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy != null)
        {
            using (var updateContext = new DoctorWhoDbContext())
            {
                enemy.EnemyName = enemyName;
                enemy.Description = description;
                updateContext.Entry(enemy).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
        }
    }
    public static void DeleteEnemy(int enemyId)
    {
        var enemy = _context.tblEnemies.Find(enemyId);
        if (enemy!=null)
        {
            using (var deleteContext= new DoctorWhoDbContext())
            {
                deleteContext.tblEnemies.Remove(enemy);
                deleteContext.SaveChanges();
            }   
        }
    }
}