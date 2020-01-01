using Microsoft.EntityFrameworkCore.Migrations;

namespace Enjaz_StackOverFlow.Migrations
{
    public partial class ddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Question_Id",
                table: "Replies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question_Id",
                table: "Replies");
        }
    }
}
