using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avanade.IT.ChallengeSE.Infra.Data.Migrations
{
    public partial class Initial_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Image = table.Column<string>(type: "VARCHAR(355)", nullable: true),
                    Points = table.Column<int>(type: "INT", nullable: false),
                    Weight = table.Column<int>(type: "INT", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DateAltered = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
