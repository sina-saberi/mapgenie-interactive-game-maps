using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace game_maps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignOfMapToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "be6a16e0-5546-4732-930e-5b70531d077a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be6a16e0-5546-4732-930e-5b70531d077a");

            migrationBuilder.AddColumn<int>(
                name: "MapId",
                table: "Locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99dcd9ec-943b-48bf-a1d8-99eab85875a3", 0, "a581d2bd-4398-4951-91d8-115f2523a6f8", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAECMB1ktKOzGLAyYo3esk7CpSoUELGGEXVYw0RxJT6OYfrYSjG1hcANQG+f1ddZKOPw==", null, false, "b3914dfd-587c-4cf0-902c-a65849f37db0", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "99dcd9ec-943b-48bf-a1d8-99eab85875a3" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MapId",
                table: "Locations",
                column: "MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Maps_MapId",
                table: "Locations",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Maps_MapId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MapId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "99dcd9ec-943b-48bf-a1d8-99eab85875a3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99dcd9ec-943b-48bf-a1d8-99eab85875a3");

            migrationBuilder.DropColumn(
                name: "MapId",
                table: "Locations");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "be6a16e0-5546-4732-930e-5b70531d077a", 0, "57b3a2dc-0546-481b-99fc-59f6eca65d80", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEPJEPL5VorzTKL+cZ/RA57qw0Dca2L3FVgeA0uEQQIinyxiluOpNnikof7H8YFGt1g==", null, false, "52611bf7-d287-4e41-9b34-454dfd0ddaef", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "be6a16e0-5546-4732-930e-5b70531d077a" });
        }
    }
}
