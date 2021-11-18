using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneYurdu.com.DAL.Migrations
{
    public partial class writer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 12, 16, 43, 59, 662, DateTimeKind.Local).AddTicks(198));

            migrationBuilder.CreateIndex(
                name: "IX_Book_WriterID",
                table: "Book",
                column: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Writer_WriterID",
                table: "Book",
                column: "WriterID",
                principalTable: "Writer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Writer_WriterID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_WriterID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "Book");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 7, 1, 6, 43, 360, DateTimeKind.Local).AddTicks(922));
        }
    }
}
