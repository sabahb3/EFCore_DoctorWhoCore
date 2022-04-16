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
        UpdateCompanionWhoPlayed(6, "whoPlayedTest");
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

}