using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "table_authors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    full_name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "table_books",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_books", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "table_books_authors",
                columns: table => new
                {
                    book_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    author_id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_table_books_authors", x => new { x.book_id, x.author_id });
                    table.ForeignKey(
                        name: "fk_table_book_author_author_id",
                        column: x => x.author_id,
                        principalTable: "table_authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "fk_table_book_author_book_id",
                        column: x => x.book_id,
                        principalTable: "table_books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "ux_table_authors_full_name",
                table: "table_authors",
                column: "full_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_table_books_title",
                table: "table_books",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_table_books_authors_author_id",
                table: "table_books_authors",
                column: "author_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "table_books_authors");

            migrationBuilder.DropTable(
                name: "table_authors");

            migrationBuilder.DropTable(
                name: "table_books");
        }
    }
}
