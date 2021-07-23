using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace yad2.Migrations
{
    public partial class addPostController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PicUrls = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_User_PublisherUsername",
                        column: x => x.PublisherUsername,
                        principalTable: "User",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    PostID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PostID",
                table: "Tags",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PublisherUsername",
                table: "Posts",
                column: "PublisherUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PostID",
                table: "Products",
                column: "PostID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostID",
                table: "Tags",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostID",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Tags_PostID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Tags");
        }
    }
}
