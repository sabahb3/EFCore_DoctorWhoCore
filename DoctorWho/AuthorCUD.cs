using DoctorWho.Db;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho;

public class AuthorCUD
{
    private static DoctorWhoDbContext _context = new();

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
            using (var updateContext = new DoctorWhoDbContext())
            {
                author.AuthorName = authorName;
                updateContext.Entry(author).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public static void DeleteAuthor(int authorId)
    {
        var author = _context.tblAuthors.Find(authorId);
        if (author != null)
            using (var deleteContext = new DoctorWhoDbContext())
            {
                deleteContext.tblAuthors.Remove(author);
                deleteContext.SaveChanges();
            }
    }
}