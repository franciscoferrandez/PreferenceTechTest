using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC.Migrations
{
    public partial class IssueasigneeIssueDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Asignee",
                table: "Issue",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Issue",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asignee",
                table: "Issue");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Issue");
        }
    }
}
