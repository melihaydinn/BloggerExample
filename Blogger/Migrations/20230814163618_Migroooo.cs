using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogger.Migrations
{
    public partial class Migroooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Images = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Banners = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Images = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Passwords = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BlogComments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Commenter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Blogsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComments", x => x.id);
                    table.ForeignKey(
                        name: "FK_BlogComments_Blogs_Blogsid",
                        column: x => x.Blogsid,
                        principalTable: "Blogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeDisLike",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    ipAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Blogsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeDisLike", x => x.id);
                    table.ForeignKey(
                        name: "FK_LikeDisLike_Blogs_Blogsid",
                        column: x => x.Blogsid,
                        principalTable: "Blogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_Blogsid",
                table: "BlogComments",
                column: "Blogsid");

            migrationBuilder.CreateIndex(
                name: "IX_LikeDisLike_Blogsid",
                table: "LikeDisLike",
                column: "Blogsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogComments");

            migrationBuilder.DropTable(
                name: "LikeDisLike");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
