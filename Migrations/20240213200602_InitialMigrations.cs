using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeOffice.Calendar.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeOfficeInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Holiday = table.Column<int>(type: "INTEGER", nullable: true),
                    SickDay = table.Column<int>(type: "INTEGER", nullable: true),
                    PublicHoliday = table.Column<int>(type: "INTEGER", nullable: true),
                    HomeOfficePercent = table.Column<int>(type: "INTEGER", nullable: true),
                    Workday = table.Column<int>(type: "INTEGER", nullable: true),
                    DayInHomeOffice = table.Column<int>(type: "INTEGER", nullable: true),
                    DayInOffice = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeOfficeInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeOfficeInfos");
        }
    }
}
