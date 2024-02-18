using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeIdadnOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "SystemPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    systemId = table.Column<int>(type: "int", nullable: false),
                    PermisionsId = table.Column<int>(type: "int", nullable: true),
                    SystemsId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemPermission_Permission_PermisionsId",
                        column: x => x.PermisionsId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemPermission_Systems_SystemsId",
                        column: x => x.SystemsId,
                        principalTable: "Systems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemPermission_Systems_systemId",
                        column: x => x.systemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    systemId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SystemsId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRoles_Systems_SystemsId",
                        column: x => x.SystemsId,
                        principalTable: "Systems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRoles_Systems_systemId",
                        column: x => x.systemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoleUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    systemId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DomainUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SystemsId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoleUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemRoleUser_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemRoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRoleUser_Systems_SystemsId",
                        column: x => x.SystemsId,
                        principalTable: "Systems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRoleUser_Systems_systemId",
                        column: x => x.systemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemRoleUser_Users_DomainUserId",
                        column: x => x.DomainUserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRoleUser_Users_usersId",
                        column: x => x.usersId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemUserPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    systemId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomainUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermisionsId = table.Column<int>(type: "int", nullable: true),
                    SystemsId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_Permission_PermisionsId",
                        column: x => x.PermisionsId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_Systems_SystemsId",
                        column: x => x.SystemsId,
                        principalTable: "Systems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_Systems_systemId",
                        column: x => x.systemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_Users_DomainUserId",
                        column: x => x.DomainUserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserPermission_Users_usersId",
                        column: x => x.usersId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemRolesPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    systemId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermisionsId = table.Column<int>(type: "int", nullable: true),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SystemPermissionId = table.Column<int>(type: "int", nullable: true),
                    SystemRolesId = table.Column<int>(type: "int", nullable: true),
                    SystemsId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRolesPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemRolesPermission_Permission_PermisionsId",
                        column: x => x.PermisionsId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRolesPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemRolesPermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemRolesPermission_Roles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRolesPermission_SystemPermission_SystemPermissionId",
                        column: x => x.SystemPermissionId,
                        principalTable: "SystemPermission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRolesPermission_SystemRoles_SystemRolesId",
                        column: x => x.SystemRolesId,
                        principalTable: "SystemRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRolesPermission_Systems_SystemsId",
                        column: x => x.SystemsId,
                        principalTable: "Systems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemRolesPermission_Systems_systemId",
                        column: x => x.systemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemUserRolePermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    systemId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomainUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PermisionsId = table.Column<int>(type: "int", nullable: true),
                    RolesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SystemRolesId = table.Column<int>(type: "int", nullable: true),
                    SystemsId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUserRolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_Permission_PermisionsId",
                        column: x => x.PermisionsId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_Roles_RolesId",
                        column: x => x.RolesId,
                        principalSchema: "identity",
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_SystemRoles_SystemRolesId",
                        column: x => x.SystemRolesId,
                        principalTable: "SystemRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_Systems_SystemsId",
                        column: x => x.SystemsId,
                        principalTable: "Systems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_Systems_systemId",
                        column: x => x.systemId,
                        principalTable: "Systems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_Users_DomainUserId",
                        column: x => x.DomainUserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SystemUserRolePermission_Users_usersId",
                        column: x => x.usersId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_Title",
                table: "Permission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemPermission_PermisionsId",
                table: "SystemPermission",
                column: "PermisionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemPermission_PermissionId_systemId",
                table: "SystemPermission",
                columns: new[] { "PermissionId", "systemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemPermission_systemId",
                table: "SystemPermission",
                column: "systemId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemPermission_SystemsId",
                table: "SystemPermission",
                column: "SystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemPermission_Title",
                table: "SystemPermission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_RoleId_systemId",
                table: "SystemRoles",
                columns: new[] { "RoleId", "systemId" },
                unique: true,
                filter: "[RoleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_RolesId",
                table: "SystemRoles",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_systemId",
                table: "SystemRoles",
                column: "systemId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_SystemsId",
                table: "SystemRoles",
                column: "SystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_Title",
                table: "SystemRoles",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_PermisionsId",
                table: "SystemRolesPermission",
                column: "PermisionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_PermissionId_systemId_RoleId",
                table: "SystemRolesPermission",
                columns: new[] { "PermissionId", "systemId", "RoleId" },
                unique: true,
                filter: "[RoleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_RoleId",
                table: "SystemRolesPermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_RolesId",
                table: "SystemRolesPermission",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_systemId",
                table: "SystemRolesPermission",
                column: "systemId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_SystemPermissionId",
                table: "SystemRolesPermission",
                column: "SystemPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_SystemRolesId",
                table: "SystemRolesPermission",
                column: "SystemRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_SystemsId",
                table: "SystemRolesPermission",
                column: "SystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRolesPermission_Title",
                table: "SystemRolesPermission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_DomainUserId",
                table: "SystemRoleUser",
                column: "DomainUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_RoleId",
                table: "SystemRoleUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_RolesId",
                table: "SystemRoleUser",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_systemId_RoleId_usersId",
                table: "SystemRoleUser",
                columns: new[] { "systemId", "RoleId", "usersId" },
                unique: true,
                filter: "[RoleId] IS NOT NULL AND [usersId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_SystemsId",
                table: "SystemRoleUser",
                column: "SystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_Title",
                table: "SystemRoleUser",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoleUser_usersId",
                table: "SystemRoleUser",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_Systems_Title",
                table: "Systems",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_DomainUserId",
                table: "SystemUserPermission",
                column: "DomainUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_PermisionsId",
                table: "SystemUserPermission",
                column: "PermisionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_PermissionId_systemId_usersId",
                table: "SystemUserPermission",
                columns: new[] { "PermissionId", "systemId", "usersId" },
                unique: true,
                filter: "[usersId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_systemId",
                table: "SystemUserPermission",
                column: "systemId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_SystemsId",
                table: "SystemUserPermission",
                column: "SystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_Title",
                table: "SystemUserPermission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserPermission_usersId",
                table: "SystemUserPermission",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_DomainUserId",
                table: "SystemUserRolePermission",
                column: "DomainUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_PermisionsId",
                table: "SystemUserRolePermission",
                column: "PermisionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_PermissionId_systemId_RoleId_usersId",
                table: "SystemUserRolePermission",
                columns: new[] { "PermissionId", "systemId", "RoleId", "usersId" },
                unique: true,
                filter: "[RoleId] IS NOT NULL AND [usersId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_RoleId",
                table: "SystemUserRolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_RolesId",
                table: "SystemUserRolePermission",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_systemId",
                table: "SystemUserRolePermission",
                column: "systemId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_SystemRolesId",
                table: "SystemUserRolePermission",
                column: "SystemRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_SystemsId",
                table: "SystemUserRolePermission",
                column: "SystemsId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_Title",
                table: "SystemUserRolePermission",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUserRolePermission_usersId",
                table: "SystemUserRolePermission",
                column: "usersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "SystemRolesPermission");

            migrationBuilder.DropTable(
                name: "SystemRoleUser");

            migrationBuilder.DropTable(
                name: "SystemUserPermission");

            migrationBuilder.DropTable(
                name: "SystemUserRolePermission");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "SystemPermission");

            migrationBuilder.DropTable(
                name: "SystemRoles");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Systems");
        }
    }
}
