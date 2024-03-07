using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KidsFun.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddKidSchoolYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SchoolYear",
                table: "Kids",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "Kids");
        }
    }
}
