using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BiddHub.Migrations
{
    /// <inheritdoc />
    public partial class ProductDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "2f145ed5-9deb-4acc-a3f8-c7e5b7602d35");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "6611a637-5f6a-424e-9835-22f2b81c9d5f");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9601cc38-bd76-4919-95f7-a173e2faf51c");

            migrationBuilder.AlterColumn<string>(
                name: "Photos_Url",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.CreateTable(
                name: "ProductDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document_Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDocuments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "329d44da-c509-4154-bc43-eded2868ffc3", "1", "Admin", "Admin" },
                    { "9ef0e5aa-4eae-44ad-8ae8-7da6927d5ad6", "3", "Auctioneer", "Auctioneer" },
                    { "f83dce2b-8573-4ea4-b3e7-f899d266143a", "2", "Bidder", "Bidder" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDocuments");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "329d44da-c509-4154-bc43-eded2868ffc3");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9ef0e5aa-4eae-44ad-8ae8-7da6927d5ad6");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f83dce2b-8573-4ea4-b3e7-f899d266143a");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photos_Url",
                table: "ProductImages",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f145ed5-9deb-4acc-a3f8-c7e5b7602d35", "2", "Bidder", "Bidder" },
                    { "6611a637-5f6a-424e-9835-22f2b81c9d5f", "3", "Auctioneer", "Auctioneer" },
                    { "9601cc38-bd76-4919-95f7-a173e2faf51c", "1", "Admin", "Admin" }
                });
        }
    }
}
