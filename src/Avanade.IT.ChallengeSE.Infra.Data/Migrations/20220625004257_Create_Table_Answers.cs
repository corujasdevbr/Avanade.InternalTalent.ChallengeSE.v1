using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avanade.IT.ChallengeSE.Infra.Data.Migrations
{
    public partial class Create_Table_Answers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Image = table.Column<string>(type: "VARCHAR(355)", nullable: true),
                    Correct = table.Column<bool>(type: "BIT", nullable: false),
                    IdQuestion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DateAltered = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_IdQuestion",
                        column: x => x.IdQuestion,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_IdQuestion",
                table: "Answers",
                column: "IdQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");
        }
    }
}
