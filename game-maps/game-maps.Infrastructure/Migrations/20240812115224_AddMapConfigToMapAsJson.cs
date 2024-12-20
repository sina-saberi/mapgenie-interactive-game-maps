using Microsoft.EntityFrameworkCore.Migrations;
using game_maps.Domain.Entities.Map;

#nullable disable

namespace game_maps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMapConfigToMapAsJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TileSets_Maps_MapId",
                table: "TileSets");

            migrationBuilder.DropIndex(
                name: "IX_TileSets_MapId",
                table: "TileSets");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "844b7567-2b43-4922-8285-e6e73c59a199" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "844b7567-2b43-4922-8285-e6e73c59a199");

            migrationBuilder.DropColumn(
                name: "MapConfig_InitialZoom",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "MapConfig_StartLat",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "MapConfig_StartLng",
                table: "Maps");

            migrationBuilder.AddColumn<MapConfig>(
                name: "MapConfig",
                table: "Maps",
                type: "jsonb",
                nullable: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64d03a1f-bec5-4aab-9135-dca5cafe8b03", 0, "58859eb7-18ea-4c68-b4fb-041c1c22d09c", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEG/KjrhmCdt63U6G40R7KemJrq8o5RtCdltEcjaMlb575YvFXhrmya0IoDxAc2falA==", null, false, "482d5cdf-0032-4d5e-8e96-dd57e5694a8e", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "64d03a1f-bec5-4aab-9135-dca5cafe8b03" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "64d03a1f-bec5-4aab-9135-dca5cafe8b03" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64d03a1f-bec5-4aab-9135-dca5cafe8b03");

            migrationBuilder.DropColumn(
                name: "MapConfig",
                table: "Maps");

            migrationBuilder.AddColumn<int>(
                name: "MapConfig_InitialZoom",
                table: "Maps",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MapConfig_StartLat",
                table: "Maps",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MapConfig_StartLng",
                table: "Maps",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "844b7567-2b43-4922-8285-e6e73c59a199", 0, "a3a6543f-9855-4e86-9a54-57144e7561ad", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEJpxJZeNmK22TT2BMs7HLHfqidvNA8ukpAjT8jnT300lQbbYxYeea4k48uyGNP2pug==", null, false, "0d12a40f-27e2-4cc6-bf25-f38ab1824b0a", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bfd3e341-69d2-4dff-9c0f-6047a11ce4c7", "844b7567-2b43-4922-8285-e6e73c59a199" });

            migrationBuilder.CreateIndex(
                name: "IX_TileSets_MapId",
                table: "TileSets",
                column: "MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_TileSets_Maps_MapId",
                table: "TileSets",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
