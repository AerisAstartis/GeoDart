using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoDart.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrillingData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaterPressurte = table.Column<float>(type: "real", nullable: false),
                    WaterConsumption = table.Column<float>(type: "real", nullable: false),
                    FeedIn = table.Column<float>(type: "real", nullable: false),
                    FeedOut = table.Column<float>(type: "real", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillingData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contractor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Well = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cluster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drilling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterPressurte = table.Column<float>(type: "real", nullable: false),
                    WaterConsumption = table.Column<float>(type: "real", nullable: false),
                    FeedIn = table.Column<float>(type: "real", nullable: false),
                    FeedOut = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrillingData");

            migrationBuilder.DropTable(
                name: "Machine");
        }
    }
}
