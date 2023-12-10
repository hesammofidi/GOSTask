using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                schema: "identity",
                table: "Users",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                schema: "identity",
                table: "Roles",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30b54ae3-5c16-4ee4-8c87-9200ea8a8901", null, "IdentityRole", "Basicuser", "BASICUSER" },
                    { "c02facf2-bb3e-4f0c-b503-1c904b429e22", null, "IdentityRole", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c02facf2-bb3e-4f0c-b503-1c904b429e22", "982bb98e-60e7-4eaa-adff-981b432b0a34" },
                    { "30b54ae3-5c16-4ee4-8c87-9200ea8a8901", "e4651308-6b8d-4514-8bc4-c4cf3f75a925" }
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "InsertTime", "IsRemoved", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RemoveTime", "SecurityStamp", "TwoFactorEnabled", "UpdateTime", "UserName" },
                values: new object[,]
                {
                    { "982bb98e-60e7-4eaa-adff-981b432b0a34", 0, "3a27f8b1-862c-4923-82aa-eab549cb1312", "User", "mofidihesam8@gmail.com", false, "HesamMofidi1", null, null, false, null, "MOFIDIHESAM8@GMAIL.COM", "MOFIDIHESAM8@GMAIL.COM", "AQAAAAIAAYagAAAAEO7QpuPt/IY43KU/mMl4EAwlZFL8Zc9Gg/qrJxZZjHDM7M+kxxZ4hcv7I493baiJGA==", null, false, null, "341fa197-55ac-44ea-a4db-39d39d227792", false, null, "mofidihesam8@gmail.com" },
                    { "e4651308-6b8d-4514-8bc4-c4cf3f75a925", 0, "081f2507-aad5-4749-b050-9201584b3687", "User", "mofidihessam@gmail.com", false, "HesamMofidi1", null, null, false, null, "MOFIDIHESSAM@GMAIL.COM", "MOFIDIHESSAM@GMAIL.COM", "AQAAAAIAAYagAAAAED7HtUZ2KwbWZTTQhfGTeh6cW0haM2y/bxd1/qHo6w3kP1h4CNXuMVDnx5T+td7gqg==", null, false, null, "478a1998-525f-46b5-907d-eb4d4476f87f", false, null, "mofidihessam@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "30b54ae3-5c16-4ee4-8c87-9200ea8a8901");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c02facf2-bb3e-4f0c-b503-1c904b429e22");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c02facf2-bb3e-4f0c-b503-1c904b429e22", "982bb98e-60e7-4eaa-adff-981b432b0a34" });

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "30b54ae3-5c16-4ee4-8c87-9200ea8a8901", "e4651308-6b8d-4514-8bc4-c4cf3f75a925" });

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "982bb98e-60e7-4eaa-adff-981b432b0a34");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e4651308-6b8d-4514-8bc4-c4cf3f75a925");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                schema: "identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                schema: "identity",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);
        }
    }
}
