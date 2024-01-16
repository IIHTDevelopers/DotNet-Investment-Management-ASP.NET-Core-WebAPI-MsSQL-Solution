using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestmentManagement.DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    InvestmentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvestmentName = table.Column<string>(nullable: true),
                    InitialInvestmentAmount = table.Column<decimal>(nullable: false),
                    InvestmentStartDate = table.Column<DateTime>(nullable: false),
                    CurrentValue = table.Column<decimal>(nullable: false),
                    InvestorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.InvestmentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investments");
        }
    }
}
