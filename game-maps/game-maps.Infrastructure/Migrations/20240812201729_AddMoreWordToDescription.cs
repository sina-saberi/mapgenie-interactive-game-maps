using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace game_maps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreWordToDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "186fd750-96d3-4864-9c96-7e0fa565473d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "186fd750-96d3-4864-9c96-7e0fa565473d");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Locations",
                type: "character varying(8000)",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(3000)",
                oldMaxLength: 3000);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "afe347c2-a336-4aa6-9276-7674aaa5514e", 0, "7fa99cf1-b090-4483-8f90-67cd7d28573e", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEMzKPJTkl45igcQ/yF9FnCqMRv5VBqNvromGXil7O0uiJ15+8axvblSoqW+ZzRwnmw==", null, false, "d6085ffd-e35b-4236-ac2c-20a7fd5eb116", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "afe347c2-a336-4aa6-9276-7674aaa5514e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "afe347c2-a336-4aa6-9276-7674aaa5514e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afe347c2-a336-4aa6-9276-7674aaa5514e");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Locations",
                type: "character varying(3000)",
                maxLength: 3000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(8000)",
                oldMaxLength: 8000);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "186fd750-96d3-4864-9c96-7e0fa565473d", 0, "43469a1b-211b-47f1-947a-ce6fc88673c2", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEFhFzZhV+VrO17YrL2bfX06bvcUTURTnWbYhI5jNeqCqJUmBEuKz0/G2s94Q0Hc5bg==", null, false, "309c21dd-19f3-45d4-bf1f-5c8ae4837cf4", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "186fd750-96d3-4864-9c96-7e0fa565473d" });
        }
    }
}
