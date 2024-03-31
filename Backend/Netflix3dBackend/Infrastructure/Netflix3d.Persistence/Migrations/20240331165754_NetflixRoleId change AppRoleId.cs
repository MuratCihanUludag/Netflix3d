using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netflix3d.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NetflixRoleIdchangeAppRoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppRoles_NetflixRoleId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "AppRole",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "NetflixRoleId",
                table: "AppUsers",
                newName: "AppRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_NetflixRoleId",
                table: "AppUsers",
                newName: "IX_AppUsers_AppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers",
                column: "AppRoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppRoles_AppRoleId",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "AppRoleId",
                table: "AppUsers",
                newName: "NetflixRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUsers_AppRoleId",
                table: "AppUsers",
                newName: "IX_AppUsers_NetflixRoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "AppRole",
                table: "AppUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppRoles_NetflixRoleId",
                table: "AppUsers",
                column: "NetflixRoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
