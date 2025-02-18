using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Assignment_Carter_Fitzgerald.Data.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "GenAIs",
                newName: "ImageFileName");

            migrationBuilder.AddColumn<string>(
                name: "AnchorLink",
                table: "GenAIs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnchorLink",
                table: "GenAIs");

            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "GenAIs",
                newName: "ImagePath");
        }
    }
}
