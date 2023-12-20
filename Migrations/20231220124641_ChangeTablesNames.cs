using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementDummy.Migrations
{
    public partial class ChangeTablesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRol_Role_RoleID",
                table: "UserRol");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRol_User_UserID",
                table: "UserRol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRol",
                table: "UserRol");

            migrationBuilder.RenameTable(
                name: "UserRol",
                newName: "UserRole");

            migrationBuilder.RenameIndex(
                name: "IX_UserRol_UserID",
                table: "UserRole",
                newName: "IX_UserRole_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRol_RoleID",
                table: "UserRole",
                newName: "IX_UserRole_RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Role_RoleID",
                table: "UserRole",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserID",
                table: "UserRole",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Role_RoleID",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserID",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRol");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_UserID",
                table: "UserRol",
                newName: "IX_UserRol_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_RoleID",
                table: "UserRol",
                newName: "IX_UserRol_RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRol",
                table: "UserRol",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRol_Role_RoleID",
                table: "UserRol",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRol_User_UserID",
                table: "UserRol",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
