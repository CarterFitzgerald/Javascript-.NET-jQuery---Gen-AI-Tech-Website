using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Assignment_Carter_Fitzgerald.Data.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgFileName",
                table: "GenAIs");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "GenAIs",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "GenAIs");

            migrationBuilder.AddColumn<string>(
                name: "ImgFileName",
                table: "GenAIs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
