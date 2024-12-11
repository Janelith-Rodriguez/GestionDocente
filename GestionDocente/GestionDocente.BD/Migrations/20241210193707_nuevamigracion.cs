using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDocente.BD.Migrations
{
    /// <inheritdoc />
    public partial class nuevamigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasesAsistencias_CursadoMaterias_CursadoMateriaId",
                table: "ClasesAsistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_CursadoMaterias_Alumnos_AlumnoId",
                table: "CursadoMaterias");

            migrationBuilder.DropForeignKey(
                name: "FK_CursadoMaterias_Turnos_TurnoId",
                table: "CursadoMaterias");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_CursadoMaterias_CursadoMateriaId",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursadoMaterias",
                table: "CursadoMaterias");

            migrationBuilder.RenameTable(
                name: "CursadoMaterias",
                newName: "CursadosMateria");

            migrationBuilder.RenameIndex(
                name: "IX_CursadoMaterias_TurnoId",
                table: "CursadosMateria",
                newName: "IX_CursadosMateria_TurnoId");

            migrationBuilder.RenameIndex(
                name: "IX_CursadoMaterias_AlumnoId",
                table: "CursadosMateria",
                newName: "IX_CursadosMateria_AlumnoId");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Turnos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "TipoDocumentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Profesores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "PlanEstudios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Notas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "MateriasEnPlanEstudio",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Materias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "MAB",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "InscripcionCarreras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Evaluaciones",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "CUPOF_Profesores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "CUPOF_Coordinadores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Correlatividades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Coordinadores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "ClasesAsistencias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Clases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "CertificadosAlumnos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Carreras",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Alumnos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "CursadosMateria",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursadosMateria",
                table: "CursadosMateria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasesAsistencias_CursadosMateria_CursadoMateriaId",
                table: "ClasesAsistencias",
                column: "CursadoMateriaId",
                principalTable: "CursadosMateria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CursadosMateria_Alumnos_AlumnoId",
                table: "CursadosMateria",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CursadosMateria_Turnos_TurnoId",
                table: "CursadosMateria",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_CursadosMateria_CursadoMateriaId",
                table: "Notas",
                column: "CursadoMateriaId",
                principalTable: "CursadosMateria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasesAsistencias_CursadosMateria_CursadoMateriaId",
                table: "ClasesAsistencias");

            migrationBuilder.DropForeignKey(
                name: "FK_CursadosMateria_Alumnos_AlumnoId",
                table: "CursadosMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_CursadosMateria_Turnos_TurnoId",
                table: "CursadosMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_CursadosMateria_CursadoMateriaId",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursadosMateria",
                table: "CursadosMateria");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "TipoDocumentos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Profesores");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "PlanEstudios");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "MateriasEnPlanEstudio");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Materias");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "MAB");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "InscripcionCarreras");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Evaluaciones");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "CUPOF_Profesores");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "CUPOF_Coordinadores");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Correlatividades");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Coordinadores");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "ClasesAsistencias");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Clases");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "CertificadosAlumnos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Carreras");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "CursadosMateria");

            migrationBuilder.RenameTable(
                name: "CursadosMateria",
                newName: "CursadoMaterias");

            migrationBuilder.RenameIndex(
                name: "IX_CursadosMateria_TurnoId",
                table: "CursadoMaterias",
                newName: "IX_CursadoMaterias_TurnoId");

            migrationBuilder.RenameIndex(
                name: "IX_CursadosMateria_AlumnoId",
                table: "CursadoMaterias",
                newName: "IX_CursadoMaterias_AlumnoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursadoMaterias",
                table: "CursadoMaterias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasesAsistencias_CursadoMaterias_CursadoMateriaId",
                table: "ClasesAsistencias",
                column: "CursadoMateriaId",
                principalTable: "CursadoMaterias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CursadoMaterias_Alumnos_AlumnoId",
                table: "CursadoMaterias",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CursadoMaterias_Turnos_TurnoId",
                table: "CursadoMaterias",
                column: "TurnoId",
                principalTable: "Turnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_CursadoMaterias_CursadoMateriaId",
                table: "Notas",
                column: "CursadoMateriaId",
                principalTable: "CursadoMaterias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
