// See https://aka.ms/new-console-template for more information

using DoctorWho.Db.Repositories;
using DoctorWho.Db;

namespace DoctorWho;
internal class Program
{
    private static DoctorWhoDbContext _context = new();

    public static async Task Main()
    {
        var result = await Procedures.ExecuteProcedure();
    }


}