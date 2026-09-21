using Microsoft.EntityFrameworkCore;
using Naruto_Universe.Model.DbEntity;

namespace Naruto_Universe.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
        public DbSet<NCharacter> NCharacters { get; set; }
        public DbSet<NKekkeiGenkai> NKekkeiGenkais { get; set; }
        public DbSet<NChakraNature> NChakraNatures  { get; set; }
        public DbSet<NClan> NClans { get; set; }
        public DbSet<NVillage> NVillages { get; set; }
        public DbSet<NMedia> NMediae { get; set; }
        public DbSet<NCountry> NCountries { get; set; }
        public DbSet<NArc> NArcs { get; set; }
        public DbSet<NJutsu> NJutsus { get; set; }
        public DbSet<NJutsuClassification> NJutsuClassifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NCharacter>()
                .HasMany(c => c.Jutsus)
                .WithMany(j => j.Characters);

            modelBuilder.Entity<NJutsu>()
                .HasOne<NCharacter>()
                .WithMany()
                .HasForeignKey(j => j.CreatorId)
                .IsRequired(false);

            modelBuilder.Entity<NMedia>()
                .HasOne(m => m.Arc)
                .WithMany(a => a.MediaList)
                .HasForeignKey(m => m.NArcId)
                .IsRequired();

            modelBuilder.Entity<NJutsu>()
                .HasMany(j => j.JutsuClassifications)
                .WithMany(c => c.Jutsus);
            
            base.OnModelCreating(modelBuilder);
        }
}