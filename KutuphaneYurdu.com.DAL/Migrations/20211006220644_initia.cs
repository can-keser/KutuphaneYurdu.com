using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneYurdu.com.DAL.Migrations
{
    public partial class initia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Blog",
                newName: "RecDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                table: "Blog",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 7, 1, 6, 43, 360, DateTimeKind.Local).AddTicks(922));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecDate",
                table: "Blog",
                newName: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 7, 1, 1, 33, 56, DateTimeKind.Local).AddTicks(3386));
        }
    }
}
