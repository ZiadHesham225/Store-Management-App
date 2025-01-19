using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce_V1.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "Customers",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Customers",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "Customers",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "Customers",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Customers",
                newName: "City");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "City", "Country", "State", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice", "Smith", "Springfield", "US", "IL", "123 Elm St", "62701" },
                    { 2, "bob@example.com", "Bob", "Johnson", "Madison", "US", "WI", "456 Oak St", "53703" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone", 500m, 20 },
                    { 2, 2, "T-shirt", 15m, 50 },
                    { 3, 3, "Novel", 10m, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Customers",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Customers",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Customers",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Customers",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customers",
                newName: "Address_City");

            migrationBuilder.AlterColumn<string>(
                name: "Address_Country",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
