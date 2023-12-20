using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagementDummy.Migrations
{
    public partial class ChangeTablesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRols_Roles_RoleID",
                table: "UserRols");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRols_Users_UserID",
                table: "UserRols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRols",
                table: "UserRols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UserRols",
                newName: "UserRol");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameIndex(
                name: "IX_UserRols_UserID",
                table: "UserRol",
                newName: "IX_UserRol_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRols_RoleID",
                table: "UserRol",
                newName: "IX_UserRol_RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRol",
                table: "UserRol",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "UserRol",
                newName: "UserRols");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRol_UserID",
                table: "UserRols",
                newName: "IX_UserRols_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserRol_RoleID",
                table: "UserRols",
                newName: "IX_UserRols_RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRols",
                table: "UserRols",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRols_Roles_RoleID",
                table: "UserRols",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRols_Users_UserID",
                table: "UserRols",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
