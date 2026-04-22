using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour.Migrations
{
    /// <inheritdoc />
    public partial class AddEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Members",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Costs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Members_EventId",
                table: "Members",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_EventId",
                table: "Costs",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Events_EventId",
                table: "Costs",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Events_EventId",
                table: "Members",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Events_EventId",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Events_EventId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Members_EventId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Costs_EventId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Costs");
        }
    }
}
