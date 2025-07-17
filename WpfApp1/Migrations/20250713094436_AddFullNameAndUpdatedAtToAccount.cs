using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddFullNameAndUpdatedAtToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddedAt",
                table: "CartItems",
                newName: "UpdatedAt");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CartItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "FullName", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6144), "", new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6137) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6303), new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6303) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6308), new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6308) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6311), new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6311) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6314), new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6314) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "CartItems",
                newName: "AddedAt");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(4123), new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(4127), new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(4131), new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(4133), new DateTime(2025, 7, 13, 15, 37, 12, 182, DateTimeKind.Local).AddTicks(4134) });
        }
    }
}
