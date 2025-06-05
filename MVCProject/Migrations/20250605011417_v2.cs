using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Librarians_librarian_ID",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_librarian_ID",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "librarian_ID",
                table: "Borrows");

            migrationBuilder.RenameColumn(
                name: "Copies_Number",
                table: "Books",
                newName: "Buy_quantity");

            migrationBuilder.AddColumn<int>(
                name: "LibrariansId",
                table: "Borrows",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher_Name",
                table: "Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Author_Name",
                table: "Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Borrow_quantity",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_LibrariansId",
                table: "Borrows",
                column: "LibrariansId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Librarians_LibrariansId",
                table: "Borrows",
                column: "LibrariansId",
                principalTable: "Librarians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Librarians_LibrariansId",
                table: "Borrows");

            migrationBuilder.DropIndex(
                name: "IX_Borrows_LibrariansId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "LibrariansId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "Borrow_quantity",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Buy_quantity",
                table: "Books",
                newName: "Copies_Number");

            migrationBuilder.AddColumn<int>(
                name: "librarian_ID",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher_Name",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Author_Name",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Borrows_librarian_ID",
                table: "Borrows",
                column: "librarian_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Librarians_librarian_ID",
                table: "Borrows",
                column: "librarian_ID",
                principalTable: "Librarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
