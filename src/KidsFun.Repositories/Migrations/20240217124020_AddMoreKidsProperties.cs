using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidsFun.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreKidsProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Kids");

            migrationBuilder.RenameColumn(
                name: "points",
                table: "Kids",
                newName: "Points");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Kids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Kids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Kids",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Kids");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Kids");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Kids",
                newName: "points");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Kids",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
