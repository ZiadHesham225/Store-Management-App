using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce_V1.Migrations
{
    /// <inheritdoc />
    public partial class OD_Total_Price_Calculated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderDetails",
                newName: "TotalPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "OrderDetails",
                newName: "Price");
        }
    }
}
