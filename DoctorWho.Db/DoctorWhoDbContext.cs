using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db;

public class DoctorWhoDbContext : DbContext
{
    public DbSet<Episode> tblEpisodes;
    public DbSet<Author> tblAuthors;
    public DbSet<Doctor> tblDoctors;
    public DbSet<Enemy> tblEnemies;
    public DbSet<Companion> tblCompanions;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().ToTable("tblAuthor");
        modelBuilder.Entity<Doctor>().ToTable("tblDoctor");
        modelBuilder.Entity<Enemy>().ToTable("tblEnemy");
        modelBuilder.Entity<Companion>().ToTable("tblCompanion");
        modelBuilder.Entity<Episode>().ToTable("tblEpisode");
        modelBuilder.Entity<EpisodeCompanion>().ToTable("tblEpisodeCompanion");
        modelBuilder.Entity<EpisodeEnemy>().ToTable("tblEpisodeEnemy");
    }
}