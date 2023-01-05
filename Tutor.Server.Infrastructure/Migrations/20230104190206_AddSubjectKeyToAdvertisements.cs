using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tutor.Server.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectKeyToAdvertisements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Advertisements");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Advertisements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_SubjectId",
                table: "Advertisements",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_SchoolSubjects_SubjectId",
                table: "Advertisements",
                column: "SubjectId",
                principalTable: "SchoolSubjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_SchoolSubjects_SubjectId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_SubjectId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Advertisements");

            migrationBuilder.AddColumn<int>(
                name: "Subject",
                table: "Advertisements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
