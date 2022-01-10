using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationApp.Server.Migrations
{
    public partial class AddAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    companyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.companyId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeFirstName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    employeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeUsername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeePassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                });

            migrationBuilder.CreateTable(
                name: "PredictionReports",
                columns: table => new
                {
                    reportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    predictionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    performance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reportName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictionReports", x => x.reportId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ticketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ticketDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ticketId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    projectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    companyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.projectId);
                    table.ForeignKey(
                        name: "FK_Projects_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "companyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTicket",
                columns: table => new
                {
                    EmployeesemployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketsticketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTicket", x => new { x.EmployeesemployeeId, x.TicketsticketId });
                    table.ForeignKey(
                        name: "FK_EmployeeTicket_Employees_EmployeesemployeeId",
                        column: x => x.EmployeesemployeeId,
                        principalTable: "Employees",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTicket_Tickets_TicketsticketId",
                        column: x => x.TicketsticketId,
                        principalTable: "Tickets",
                        principalColumn: "ticketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProject",
                columns: table => new
                {
                    EmployeesemployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsprojectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProject", x => new { x.EmployeesemployeeId, x.ProjectsprojectId });
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Employees_EmployeesemployeeId",
                        column: x => x.EmployeesemployeeId,
                        principalTable: "Employees",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProject_Projects_ProjectsprojectId",
                        column: x => x.ProjectsprojectId,
                        principalTable: "Projects",
                        principalColumn: "projectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTicket",
                columns: table => new
                {
                    ProjectsprojectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketsticketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTicket", x => new { x.ProjectsprojectId, x.TicketsticketId });
                    table.ForeignKey(
                        name: "FK_ProjectTicket_Projects_ProjectsprojectId",
                        column: x => x.ProjectsprojectId,
                        principalTable: "Projects",
                        principalColumn: "projectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTicket_Tickets_TicketsticketId",
                        column: x => x.TicketsticketId,
                        principalTable: "Tickets",
                        principalColumn: "ticketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProject_ProjectsprojectId",
                table: "EmployeeProject",
                column: "ProjectsprojectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTicket_TicketsticketId",
                table: "EmployeeTicket",
                column: "TicketsticketId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_companyId",
                table: "Projects",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTicket_TicketsticketId",
                table: "ProjectTicket",
                column: "TicketsticketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProject");

            migrationBuilder.DropTable(
                name: "EmployeeTicket");

            migrationBuilder.DropTable(
                name: "PredictionReports");

            migrationBuilder.DropTable(
                name: "ProjectTicket");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
