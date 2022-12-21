using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutor.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adddCurrecyAndModes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Levels",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "Modes",
                table: "Advertisements",
                type: "smallint",
                nullable: false,
                defaultValue: (short)1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "Modes",
                table: "Advertisements");

            migrationBuilder.AlterColumn<int>(
                name: "Levels",
                table: "Advertisements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }
    }
}
