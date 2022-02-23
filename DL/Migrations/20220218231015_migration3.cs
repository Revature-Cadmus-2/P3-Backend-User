using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowedBy_Users_UserId",
                table: "FollowedBy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowedBy",
                table: "FollowedBy");

            migrationBuilder.RenameTable(
                name: "FollowedBy",
                newName: "Followers");

            migrationBuilder.RenameIndex(
                name: "IX_FollowedBy_UserId",
                table: "Followers",
                newName: "IX_Followers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_UserId",
                table: "Followers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_UserId",
                table: "Followers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "FollowedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_UserId",
                table: "FollowedBy",
                newName: "IX_FollowedBy_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowedBy",
                table: "FollowedBy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowedBy_Users_UserId",
                table: "FollowedBy",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
