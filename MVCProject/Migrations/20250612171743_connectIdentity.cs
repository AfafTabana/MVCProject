using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class connectIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Librarians",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ApplicationUserId",
                table: "Users",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Librarians_ApplicationUserId",
                table: "Librarians",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Librarians_AspNetUsers_ApplicationUserId",
                table: "Librarians",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_ApplicationUserId",
                table: "Users",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Librarians_AspNetUsers_ApplicationUserId",
                table: "Librarians");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_ApplicationUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ApplicationUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Librarians_ApplicationUserId",
                table: "Librarians");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Librarians");
        }
    }
}
