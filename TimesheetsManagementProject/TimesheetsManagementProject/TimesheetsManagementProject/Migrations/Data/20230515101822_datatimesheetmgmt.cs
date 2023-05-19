using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimesheetsManagementProject.Migrations.Data
{
    /// <inheritdoc />
    public partial class datatimesheetmgmt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingMethod",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BillingMethodId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "BillingMethodId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "BillingMethod",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
