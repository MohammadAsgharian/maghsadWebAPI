using Microsoft.EntityFrameworkCore;
using maghsadAPI.Models;


namespace maghsadAPI.Data
{
    public class MaghsadContext : DbContext
    {
        public MaghsadContext(DbContextOptions options): base(options: options)
        {

        }
        public DbSet<Models.Place> Places{get; set;}
        public DbSet<Models.PlaceType> PlaceTypes{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                    .HasOne(p => p.PlaceType)
                    .WithMany(p => p.Places)
                    .HasForeignKey(p => p.PlaceTypeID);
            
            modelBuilder.Entity<PlaceType>()
                    .HasMany(p => p.Places)
                    .WithOne(p => p.PlaceType)
                    .HasForeignKey(p => p.PlaceTypeID);
        }

    }
}