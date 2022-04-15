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
        
        modelBuilder.Entity<Enemy>().HasData(
            new Enemy
            {
                EnemyId = 1,
                EnemyName = "Tuberculosis",
                Description = "Tuberculosis (TB) is caused by bacteria (Mycobacterium tuberculosis) that most often affect" +
                              " the lungs. Tuberculosis is curable and preventable."
            },
            new Enemy
            {
                EnemyId = 2,
                EnemyName = "Plague",
                Description = "Plague is an infectious disease caused by the bacteria Yersinia pestis, a zoonotic bacteria, usually " +
                              "found in small mammals and their fleas. It is transmitted between animals through fleas."
            },
            new Enemy
            {
                EnemyId = 3,
                EnemyName = "Smallpox",
                Description = "Smallpox is an ancient disease caused by the variola virus. Early symptoms include high fever and fatigue." +
                              " The virus then produces a characteristic rash, particularly on the face, arms and legs. The resulting spots " +
                              "become filled with clear fluid and later, pus, and then form a crust, which eventually dries up and falls off." +
                              " Smallpox was fatal in up to 30% of cases"
            },
            new Enemy
            {
                EnemyId = 4,
                EnemyName = "Poliomyelitis",
                Description = "A viral infection causing nerve injury which leads to partial or full paralysis. Many of the infected people" +
                              " do not show any symptoms."
            },
            new Enemy
            {
                EnemyId = 5,
                EnemyName = "Cholera",
                Description = "A bacterial infection which spreads through contaminated food and water."
            }
        );
    }
}