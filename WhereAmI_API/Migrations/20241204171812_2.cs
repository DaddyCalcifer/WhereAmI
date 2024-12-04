using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WhereAmI_API.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SafeZone_Users_OwnerId",
                table: "SafeZone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SafeZone",
                table: "SafeZone");

            migrationBuilder.RenameTable(
                name: "SafeZone",
                newName: "SafeZones");

            migrationBuilder.RenameIndex(
                name: "IX_SafeZone_OwnerId",
                table: "SafeZones",
                newName: "IX_SafeZones_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SafeZones",
                table: "SafeZones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SafeZones_Users_OwnerId",
                table: "SafeZones",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SafeZones_Users_OwnerId",
                table: "SafeZones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SafeZones",
                table: "SafeZones");

            migrationBuilder.RenameTable(
                name: "SafeZones",
                newName: "SafeZone");

            migrationBuilder.RenameIndex(
                name: "IX_SafeZones_OwnerId",
                table: "SafeZone",
                newName: "IX_SafeZone_OwnerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SafeZone",
                table: "SafeZone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SafeZone_Users_OwnerId",
                table: "SafeZone",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
