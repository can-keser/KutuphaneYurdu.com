using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneYurdu.com.DAL.Migrations
{
    public partial class ID2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 11, 12, 21, 52, 28, 804, DateTimeKind.Local).AddTicks(2881));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 11, 12, 21, 42, 11, 220, DateTimeKind.Local).AddTicks(3225));
        }
    }
}
