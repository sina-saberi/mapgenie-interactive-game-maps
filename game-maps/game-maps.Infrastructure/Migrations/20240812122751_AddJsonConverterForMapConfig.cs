using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace game_maps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJsonConverterForMapConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "50e160b2-f675-4870-af75-038d9857d584" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50e160b2-f675-4870-af75-038d9857d584");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "be6a16e0-5546-4732-930e-5b70531d077a", 0, "57b3a2dc-0546-481b-99fc-59f6eca65d80", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEPJEPL5VorzTKL+cZ/RA57qw0Dca2L3FVgeA0uEQQIinyxiluOpNnikof7H8YFGt1g==", null, false, "52611bf7-d287-4e41-9b34-454dfd0ddaef", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "be6a16e0-5546-4732-930e-5b70531d077a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "be6a16e0-5546-4732-930e-5b70531d077a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be6a16e0-5546-4732-930e-5b70531d077a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "50e160b2-f675-4870-af75-038d9857d584", 0, "0357030e-e269-4884-87c9-d137a4faf1dc", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEMpqnTVkZ4KsUQpFl7LKE/U7KJ2EUFgILvr+zJAkyIGFO20jXN21817j/FKtfV/I6g==", null, false, "eaa39d31-13eb-4545-8c3a-b868c70dee9e", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "50e160b2-f675-4870-af75-038d9857d584" });
        }
    }
}
