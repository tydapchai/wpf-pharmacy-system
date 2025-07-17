using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9655), new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9649) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9808), "images/paracetamol.png", new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9808) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9812), "images/ibuprofen.png", new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9813) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9816), "images/vitaminc.png", new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9816) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ImageUrl", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9819), "images/omeprazole.png", new DateTime(2025, 7, 13, 22, 18, 47, 934, DateTimeKind.Local).AddTicks(9819) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6144), new DateTime(2025, 7, 13, 16, 44, 36, 228, DateTimeKind.Local).AddTicks(6137) });

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
    }
}
