using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avanade.IT.ChallengeSE.Infra.Data.Migrations
{
    public partial class Alter_Table_Question_Add_Level : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Questions",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Questions",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }
    }
}
