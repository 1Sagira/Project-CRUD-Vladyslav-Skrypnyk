using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadanieApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "zadania",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tytul = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Priorytet = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 3),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zadania", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "zadania");
        }
    }
}
