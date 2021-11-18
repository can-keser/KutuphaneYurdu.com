using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneYurdu.com.DAL.Migrations
{
    public partial class User1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastIPNO",
                table: "User",
                newName: "UserIPNO");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 15, 0, 41, 57, 580, DateTimeKind.Local).AddTicks(3914));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserIPNO",
                table: "User",
                newName: "LastIPNO");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 14, 23, 13, 45, 2, DateTimeKind.Local).AddTicks(9554));
        }
    }
}
