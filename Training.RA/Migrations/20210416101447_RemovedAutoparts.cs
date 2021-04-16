using Microsoft.EntityFrameworkCore.Migrations;

namespace Training.RA.Migrations
{
    public partial class RemovedAutoparts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autoparts",
                columns: new[] { "Id", "Description", "Name", "Price", "ProducerId" },
                values: new object[] { 1, "Battery Edcon DC35300R 35 A/h", "Battery", 100.0, 2 });

            migrationBuilder.InsertData(
                table: "Autoparts",
                columns: new[] { "Id", "Description", "Name", "Price", "ProducerId" },
                values: new object[] { 2, "Automatic transmission", "Gear box cushion", 10.5, 1 });

            migrationBuilder.InsertData(
                table: "Autoparts",
                columns: new[] { "Id", "Description", "Name", "Price", "ProducerId" },
                values: new object[] { 3, "Diameter 322, Installation side - fornt axle", "Disc brake kit", 10.1, 1 });
        }
    }
}
