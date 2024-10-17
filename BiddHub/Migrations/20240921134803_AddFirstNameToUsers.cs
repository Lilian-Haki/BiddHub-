using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiddHub.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstNameToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "a56cc931-2ca8-43a0-b019-c3e884c269bf", "2", "Bidder", "Bidder" },
                    { "b2c30167-3de3-4ff4-a659-6f861c32d44d", "1", "Admin", "Admin" },
                    { "f4fc699f-c96e-43e2-8c71-77f705f5d8f9", "3", "Auctioneer", "Auctioneer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a56cc931-2ca8-43a0-b019-c3e884c269bf");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b2c30167-3de3-4ff4-a659-6f861c32d44d");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f4fc699f-c96e-43e2-8c71-77f705f5d8f9");

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
    }
}
