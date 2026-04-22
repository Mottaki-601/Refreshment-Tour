using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityAndDateToCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CostDate",
                table: "Costs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Costs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostDate",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Costs");
        }
    }
}
