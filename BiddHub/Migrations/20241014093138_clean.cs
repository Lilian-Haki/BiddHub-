using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiddHub.Migrations
{
    /// <inheritdoc />
    public partial class clean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ProductsImages");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4f2db908-1a51-4bf7-892d-6e8937104288");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "62b63e95-a411-419b-9046-95e96cd216d0");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "eacd3fa2-d785-40f9-94cf-d1b58a49ae1e");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            //migrationBuilder.CreateTable(
            //    name: "ProductsImages",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Photos_Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ProductsImages", x => x.Id);
            //    });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f2db908-1a51-4bf7-892d-6e8937104288", "1", "Admin", "Admin" },
                    { "62b63e95-a411-419b-9046-95e96cd216d0", "3", "Auctioneer", "Auctioneer" },
                    { "eacd3fa2-d785-40f9-94cf-d1b58a49ae1e", "2", "Bidder", "Bidder" }
                });
        }
    }
}
