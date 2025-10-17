using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadanieApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddWykonawcaAndCzasFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SzacowanyCzas",
                table: "zadania",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Wykonawca",
                table: "zadania",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SzacowanyCzas",
                table: "zadania");

            migrationBuilder.DropColumn(
                name: "Wykonawca",
                table: "zadania");
        }
    }
}
