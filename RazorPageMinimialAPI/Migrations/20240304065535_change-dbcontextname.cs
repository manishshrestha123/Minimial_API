using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPageMinimialAPI.Migrations
{
    /// <inheritdoc />
    public partial class changedbcontextname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "StudentRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRecords",
                table: "StudentRecords",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRecords",
                table: "StudentRecords");

            migrationBuilder.RenameTable(
                name: "StudentRecords",
                newName: "Students");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");
        }
    }
}
