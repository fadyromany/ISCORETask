using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISCORETask.DAL.Migrations
{
    public partial class AddBooksschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookManagement.Books",
                table: "BookManagement.Books");

            migrationBuilder.EnsureSchema(
                name: "BookManagement");

            migrationBuilder.RenameTable(
                name: "BookManagement.Books",
                newName: "Books",
                newSchema: "BookManagement");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "BookManagement",
                table: "Books",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "BookManagement",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "BookManagement",
                newName: "BookManagement.Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookManagement.Books",
                table: "BookManagement.Books",
                column: "Id");
        }
    }
}
