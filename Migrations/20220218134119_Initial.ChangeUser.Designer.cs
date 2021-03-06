// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using maghsadAPI.Data;

namespace maghsadAPI.Migrations
{
    [DbContext(typeof(MaghsadContext))]
    [Migration("20220218134119_Initial.ChangeUser")]
    partial class InitialChangeUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("maghsadAPI.Models.Place", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("PlaceTypeID")
                        .HasColumnType("bigint");

                    b.Property<int?>("PriceType")
                        .HasColumnType("int");

                    b.Property<string>("Site")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Tel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("grade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceTypeID");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("maghsadAPI.Models.PlacePhoto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsCover")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PlaceID")
                        .HasColumnType("bigint");

                    b.Property<long?>("PlacePhotoId")
                        .HasColumnType("bigint");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TypeFile")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PlaceID");

                    b.HasIndex("PlacePhotoId");

                    b.HasIndex("UserID");

                    b.ToTable("PlacePhotos");
                });

            modelBuilder.Entity("maghsadAPI.Models.PlaceType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("PlaceTypes");
                });

            modelBuilder.Entity("maghsadAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivateSms")
                        .HasColumnType("int");

                    b.Property<int?>("ActivationCodeEmail")
                        .HasColumnType("int");

                    b.Property<string>("AvatarPhotoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPhotoName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool?>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("InstagramName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte[]>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("varbinary(50)");

                    b.Property<DateTime>("SinginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tel")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("UserLevelID")
                        .HasColumnType("bigint");

                    b.Property<long?>("YourEarn")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserLevelID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("maghsadAPI.Models.UserLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserLevels");
                });

            modelBuilder.Entity("maghsadAPI.Models.Place", b =>
                {
                    b.HasOne("maghsadAPI.Models.PlaceType", "PlaceType")
                        .WithMany("Places")
                        .HasForeignKey("PlaceTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlaceType");
                });

            modelBuilder.Entity("maghsadAPI.Models.PlacePhoto", b =>
                {
                    b.HasOne("maghsadAPI.Models.Place", "Place")
                        .WithMany("PlacePhotos")
                        .HasForeignKey("PlaceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("maghsadAPI.Models.PlacePhoto", null)
                        .WithMany("PlacePhotos")
                        .HasForeignKey("PlacePhotoId");

                    b.HasOne("maghsadAPI.Models.User", "User")
                        .WithMany("PlacePhotos")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("maghsadAPI.Models.User", b =>
                {
                    b.HasOne("maghsadAPI.Models.UserLevel", "UserLevel")
                        .WithMany("Users")
                        .HasForeignKey("UserLevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserLevel");
                });

            modelBuilder.Entity("maghsadAPI.Models.Place", b =>
                {
                    b.Navigation("PlacePhotos");
                });

            modelBuilder.Entity("maghsadAPI.Models.PlacePhoto", b =>
                {
                    b.Navigation("PlacePhotos");
                });

            modelBuilder.Entity("maghsadAPI.Models.PlaceType", b =>
                {
                    b.Navigation("Places");
                });

            modelBuilder.Entity("maghsadAPI.Models.User", b =>
                {
                    b.Navigation("PlacePhotos");
                });

            modelBuilder.Entity("maghsadAPI.Models.UserLevel", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
