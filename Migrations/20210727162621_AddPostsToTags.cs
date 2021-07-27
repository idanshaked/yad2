using Microsoft.EntityFrameworkCore.Migrations;

namespace yad2.Migrations
{
    public partial class AddPostsToTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostID",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_PostID",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "PostID",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostsPostID = table.Column<int>(type: "int", nullable: false),
                    TagstagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostsPostID, x.TagstagId });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostsPostID",
                        column: x => x.PostsPostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagstagId",
                        column: x => x.TagstagId,
                        principalTable: "Tags",
                        principalColumn: "tagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagstagId",
                table: "PostTags",
                column: "TagstagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.AddColumn<int>(
                name: "PostID",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_PostID",
                table: "Tags",
                column: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostID",
                table: "Tags",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
