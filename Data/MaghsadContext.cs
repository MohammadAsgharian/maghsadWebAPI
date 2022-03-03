using Microsoft.EntityFrameworkCore;
using maghsadAPI.Models;


namespace maghsadAPI.Data
{
    public class MaghsadContext : DbContext
    {

        public MaghsadContext(DbContextOptions<MaghsadContext> options): base(options: options)
        {

        }
        // Set Of All Places {Like Hotels, Attractions, Restourant and etc }
        public DbSet<Models.Place> Places{get; set;}

        public DbSet<Models.PlaceType> PlaceTypes{get; set;}

        public DbSet<Models.User> Users { get; set; }

        public DbSet<Models.UserLevel> UserLevels{get; set;}

        public DbSet<Models.PlacePhoto> PlacePhotos{get; set;}

        public DbSet<Models.Province> Provinces{get; set;}
        public DbSet<Models.City> Cities{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>()
                    .HasOne(p => p.PlaceType)
                    .WithMany(p => p.Places)
                    .HasForeignKey(p => p.PlaceTypeId);

            modelBuilder.Entity<PlaceType>()
                    .HasMany(p => p.Places)
                    .WithOne(p => p.PlaceType)
                    .HasForeignKey(p => p.PlaceTypeId);


            modelBuilder.Entity<User>()
                    .HasOne(p => p.UserLevel)
                    .WithMany(p => p.Users)
                    .HasForeignKey(p => p.UserLevelID);            
            modelBuilder.Entity<UserLevel>()
                    .HasMany(p => p.Users)
                    .WithOne(p => p.UserLevel)
                    .HasForeignKey(p => p.UserLevelID);
            

             modelBuilder.Entity<PlacePhoto>()
                    .HasOne(p => p.AppUser)
                    .WithMany(p => p.PlacePhotos)
                    .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Models.Identity.AppUser>()
                    .HasMany(p => p.PlacePhotos)
                    .WithOne(p => p.AppUser)
                    .HasForeignKey(p => p.UserId);



                modelBuilder.Entity<PlacePhoto>()
                    .HasOne(p => p.Place)
                    .WithMany(p => p.PlacePhotos)
                    .HasForeignKey(p => p.PlaceId);
                modelBuilder.Entity<Place>()
                    .HasMany(p => p.PlacePhotos)
                    .WithOne(p => p.Place)
                    .HasForeignKey(p => p.PlaceId);

                //      Summery
                //              Relation Between Place And City
                //              Every City has many Places (Hotels, Attractions and etc)
                //              ForeignKey CityID in Place Table

                modelBuilder.Entity<Place>()
                    .HasOne(p => p.City)
                    .WithMany(p => p.Places)
                    .HasForeignKey(p => p.CityId);
                modelBuilder.Entity<City>()
                    .HasMany(p => p.Places)
                    .WithOne(p => p.City)
                    .HasForeignKey(p => p.CityId);


                //      Summery
                //              Relation Between City And Province
                //              ForeignKey CityID in Province Table

                modelBuilder.Entity<City>()
                    .HasOne(p => p.Province)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(p => p.ProvinceID);
                modelBuilder.Entity<Province>()
                    .HasMany(p => p.Cities)
                    .WithOne(p => p.Province)
                    .HasForeignKey(p => p.ProvinceID);


                //      Summery
                //              Relation Between Place And User
                //              ForeignKey UserId in Place Table
                
                modelBuilder.Entity<Place>()
                    .HasOne(p => p.AppUser)
                    .WithMany(p => p.Places)
                    .HasForeignKey(p => p.UserId);
                modelBuilder.Entity<Models.Identity.AppUser>()
                    .HasMany(p => p.Places)
                    .WithOne(p => p.AppUser)
                    .HasForeignKey(p => p.UserId);


                //      Summery
                //              Relation Between AttractionType And Place
                //              ForeignKey AttractionType in Place Table
                
                modelBuilder.Entity<Place>()
                    .HasOne(p => p.AttractionType)
                    .WithMany(p => p.Places)
                    .HasForeignKey(p => p.AttractionId);
                modelBuilder.Entity<AttractionType>()
                    .HasMany(p => p.Places)
                    .WithOne(p => p.AttractionType)
                    .HasForeignKey(p => p.AttractionId);
        }
    }
}