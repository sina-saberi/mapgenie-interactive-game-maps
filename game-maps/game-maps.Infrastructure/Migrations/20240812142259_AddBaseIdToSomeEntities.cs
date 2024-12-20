using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace game_maps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseIdToSomeEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Categories_CateogryId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Maps_MapId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CateogryId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "99dcd9ec-943b-48bf-a1d8-99eab85875a3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99dcd9ec-943b-48bf-a1d8-99eab85875a3");

            migrationBuilder.RenameColumn(
                name: "MapId",
                table: "Locations",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "CateogryId",
                table: "Locations",
                newName: "BaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_MapId",
                table: "Locations",
                newName: "IX_Locations_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "186fd750-96d3-4864-9c96-7e0fa565473d", 0, "43469a1b-211b-47f1-947a-ce6fc88673c2", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEFhFzZhV+VrO17YrL2bfX06bvcUTURTnWbYhI5jNeqCqJUmBEuKz0/G2s94Q0Hc5bg==", null, false, "309c21dd-19f3-45d4-bf1f-5c8ae4837cf4", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "186fd750-96d3-4864-9c96-7e0fa565473d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Categories_CategoryId",
                table: "Locations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Categories_CategoryId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "186fd750-96d3-4864-9c96-7e0fa565473d" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "186fd750-96d3-4864-9c96-7e0fa565473d");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Locations",
                newName: "MapId");

            migrationBuilder.RenameColumn(
                name: "BaseId",
                table: "Locations",
                newName: "CateogryId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CategoryId",
                table: "Locations",
                newName: "IX_Locations_MapId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "99dcd9ec-943b-48bf-a1d8-99eab85875a3", 0, "a581d2bd-4398-4951-91d8-115f2523a6f8", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAECMB1ktKOzGLAyYo3esk7CpSoUELGGEXVYw0RxJT6OYfrYSjG1hcANQG+f1ddZKOPw==", null, false, "b3914dfd-587c-4cf0-902c-a65849f37db0", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "99dcd9ec-943b-48bf-a1d8-99eab85875a3" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CateogryId",
                table: "Locations",
                column: "CateogryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Categories_CateogryId",
                table: "Locations",
                column: "CateogryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Maps_MapId",
                table: "Locations",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
