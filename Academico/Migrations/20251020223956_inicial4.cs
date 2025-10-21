using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academico.Migrations
{
    /// <inheritdoc />
    public partial class inicial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoID",
                table: "Disciplina",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_CursoID",
                table: "Disciplina",
                column: "CursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Curso_CursoID",
                table: "Disciplina",
                column: "CursoID",
                principalTable: "Curso",
                principalColumn: "CursoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Curso_CursoID",
                table: "Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_CursoID",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "CursoID",
                table: "Disciplina");
        }
    }
}
