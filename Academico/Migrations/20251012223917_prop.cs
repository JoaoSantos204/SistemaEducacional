using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academico.Migrations
{
    /// <inheritdoc />
    public partial class prop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departamentos",
                newName: "DepartamentoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartamentoID",
                table: "Departamentos",
                newName: "Id");
        }
    }
}
