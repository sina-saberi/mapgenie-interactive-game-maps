using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace game_maps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", null, "Admin", "ADMIN" },
                    { "cd6da49a-8c12-4938-9854-5c17fdf4a24d", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5301d115-48f3-4e11-8663-d73fb4534332", 0, "6cd7bf2f-67cd-42b8-988c-1f0dfbc77b1b", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEHdxP3GlfDH6ZXQ8Cp8TXiWkvDSgruSRwaKsihdS+ECZihdGsCuI/dDIFj+fDKbDMw==", null, false, "503121f4-b7f1-4576-9f1d-8baf61dbdaf6", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "CreateGameAndMap", "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7" },
                    { 2, "Permission", "UpdateGameAndMap", "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7" },
                    { 3, "Permission", "MapInteraction", "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7" },
                    { 4, "Permission", "UserManagement", "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7" },
                    { 5, "Permission", "MapInteraction", "cd6da49a-8c12-4938-9854-5c17fdf4a24d" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "5301d115-48f3-4e11-8663-d73fb4534332" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "5301d115-48f3-4e11-8663-d73fb4534332" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd6da49a-8c12-4938-9854-5c17fdf4a24d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5301d115-48f3-4e11-8663-d73fb4534332");
        }
    }
}
