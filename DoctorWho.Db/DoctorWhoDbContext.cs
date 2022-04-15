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
        
        modelBuilder.Entity<Companion>().HasData(
            new Companion
            {
                CompanionId = 1,
                CompanionName = "Ameera Ameer",
                WhoPlayed = "Ameera Surakji"
            },
            new Companion
            {
                CompanionId = 2,
                CompanionName = "khalid Ali",
                WhoPlayed = "khalid Toma"
            },
            new Companion
            {
                CompanionId = 3,
                CompanionName = "Aya Khalid",
                WhoPlayed = "Aya Jamal"
            },
            new Companion
            {
                CompanionId = 4,
                CompanionName = "Samar Samer",
                WhoPlayed = "Samar Rsas"
            },
            new Companion
            {
                CompanionId = 5,
                CompanionName = "Duaa Aqel",
                WhoPlayed = "Dalal Aqel"
            }
        );
        
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                DoctorId = 1,
                DoctorNumber = "First Doctor",
                DoctorName = "Anjad Shaar",
                BirthDate = new DateTime(1985,7,10),
                FirstEpisodeDate = new DateTime(2005,8,3),
                LastEpisodeDate = new DateTime(2008,12,26)
            },
            new Doctor
            {
                DoctorId = 2,
                DoctorNumber = "Second Doctor",
                DoctorName = "Ranen Halabi",
                BirthDate = new DateTime(1986,7,10),
                FirstEpisodeDate = new DateTime(2002,8,3),
                LastEpisodeDate = new DateTime(2009,12,26)
            },
            new Doctor
            {
                DoctorId = 3,
                DoctorNumber = "Third Doctor",
                DoctorName = "Shahd Shaar",
                BirthDate = new DateTime(1987,7,10),
                FirstEpisodeDate = new DateTime(2012,8,3),
                LastEpisodeDate = null
            },
            new Doctor
            {
                DoctorId = 4,
                DoctorNumber = "Fourth Doctor",
                DoctorName = "Lina Khanna",
                BirthDate = new DateTime(1988,10,15),
                FirstEpisodeDate = null,
                LastEpisodeDate = null
            },
            new Doctor
            {
                DoctorId = 5,
                DoctorNumber = "Fifth Doctor",
                DoctorName = "Majd Nabulsi",
                BirthDate = new DateTime(1989,12,25),
                FirstEpisodeDate = null,
                LastEpisodeDate = null
            }
        );
        
        modelBuilder.Entity<Author>().HasData(
            new Author
            {
                AuthorId = 1,
                AuthorName = "Aisha Marmash"
            },
            new Author
            {
                AuthorId = 2,
                AuthorName = "Sara Sawafta"
            },
            new Author
            {
                AuthorId = 3,
                AuthorName = "Asad Jamal"
            },
            new Author
            {
                AuthorId = 4,
                AuthorName = "Rawan Ahmad"
            },
            new Author
            {
                AuthorId = 5,
                AuthorName = "Qamar Ashour"
            }
        );
    }
}