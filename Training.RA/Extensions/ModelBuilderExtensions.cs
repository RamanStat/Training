using Microsoft.EntityFrameworkCore;
using Training.Data.Entities;

namespace Training.RA.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client() { Id = 1, FirstName = "Roman", LastName = "Statkevich", Email = "romanstat@test.ru", Phone = "+375447777777" },
                new Client() { Id = 2, FirstName = "Pavel", LastName = "Selitsky", Email = "pavelselit@test.ru", Phone = "+375447777777" });

            modelBuilder.Entity<Producer>().HasData(
                new Producer() { Id = 1, Name = "Volkswagen", Address = "Wolfsburg" },
                new Producer() { Id = 2, Name = "BMW", Address = "Petuelring 130, 80809 München, Germany" },
                new Producer() { Id = 3, Name = "Mercedes", Address = "Stuttgart, Germany" });

            modelBuilder.Entity<Vendor>().HasData(
                new Vendor() { Id = 1, Name = "MercedesBelarus", Address = "Ulitsa Timiryazeva 70, Minsk" },
                new Vendor() { Id = 2, Name = "BMWGroup", Address = "Leningradskoye Hwy, Moscow", Phone = "+7 800 550-88-00" },
                new Vendor() { Id = 3, Name = "VolkswagenUkraine", Address = "Sofiivska Borschahivka, Kyiv Oblast, Ukraine" });

            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 1, Brand = "Mercedes", Model = "E-CLASS", Engine = (int)EngineIdentifiers.Diesel, IssueYear = 2021 },
                new Car() { Id = 2, Brand = "Mercedes", Model = "GLE", Engine = (int)EngineIdentifiers.Diesel, IssueYear = 2020 },
                new Car() { Id = 3, Brand = "BMW", Model = "X5", Engine = (int)EngineIdentifiers.Diesel, IssueYear = 2020 },
                new Car() { Id = 4, Brand = "BMW", Model = "X7", Engine = (int)EngineIdentifiers.Diesel, IssueYear = 2021 });

            modelBuilder.Entity<Autopart>().HasData(
                new Autopart() { Id = 1, ProducerId = 2, Name = "Battery", Description = "Battery Edcon DC35300R 35 A/h", Price = 100 },
                new Autopart() { Id = 2, ProducerId = 1, Name = "Gear box cushion", Description = "Automatic transmission", Price = 10.5 },
                new Autopart() { Id = 3, ProducerId = 1, Name = "Disc brake kit", Description = "Diameter 322, Installation side - fornt axle", Price = 10.1 });
        }
    }
}
