using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DoctorWho.Db;

public class DoctorWhoDbContext : DbContext
{
    public DbSet<Episode> tblEpisodes;
    public DbSet<Author> tblAuthors;
    public DbSet<Doctor> tblDoctors;
    public DbSet<Enemy> tblEnemies;
    public DbSet<Companion> tblCompanions;

    public static readonly ILoggerFactory ConsoleLoggerFactory
        = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddConsole();
        });
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory).EnableSensitiveDataLogging()
            .UseSqlServer(
                "Server=localhost;" +
                "Database=DoctorWhoCore;" +
                "Persist Security Info=False;User ID=sa;Password=S.11714778" )
            .UseEnumCheckConstraints();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().ToTable("tblAuthor");
        modelBuilder.Entity<Doctor>().ToTable("tblDoctor");
        modelBuilder.Entity<Enemy>().ToTable("tblEnemy");
        modelBuilder.Entity<Companion>().ToTable("tblCompanion");
        modelBuilder.Entity<Episode>().ToTable("tblEpisode");
        modelBuilder.Entity<EpisodeCompanion>().ToTable("tblEpisodeCompanion");
        modelBuilder.Entity<EpisodeEnemy>().ToTable("tblEpisodeEnemy");
        
        modelBuilder.Entity<EpisodeCompanion>().HasKey(e => new {e.EpisodeId, e.CompanionId});
        modelBuilder.Entity<EpisodeEnemy>().HasKey(e => new {e.EpisodeId, e.EnemyId});
        modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).HasConversion<string>();
    }
}