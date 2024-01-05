﻿// <auto-generated />
using System;
using HomeworkModule4Lesson4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeworkModule4Lesson4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.BreedEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BreedId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BreedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Breed", (string)null);
                });

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.LocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LocationID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.PetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PetID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Age")
                        .HasColumnType("float");

                    b.Property<int?>("BreedId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BreedId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.ToTable("Pet", (string)null);
                });

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.BreedEntity", b =>
                {
                    b.HasOne("HomeworkModule4Lesson4.Data.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.PetEntity", b =>
                {
                    b.HasOne("HomeworkModule4Lesson4.Data.Entities.BreedEntity", "Breed")
                        .WithMany("Pets")
                        .HasForeignKey("BreedId");

                    b.HasOne("HomeworkModule4Lesson4.Data.Entities.CategoryEntity", "Category")
                        .WithMany("Pets")
                        .HasForeignKey("CategoryId");

                    b.HasOne("HomeworkModule4Lesson4.Data.Entities.LocationEntity", "Location")
                        .WithMany("Pets")
                        .HasForeignKey("LocationId");

                    b.Navigation("Breed");

                    b.Navigation("Category");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.BreedEntity", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("HomeworkModule4Lesson4.Data.Entities.LocationEntity", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
