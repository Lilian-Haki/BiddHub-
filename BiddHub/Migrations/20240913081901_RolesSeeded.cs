using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiddHub.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "45a74bce-354d-4c39-810e-79dc49173208");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "61257051-1c56-40ed-bcda-195f032a9d40");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "671cc8e2-2b15-49c1-a989-999753e00fb8");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12adb9e5-966d-4acc-b8eb-c8e21a304689", "1", "Admin", "Admin" },
                    { "242e9d90-1588-4cd8-ae87-cd725c2fbf08", "2", "Bidder", "Bidder" },
                    { "66434651-b119-416a-92de-8595a34b5fad", "3", "Auctioneer", "Auctioneer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "12adb9e5-966d-4acc-b8eb-c8e21a304689");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "242e9d90-1588-4cd8-ae87-cd725c2fbf08");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "66434651-b119-416a-92de-8595a34b5fad");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "45a74bce-354d-4c39-810e-79dc49173208", "3", "Auctioneer", "Auctioneer" },
                    { "61257051-1c56-40ed-bcda-195f032a9d40", "2", "Bidder", "Bidder" },
                    { "671cc8e2-2b15-49c1-a989-999753e00fb8", "1", "Admin", "Admin" }
                });
        }
    }
}
