using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TitleNotReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemUserRolePermission_Title",
                table: "SystemUserRolePermission");

            migrationBuilder.DropIndex(
                name: "IX_SystemUserPermission_Title",
                table: "SystemUserPermission");

            migrationBuilder.DropIndex(
                name: "IX_Systems_Title",
                table: "Systems");

            migrationBuilder.DropIndex(
                name: "IX_SystemRoleUser_Title",
                table: "SystemRoleUser");

            migrationBuilder.DropIndex(
                name: "IX_SystemRolesPermission_Title",
                table: "SystemRolesPermission");

            migrationBuilder.DropIndex(
                name: "IX_SystemRoles_Title",
                table: "SystemRoles");

            migrationBuilder.DropIndex(
                name: "IX_SystemPermission_Title",
                table: "SystemPermission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_Title",
                table: "Permission");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemUserRolePermission",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemUserPermission",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Systems",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemRoleUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemRolesPermission",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemRoles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemPermission",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Permission",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_Title",
                table: "SystemUserRolePermission",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Title",
                table: "SystemUserPermission",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_Title",
                table: "Systems",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_Title",
                table: "SystemRoleUser",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_Title",
                table: "SystemRolesPermission",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_Title",
                table: "SystemRoles",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemPermission_Title",
                table: "SystemPermission",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Title",
                table: "Permission",
                column: "Title",
                unique: true,
                filter: "[Title] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SystemUserRolePermission_Title",
                table: "SystemUserRolePermission");

            migrationBuilder.DropIndex(
                name: "IX_SystemUserPermission_Title",
                table: "SystemUserPermission");

            migrationBuilder.DropIndex(
                name: "IX_Systems_Title",
                table: "Systems");

            migrationBuilder.DropIndex(
                name: "IX_SystemRoleUser_Title",
                table: "SystemRoleUser");

            migrationBuilder.DropIndex(
                name: "IX_SystemRolesPermission_Title",
                table: "SystemRolesPermission");

            migrationBuilder.DropIndex(
                name: "IX_SystemRoles_Title",
                table: "SystemRoles");

            migrationBuilder.DropIndex(
                name: "IX_SystemPermission_Title",
                table: "SystemPermission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_Title",
                table: "Permission");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemUserRolePermission",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemUserPermission",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Systems",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemRoleUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemRolesPermission",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemRoles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "SystemPermission",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Permission",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_Title",
                table: "SystemUserRolePermission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Title",
                table: "SystemUserPermission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Systems_Title",
                table: "Systems",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_Title",
                table: "SystemRoleUser",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_Title",
                table: "SystemRolesPermission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_Title",
                table: "SystemRoles",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemPermission_Title",
                table: "SystemPermission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Title",
                table: "Permission",
                column: "Title",
                unique: true);
        }
    }
}
