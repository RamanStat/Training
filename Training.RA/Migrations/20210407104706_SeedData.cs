using Microsoft.EntityFrameworkCore.Migrations;

namespace Training.RA.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Engine", "IssueYear", "Model" },
                values: new object[,]
                {
                    { 1, "Mercedes", "diesel 2.0", 2021, "E-CLASS" },
                    { 2, "Mercedes", "diesel 5.0", 2020, "GLE" },
                    { 3, "BMW", "diesel 3.0", 2020, "X5" },
                    { 4, "BMW", "diesel 5.0", 2021, "X7" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "romanstat@test.ru", "Roman", "Statkevich", "+375447777777" },
                    { 2, "pavelselit@test.ru", "Pavel", "Selitsky", "+375447777777" }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Wolfsburg", "Volkswagen", null },
                    { 2, "Petuelring 130, 80809 München, Germany", "BMW", null },
                    { 3, "Stuttgart, Germany", "Mercedes", null }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Ulitsa Timiryazeva 70, Minsk", "MercedesBelarus", null },
                    { 2, "Leningradskoye Hwy, Moscow", "BMWGroup", "+7 800 550-88-00" },
                    { 3, "Sofiivska Borschahivka, Kyiv Oblast, Ukraine", "VolkswagenUkraine", null }
                });

            migrationBuilder.InsertData(
                table: "Autoparts",
                columns: new[] { "Id", "Description", "Name", "Price", "ProducerId" },
                values: new object[] { 2, "Automatic transmission", "Gear box cushion", 10.5, 1 });

            migrationBuilder.InsertData(
                table: "Autoparts",
                columns: new[] { "Id", "Description", "Name", "Price", "ProducerId" },
                values: new object[] { 3, "Diameter 322, Installation side - fornt axle", "Disc brake kit", 10.1, 1 });

            migrationBuilder.InsertData(
                table: "Autoparts",
                columns: new[] { "Id", "Description", "Name", "Price", "ProducerId" },
                values: new object[] { 1, "Battery Edcon DC35300R 35 A/h", "Battery", 100.0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autoparts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autoparts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Autoparts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Producers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
