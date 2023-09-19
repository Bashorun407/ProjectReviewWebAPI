using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectReviewWebAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66330d32-e164-46f4-80ac-0581d27cd228");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c787e650-eb75-4b4a-a769-fb50d5f456c5");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28a6b2c8-7fd8-46bb-88fe-986a87bd827c", null, "Admin", "ADMIN" },
                    { "866f2e66-3510-4370-8e2f-683819ab17ca", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28a6b2c8-7fd8-46bb-88fe-986a87bd827c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "866f2e66-3510-4370-8e2f-683819ab17ca");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Ratings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66330d32-e164-46f4-80ac-0581d27cd228", null, "User", "USER" },
                    { "c787e650-eb75-4b4a-a769-fb50d5f456c5", null, "Admin", "ADMIN" }
                });
        }
    }
}
