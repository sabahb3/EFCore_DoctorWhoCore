using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class AuthorRepository
{
    private DoctorWhoDbContext _context;

    public AuthorRepository(DoctorWhoDbContext context)
    {
        _context = context;
    }
    
    public async Task CreateAuthor(string authorName)
    {
        var author = new Author
        {
            AuthorName = authorName
        };
        _context.tblAuthors.Add(author);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAuthor(int authorId, string authorName)
    {
        var author = await _context.tblAuthors.FindAsync(authorId);
        if (author != null)
            using (var updateContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                author.AuthorName = authorName;
                updateContext.Entry(author).State = EntityState.Modified;
                await updateContext.SaveChangesAsync();
            }
    }

    public async Task DeleteAuthor(int authorId)
    {
        var author = await _context.tblAuthors.FindAsync(authorId);
        if (author != null)
            using (var deleteContext = new DoctorWhoDbContext(_context.DoctorWhoOptions.Options))
            {
                deleteContext.tblAuthors.Remove(author);
                await deleteContext.SaveChangesAsync();
            }
    }
}