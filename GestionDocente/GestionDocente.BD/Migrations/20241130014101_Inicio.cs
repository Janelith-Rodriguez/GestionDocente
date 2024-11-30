using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDocente.BD.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DuracionCarrera = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Modalidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Formato = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Formacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ResolucionMinisterial = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Anno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanEstudios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Anno = table.Column<int>(type: "int", nullable: false),
                    EstadoPlan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanEstudios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanEstudios_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_TipoDocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MateriasEnPlanEstudio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    PlanEstudioId = table.Column<int>(type: "int", nullable: false),
                    HrsRelojAnuales = table.Column<int>(type: "int", maxLength: 60, nullable: false),
                    HrsCatedraSemanales = table.Column<int>(type: "int", maxLength: 60, nullable: false),
                    Anual_Cuatrimestral = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Anno = table.Column<int>(type: "int", nullable: false),
                    NumeroOrden = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriasEnPlanEstudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MateriasEnPlanEstudio_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MateriasEnPlanEstudio_PlanEstudios_PlanEstudioId",
                        column: x => x.PlanEstudioId,
                        principalTable: "PlanEstudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Correlatividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MateriaEnPlanEstudioId = table.Column<int>(type: "int", nullable: false),
                    MateriaCorrelativaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correlatividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Correlatividades_MateriasEnPlanEstudio_MateriaCorrelativaId",
                        column: x => x.MateriaCorrelativaId,
                        principalTable: "MateriasEnPlanEstudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Correlatividades_MateriasEnPlanEstudio_MateriaEnPlanEstudioId",
                        column: x => x.MateriaEnPlanEstudioId,
                        principalTable: "MateriasEnPlanEstudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edad = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CUIL = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TituloBase = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FotocopiaDNI = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    ConstanciaCUIL = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PartidaNacimiento = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Analitico = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FotoCarnet = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CUS = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coordinadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinadores_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coordinadores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CertificadosAlumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DuracionCarrera = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Modalidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificadosAlumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificadosAlumnos_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CUPOF_Coordinadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    CoordinadorId = table.Column<int>(type: "int", nullable: true),
                    CUPOF = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Ocupado_Libre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Sede = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUPOF_Coordinadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUPOF_Coordinadores_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CUPOF_Coordinadores_Coordinadores_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "Coordinadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: true),
                    Sede = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AnnoCicloLectivo = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    MateriaEnPlanEstudioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turnos_MateriasEnPlanEstudio_MateriaEnPlanEstudioId",
                        column: x => x.MateriaEnPlanEstudioId,
                        principalTable: "MateriasEnPlanEstudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turnos_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InscripcionCarreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    Cohorte = table.Column<int>(type: "int", nullable: false),
                    Legajo = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    EstadoAlumno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LibroMatriz = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NroOrdenAlumno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CertificadoAlumnoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InscripcionCarreras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InscripcionCarreras_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscripcionCarreras_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InscripcionCarreras_CertificadosAlumnos_CertificadoAlumnoId",
                        column: x => x.CertificadoAlumnoId,
                        principalTable: "CertificadosAlumnos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurnoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clases_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CUPOF_Profesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurnoId = table.Column<int>(type: "int", nullable: false),
                    CUPOF = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Ocupado_Libre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUPOF_Profesores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CUPOF_Profesores_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CursadoMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoId = table.Column<int>(type: "int", nullable: false),
                    TurnoId = table.Column<int>(type: "int", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anno = table.Column<int>(type: "int", nullable: false),
                    CondicionActual = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VencimientoCondicion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursadoMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursadoMaterias_Alumnos_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursadoMaterias_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurnoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoEvaluacion = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Libro = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sede = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluaciones_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    CUPOF_ProfesorId = table.Column<int>(type: "int", nullable: false),
                    IdMab = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SitRevista = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MAB_CUPOF_Profesores_CUPOF_ProfesorId",
                        column: x => x.CUPOF_ProfesorId,
                        principalTable: "CUPOF_Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MAB_Profesores_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Profesores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClasesAsistencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursadoMateriaId = table.Column<int>(type: "int", nullable: false),
                    ClaseId = table.Column<int>(type: "int", nullable: false),
                    Asistencia = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasesAsistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClasesAsistencias_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClasesAsistencias_CursadoMaterias_CursadoMateriaId",
                        column: x => x.CursadoMateriaId,
                        principalTable: "CursadoMaterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluacionId = table.Column<int>(type: "int", nullable: false),
                    ValorNota = table.Column<int>(type: "int", maxLength: 60, nullable: false),
                    Asistencia = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CursadoMateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_CursadoMaterias_CursadoMateriaId",
                        column: x => x.CursadoMateriaId,
                        principalTable: "CursadoMaterias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notas_Evaluaciones_EvaluacionId",
                        column: x => x.EvaluacionId,
                        principalTable: "Evaluaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_UsuarioId",
                table: "Alumnos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificadosAlumnos_AlumnoId",
                table: "CertificadosAlumnos",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "Clases_UQ",
                table: "Clases",
                columns: new[] { "TurnoId", "Fecha" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ClasesDeUnTurnoIDX",
                table: "Clases",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "AsistenciasDeAlumnoEnTurnoIDX",
                table: "ClasesAsistencias",
                column: "CursadoMateriaId");

            migrationBuilder.CreateIndex(
                name: "AsistenciasDeUnaClaseIDX",
                table: "ClasesAsistencias",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "FaltaronEstaClaseIDX",
                table: "ClasesAsistencias",
                columns: new[] { "Asistencia", "ClaseId" });

            migrationBuilder.CreateIndex(
                name: "IX_Coordinadores_CarreraId",
                table: "Coordinadores",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinadores_UsuarioId",
                table: "Coordinadores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Correlatividades_MateriaCorrelativaId",
                table: "Correlatividades",
                column: "MateriaCorrelativaId");

            migrationBuilder.CreateIndex(
                name: "IX_Correlatividades_MateriaEnPlanEstudioId",
                table: "Correlatividades",
                column: "MateriaEnPlanEstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_CUPOF_Coordinadores_CarreraId",
                table: "CUPOF_Coordinadores",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_CUPOF_Coordinadores_CoordinadorId",
                table: "CUPOF_Coordinadores",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_CUPOF_Profesores_TurnoId",
                table: "CUPOF_Profesores",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursadoMaterias_AlumnoId",
                table: "CursadoMaterias",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursadoMaterias_TurnoId",
                table: "CursadoMaterias",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "EvaluacionesDeUnTurnoIDX",
                table: "Evaluaciones",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "EvaluacionesEnFechaIDX",
                table: "Evaluaciones",
                columns: new[] { "TurnoId", "Fecha" });

            migrationBuilder.CreateIndex(
                name: "EvaluacionesTipoIDX",
                table: "Evaluaciones",
                columns: new[] { "TurnoId", "TipoEvaluacion" });

            migrationBuilder.CreateIndex(
                name: "CohorteIDX",
                table: "InscripcionCarreras",
                columns: new[] { "CarreraId", "Cohorte" });

            migrationBuilder.CreateIndex(
                name: "InscripcionCarrera_UQ",
                table: "InscripcionCarreras",
                columns: new[] { "AlumnoId", "CarreraId", "Cohorte" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InscripcionCarreras_CertificadoAlumnoId",
                table: "InscripcionCarreras",
                column: "CertificadoAlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_MAB_CUPOF_ProfesorId",
                table: "MAB",
                column: "CUPOF_ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_MAB_ProfesorId",
                table: "MAB",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "MABUnico_UQ",
                table: "MAB",
                column: "IdMab",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Materia_UQ",
                table: "Materias",
                columns: new[] { "Nombre", "ResolucionMinisterial" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "MateriasPorNombreIDX",
                table: "Materias",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_MateriasEnPlanEstudio_MateriaId",
                table: "MateriasEnPlanEstudio",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "MateriaEnPlanEstudio_UQ",
                table: "MateriasEnPlanEstudio",
                columns: new[] { "PlanEstudioId", "MateriaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NotasDeAlumnoEnMateriaIDX",
                table: "Notas",
                column: "CursadoMateriaId");

            migrationBuilder.CreateIndex(
                name: "NotasDeEvaluacionIDX",
                table: "Notas",
                column: "EvaluacionId");

            migrationBuilder.CreateIndex(
                name: "Apellido-NombreIDX",
                table: "Personas",
                columns: new[] { "Apellido", "Nombre" });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TipoDocumentoId",
                table: "Personas",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "Nombre-ApellidoIDX",
                table: "Personas",
                columns: new[] { "Nombre", "Apellido" });

            migrationBuilder.CreateIndex(
                name: "PersonaUnica_UQ",
                table: "Personas",
                columns: new[] { "Documento", "TipoDocumentoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PlanesDeUnaCarreraIDX",
                table: "PlanEstudios",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "PlanEstudio_UQ",
                table: "PlanEstudios",
                columns: new[] { "CarreraId", "Anno" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesores_UsuarioId",
                table: "Profesores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "TDocumentoUnico_UQ",
                table: "TipoDocumentos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "InscripcionCarrera_UQ",
                table: "Turnos",
                columns: new[] { "MateriaEnPlanEstudioId", "Sede", "Horario", "AnnoCicloLectivo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ProfesorId",
                table: "Turnos",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "MateriasQueDaUnProfeIDX",
                table: "Turnos",
                columns: new[] { "MateriaEnPlanEstudioId", "ProfesorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasesAsistencias");

            migrationBuilder.DropTable(
                name: "Correlatividades");

            migrationBuilder.DropTable(
                name: "CUPOF_Coordinadores");

            migrationBuilder.DropTable(
                name: "InscripcionCarreras");

            migrationBuilder.DropTable(
                name: "MAB");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Coordinadores");

            migrationBuilder.DropTable(
                name: "CertificadosAlumnos");

            migrationBuilder.DropTable(
                name: "CUPOF_Profesores");

            migrationBuilder.DropTable(
                name: "CursadoMaterias");

            migrationBuilder.DropTable(
                name: "Evaluaciones");

            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "MateriasEnPlanEstudio");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "PlanEstudios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Carreras");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}
