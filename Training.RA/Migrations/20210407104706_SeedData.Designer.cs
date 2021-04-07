﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Training.RA.DbContexts;

namespace Training.RA.Migrations
{
    [DbContext(typeof(SQLDbContext))]
    [Migration("20210407104706_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutopartCar", b =>
                {
                    b.Property<int>("AutopartsId")
                        .HasColumnType("int");

                    b.Property<int>("CarsId")
                        .HasColumnType("int");

                    b.HasKey("AutopartsId", "CarsId");

                    b.HasIndex("CarsId");

                    b.ToTable("AutopartCar");
                });

            modelBuilder.Entity("AutopartVendor", b =>
                {
                    b.Property<int>("AutopartsId")
                        .HasColumnType("int");

                    b.Property<int>("VendorsId")
                        .HasColumnType("int");

                    b.HasKey("AutopartsId", "VendorsId");

                    b.HasIndex("VendorsId");

                    b.ToTable("AutopartVendor");
                });

            modelBuilder.Entity("Data.Entities.Autopart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("Autoparts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Battery Edcon DC35300R 35 A/h",
                            Name = "Battery",
                            Price = 100.0,
                            ProducerId = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "Automatic transmission",
                            Name = "Gear box cushion",
                            Price = 10.5,
                            ProducerId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Diameter 322, Installation side - fornt axle",
                            Name = "Disc brake kit",
                            Price = 10.1,
                            ProducerId = 1
                        });
                });

            modelBuilder.Entity("Data.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Engine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IssueYear")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Mercedes",
                            Engine = "diesel 2.0",
                            IssueYear = 2021,
                            Model = "E-CLASS"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Mercedes",
                            Engine = "diesel 5.0",
                            IssueYear = 2020,
                            Model = "GLE"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "BMW",
                            Engine = "diesel 3.0",
                            IssueYear = 2020,
                            Model = "X5"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "BMW",
                            Engine = "diesel 5.0",
                            IssueYear = 2021,
                            Model = "X7"
                        });
                });

            modelBuilder.Entity("Data.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "romanstat@test.ru",
                            FirstName = "Roman",
                            LastName = "Statkevich",
                            Phone = "+375447777777"
                        },
                        new
                        {
                            Id = 2,
                            Email = "pavelselit@test.ru",
                            FirstName = "Pavel",
                            LastName = "Selitsky",
                            Phone = "+375447777777"
                        });
                });

            modelBuilder.Entity("Data.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutopartId")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AutopartId");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Data.Entities.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Wolfsburg",
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Petuelring 130, 80809 München, Germany",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Stuttgart, Germany",
                            Name = "Mercedes"
                        });
                });

            modelBuilder.Entity("Data.Entities.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Ulitsa Timiryazeva 70, Minsk",
                            Name = "MercedesBelarus"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Leningradskoye Hwy, Moscow",
                            Name = "BMWGroup",
                            Phone = "+7 800 550-88-00"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Sofiivska Borschahivka, Kyiv Oblast, Ukraine",
                            Name = "VolkswagenUkraine"
                        });
                });

            modelBuilder.Entity("AutopartCar", b =>
                {
                    b.HasOne("Data.Entities.Autopart", null)
                        .WithMany()
                        .HasForeignKey("AutopartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutopartVendor", b =>
                {
                    b.HasOne("Data.Entities.Autopart", null)
                        .WithMany()
                        .HasForeignKey("AutopartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Vendor", null)
                        .WithMany()
                        .HasForeignKey("VendorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Autopart", b =>
                {
                    b.HasOne("Data.Entities.Producer", "Producer")
                        .WithMany("Autoparts")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("Data.Entities.Order", b =>
                {
                    b.HasOne("Data.Entities.Autopart", "Autopart")
                        .WithMany()
                        .HasForeignKey("AutopartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autopart");

                    b.Navigation("Car");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Data.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Data.Entities.Producer", b =>
                {
                    b.Navigation("Autoparts");
                });
#pragma warning restore 612, 618
        }
    }
}
