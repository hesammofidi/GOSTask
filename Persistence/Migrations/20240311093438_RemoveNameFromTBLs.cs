using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNameFromTBLs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionName",
                table: "SystemUserRolePermission");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "SystemUserRolePermission");

            migrationBuilder.DropColumn(
                name: "SystemName",
                table: "SystemUserRolePermission");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SystemUserRolePermission");

            migrationBuilder.DropColumn(
                name: "PermissionName",
                table: "SystemUserPermission");

            migrationBuilder.DropColumn(
                name: "SystemName",
                table: "SystemUserPermission");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SystemUserPermission");

            migrationBuilder.DropColumn(
                name: "PermissionName",
                table: "SystemRolesPermission");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "SystemRolesPermission");

            migrationBuilder.DropColumn(
                name: "SystemName",
                table: "SystemRolesPermission");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermissionName",
                table: "SystemUserRolePermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "SystemUserRolePermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                table: "SystemUserRolePermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SystemUserRolePermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionName",
                table: "SystemUserPermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                table: "SystemUserPermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SystemUserPermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionName",
                table: "SystemRolesPermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "SystemRolesPermission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemName",
                table: "SystemRolesPermission",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
