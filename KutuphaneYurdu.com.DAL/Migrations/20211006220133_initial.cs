using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneYurdu.com.DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Surname = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastIPNO = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    BlogDetails = table.Column<string>(type: "Text", nullable: true),
                    Picture = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Writer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Link = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "ID", "LastDate", "LastIPNO", "Name", "Password", "Surname", "UserName" },
                values: new object[] { 1, new DateTime(2021, 10, 7, 1, 1, 33, 56, DateTimeKind.Local).AddTicks(3386), "", "Can", "202cb962ac59075b964b07152d234b70", "Keser", "can" });

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryID",
                table: "Book",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Writer");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
