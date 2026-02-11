using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapStoneProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddScanLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScanLogs",
                columns: table => new
                {
                    LogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TargetIPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScanTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpenPortsDetected = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScanDurationMs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScanLogs", x => x.LogID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScanLogs");
        }
    }
}
