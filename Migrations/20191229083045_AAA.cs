using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Enjaz_StackOverFlow.Migrations
{
    public partial class AAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    User_Id = table.Column<int>(nullable: false),
                    Question_Id = table.Column<int>(nullable: false),
                    Comment_Date = table.Column<DateTime>(nullable: false),
                    Evaluation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question_Histories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qustion_Id = table.Column<int>(nullable: false),
                    Before_Edit = table.Column<string>(nullable: true),
                    After_Edit = table.Column<string>(nullable: true),
                    Edit_DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question_Histories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    User_Id = table.Column<int>(nullable: false),
                    Question_Date = table.Column<DateTime>(nullable: false),
                    Tag_UserName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    User_Id = table.Column<int>(nullable: false),
                    Comment_Id = table.Column<int>(nullable: false),
                    Question_Date = table.Column<DateTime>(nullable: false),
                    Evaluation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Name = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(nullable: true),
                    Person_Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Profile_Picture = table.Column<byte[]>(nullable: true),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Point = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Question_Histories");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
