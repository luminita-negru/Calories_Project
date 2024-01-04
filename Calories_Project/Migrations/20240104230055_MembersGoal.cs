using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calories_Project.Migrations
{
    public partial class MembersGoal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaloriesGoal",
                table: "Member",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaloriesGoal",
                table: "Member");
        }
    }
}
