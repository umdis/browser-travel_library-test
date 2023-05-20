using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrowserTravel.Library.Infraestructure.Migrations
{
    public partial class insert_seed_authors_books : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.DropIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                columns: new[] { "BooksId", "AuthorsId" });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Salt", "SaltedAndHashedPassword" },
                values: new object[] { new DateTime(2023, 5, 19, 20, 25, 12, 567, DateTimeKind.Local).AddTicks(4473), new byte[] { 46, 231, 97, 52, 77, 29, 170, 96, 140, 61, 124, 108, 11, 29, 76, 191 }, "LudhNE0dqmCMPXxsCx1Mv4sc5FtR5iQroQykDwoQEx9WRgq2" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_AuthorsId",
                table: "AuthorBook",
                column: "AuthorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook");

            migrationBuilder.DropIndex(
                name: "IX_AuthorBook_AuthorsId",
                table: "AuthorBook");

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsId", "BooksId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBook",
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Salt", "SaltedAndHashedPassword" },
                values: new object[] { new DateTime(2023, 5, 19, 20, 15, 18, 717, DateTimeKind.Local).AddTicks(6196), new byte[] { 244, 199, 209, 163, 11, 7, 37, 53, 71, 173, 81, 193, 74, 240, 63, 85 }, "9MfRowsHJTVHrVHBSvA/VafvSZcEi2mEgxgphaLd1Qd9+r8Q" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");
        }
    }
}
