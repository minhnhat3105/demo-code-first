﻿// <auto-generated />
using DemoCodeFirst.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoCodeFirst.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoCodeFirst.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ABC",
                            StateId = 1,
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "XYZ",
                            StateId = 2,
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "MLB",
                            StateId = 3,
                            Status = true
                        });
                });

            modelBuilder.Entity("DemoCodeFirst.Data.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "bbb",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "kkk",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "zzz",
                            Status = true
                        });
                });

            modelBuilder.Entity("DemoCodeFirst.Data.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("State");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "ddd",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "eee",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            Name = "fff",
                            Status = true
                        });
                });

            modelBuilder.Entity("DemoCodeFirst.Data.Entities.City", b =>
                {
                    b.HasOne("DemoCodeFirst.Data.Entities.State", "State")
                        .WithMany("cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("DemoCodeFirst.Data.Entities.State", b =>
                {
                    b.HasOne("DemoCodeFirst.Data.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DemoCodeFirst.Data.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("DemoCodeFirst.Data.Entities.State", b =>
                {
                    b.Navigation("cities");
                });
#pragma warning restore 612, 618
        }
    }
}