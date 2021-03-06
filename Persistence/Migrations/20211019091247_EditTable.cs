using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EditTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys");

            migrationBuilder.RenameTable(
                name: "Activitys",
                newName: "Activities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activities",
                table: "Activities",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activities",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "Activities",
                newName: "Activitys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activitys",
                table: "Activitys",
                column: "Id");
        }
    }
}
