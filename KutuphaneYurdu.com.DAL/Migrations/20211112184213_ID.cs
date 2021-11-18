using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneYurdu.com.DAL.Migrations
{
    public partial class ID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 11, 12, 21, 42, 11, 220, DateTimeKind.Local).AddTicks(3225));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    IPNO = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Surname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "ID",
                keyValue: 1,
                column: "LastDate",
                value: new DateTime(2021, 10, 19, 19, 23, 37, 5, DateTimeKind.Local).AddTicks(1414));
        }
    }
}
