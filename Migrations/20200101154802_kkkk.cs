using Microsoft.EntityFrameworkCore.Migrations;

namespace Enjaz_StackOverFlow.Migrations
{
    public partial class kkkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_Histories_Qustion_Id",
                table: "Question_Histories",
                column: "Qustion_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Histories_Questions_Qustion_Id",
                table: "Question_Histories",
                column: "Qustion_Id",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Histories_Questions_Qustion_Id",
                table: "Question_Histories");

            migrationBuilder.DropIndex(
                name: "IX_Question_Histories_Qustion_Id",
                table: "Question_Histories");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
