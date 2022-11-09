using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Villas",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Villas",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "VillaNumbers",
                newName: "UpdatedDate");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 9, 3, 24, 16, 950, DateTimeKind.Local).AddTicks(5950));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 9, 3, 24, 16, 950, DateTimeKind.Local).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 9, 3, 24, 16, 950, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 9, 3, 24, 16, 950, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 11, 9, 3, 24, 16, 950, DateTimeKind.Local).AddTicks(5972));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Villas",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Villas",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "VillaNumbers",
                newName: "UpdateDate");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 9, 3, 0, 54, 297, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 9, 3, 0, 54, 297, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 9, 3, 0, 54, 297, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 9, 3, 0, 54, 297, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 9, 3, 0, 54, 297, DateTimeKind.Local).AddTicks(7724));
        }
    }
}
