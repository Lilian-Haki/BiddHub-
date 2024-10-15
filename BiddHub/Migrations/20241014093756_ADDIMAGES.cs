using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiddHub.Migrations
{
    /// <inheritdoc />
    public partial class ADDIMAGES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "393b126f-67d2-4b6b-9260-6ff29e24483b");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "67acc603-c3d7-4721-a7e7-6ee31abe956d");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8ead28b0-8ff7-482c-9ed4-1d7a4da6b3ff");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photos_Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "009652b5-2c3c-4c09-b883-f255ea112192", "1", "Admin", "Admin" },
                    { "5bed7738-4729-4a3b-8735-c6418cdc26d3", "3", "Auctioneer", "Auctioneer" },
                    { "75001dde-b462-4b01-b1b0-af959f16f4d5", "2", "Bidder", "Bidder" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "009652b5-2c3c-4c09-b883-f255ea112192");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5bed7738-4729-4a3b-8735-c6418cdc26d3");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "75001dde-b462-4b01-b1b0-af959f16f4d5");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "393b126f-67d2-4b6b-9260-6ff29e24483b", "1", "Admin", "Admin" },
                    { "67acc603-c3d7-4721-a7e7-6ee31abe956d", "2", "Bidder", "Bidder" },
                    { "8ead28b0-8ff7-482c-9ed4-1d7a4da6b3ff", "3", "Auctioneer", "Auctioneer" }
                });
        }
    }
}
