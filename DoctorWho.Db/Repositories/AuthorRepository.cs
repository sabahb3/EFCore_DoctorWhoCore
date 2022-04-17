using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class AuthorRepository
{
    private DoctorWhoDbContext _context;

    public AuthorRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }
    
    public void CreateAuthor(string authorName)
    {
        var author = new Author
        {
            AuthorName = authorName
        };
        _context.tblAuthors.Add(author);
        _context.SaveChanges();
    }

    public void UpdateAuthor(int authorId, string authorName)
    {
        var author = _context.tblAuthors.Find(authorId);
        if (author != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                author.AuthorName = authorName;
                updateContext.Entry(author).State = EntityState.Modified;
                updateContext.SaveChanges();
            }
    }

    public void DeleteAuthor(int authorId)
    {
        var author = _context.tblAuthors.Find(authorId);
        if (author != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblAuthors.Remove(author);
                deleteContext.SaveChanges();
            }
    }
}