using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimesheetsManagementProject.Migrations.Data
{
    /// <inheritdoc />
    public partial class datatimesheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Designations_DesignationsDesignationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoles_UserRolesRolesUserRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DesignationsDesignationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRolesRolesUserRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DesignationsDesignationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRolesRolesUserRoleId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Mobile",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "DesignationId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DesignationsDesignationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRolesRolesUserRoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_DesignationsDesignationId",
                table: "Users",
                column: "DesignationsDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRolesRolesUserRoleId",
                table: "Users",
                column: "UserRolesRolesUserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Designations_DesignationsDesignationId",
                table: "Users",
                column: "DesignationsDesignationId",
                principalTable: "Designations",
                principalColumn: "DesignationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRoles_UserRolesRolesUserRoleId",
                table: "Users",
                column: "UserRolesRolesUserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
