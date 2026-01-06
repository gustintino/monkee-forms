using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace monkee_forms_v2.Migrations
{
    /// <inheritdoc />
    public partial class TypoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvgAccLast10Runs",
                table: "Users",
                newName: "AvgAcc_Last10Runs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvgAcc_Last10Runs",
                table: "Users",
                newName: "AvgAccLast10Runs");
        }
    }
}
