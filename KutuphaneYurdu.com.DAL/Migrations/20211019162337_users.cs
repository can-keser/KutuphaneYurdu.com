using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneYurdu.com.DAL.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserIPNO",
                table: "User",
                newName: "IPNO");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 19, 19, 23, 37, 5, DateTimeKind.Local).AddTicks(1414));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "IPNO",
                table: "User",
                newName: "UserIPNO");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 15, 0, 41, 57, 580, DateTimeKind.Local).AddTicks(3914));
        }
    }
}
