using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OficinaMeurer.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Inclui_Cor_Veiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "CLIENTE",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "CLIENTE");
        }
    }
}
