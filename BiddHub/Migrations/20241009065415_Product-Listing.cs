using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiddHub.Migrations
{
    /// <inheritdoc />
    public partial class ProductListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "15e1db70-f404-42cd-bb71-eec9373e77d1");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7e59abf3-6b27-4efa-add6-7851df2ed9ea");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "d2d49cf0-4a47-4a5e-a5aa-f0d4ad7400da");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason_for_listing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owners_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner_Phone_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reserve_Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo_id = table.Column<int>(type: "int", nullable: false),
                    Documents_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "569c33ce-c76e-44c9-99e4-a04b333d4edd", "3", "Auctioneer", "Auctioneer" },
                    { "61c3e454-3df6-4788-ba70-71b2836ebc73", "2", "Bidder", "Bidder" },
                    { "f97f2cfa-a30b-4c83-a778-3707434f49e6", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "569c33ce-c76e-44c9-99e4-a04b333d4edd");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "61c3e454-3df6-4788-ba70-71b2836ebc73");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f97f2cfa-a30b-4c83-a778-3707434f49e6");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15e1db70-f404-42cd-bb71-eec9373e77d1", "1", "Admin", "Admin" },
                    { "7e59abf3-6b27-4efa-add6-7851df2ed9ea", "3", "Auctioneer", "Auctioneer" },
                    { "d2d49cf0-4a47-4a5e-a5aa-f0d4ad7400da", "2", "Bidder", "Bidder" }
                });
        }
    }
}
