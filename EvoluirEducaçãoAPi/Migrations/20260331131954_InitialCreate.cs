using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoluirEducação.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Curso__085F27D6A0F95B16", x => x.IdCurso);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    IdTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Turno = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Turma__C1ECFFC92F1ACE2F", x => x.IdTurma);
                    table.ForeignKey(
                        name: "FK__Turma__IdCurso__60A75C0F",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso");
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    IdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Nome = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Matricula = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Foto = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    Contato = table.Column<int>(type: "int", nullable: false),
                    IdTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Aluno__8092FCB3E2381E55", x => x.IdAluno);
                    table.ForeignKey(
                        name: "FK__Aluno__IdTurma__6477ECF3",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_IdTurma",
                table: "Aluno",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdCurso",
                table: "Turma",
                column: "IdCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
