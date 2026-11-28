using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwitterClone.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTweetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tweets",
                table: "Tweets");

            migrationBuilder.RenameTable(
                name: "Tweets",
                newName: "tweets");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "tweets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tweets",
                table: "tweets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tweets_UserId",
                table: "tweets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tweets_Users_UserId",
                table: "tweets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tweets_Users_UserId",
                table: "tweets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tweets",
                table: "tweets");

            migrationBuilder.DropIndex(
                name: "IX_tweets_UserId",
                table: "tweets");

            migrationBuilder.RenameTable(
                name: "tweets",
                newName: "Tweets");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Tweets",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tweets",
                table: "Tweets",
                column: "Id");
        }
    }
}
