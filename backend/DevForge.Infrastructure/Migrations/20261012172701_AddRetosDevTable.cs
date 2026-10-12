using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevForge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRetosDevTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "RetosDev",
                newName: "Titulo");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "RetosDev",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "RetosDev");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "RetosDev",
                newName: "Nombre");
        }
    }
}
