using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperheroesApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSuperheroesFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AlterEgo",
                table: "Superheroes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Catchphrase",
                table: "Superheroes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Superheroes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAbility",
                table: "Superheroes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryAbility",
                table: "Superheroes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlterEgo",
                table: "Superheroes");

            migrationBuilder.DropColumn(
                name: "Catchphrase",
                table: "Superheroes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Superheroes");

            migrationBuilder.DropColumn(
                name: "PrimaryAbility",
                table: "Superheroes");

            migrationBuilder.DropColumn(
                name: "SecondaryAbility",
                table: "Superheroes");
        }
    }
}
