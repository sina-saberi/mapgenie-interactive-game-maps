using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace game_maps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeGameSlugUniq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "5301d115-48f3-4e11-8663-d73fb4534332" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5301d115-48f3-4e11-8663-d73fb4534332");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "844b7567-2b43-4922-8285-e6e73c59a199", 0, "a3a6543f-9855-4e86-9a54-57144e7561ad", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEJpxJZeNmK22TT2BMs7HLHfqidvNA8ukpAjT8jnT300lQbbYxYeea4k48uyGNP2pug==", null, false, "0d12a40f-27e2-4cc6-bf25-f38ab1824b0a", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "844b7567-2b43-4922-8285-e6e73c59a199" });

            migrationBuilder.CreateIndex(
                name: "IX_Games_Slug",
                table: "Games",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_Slug",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "844b7567-2b43-4922-8285-e6e73c59a199" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "844b7567-2b43-4922-8285-e6e73c59a199");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5301d115-48f3-4e11-8663-d73fb4534332", 0, "6cd7bf2f-67cd-42b8-988c-1f0dfbc77b1b", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEHdxP3GlfDH6ZXQ8Cp8TXiWkvDSgruSRwaKsihdS+ECZihdGsCuI/dDIFj+fDKbDMw==", null, false, "503121f4-b7f1-4576-9f1d-8baf61dbdaf6", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "5301d115-48f3-4e11-8663-d73fb4534332" });
        }
    }
}
