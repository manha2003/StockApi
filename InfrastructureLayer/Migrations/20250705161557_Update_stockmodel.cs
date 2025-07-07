using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfrastructureLayer.Migrations
{
    /// <inheritdoc />
    public partial class Update_stockmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Stocks",
                newName: "LastPriceUpdatedAt");

            migrationBuilder.AddColumn<decimal>(
                name: "LastestPrice",
                table: "Stocks",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastestPrice",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "LastPriceUpdatedAt",
                table: "Stocks",
                newName: "LastUpdated");
        }
    }
}
