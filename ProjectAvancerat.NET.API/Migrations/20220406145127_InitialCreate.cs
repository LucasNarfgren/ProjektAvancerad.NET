using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectAvancerat.NET.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CustomerPhone = table.Column<string>(nullable: false),
                    CustomerEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(maxLength: 25, nullable: false),
                    ProjectDescription = table.Column<string>(maxLength: 200, nullable: false),
                    ProjectStartDate = table.Column<DateTime>(nullable: false),
                    ProjectEndDate = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    EstimatedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Completed = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timereports",
                columns: table => new
                {
                    TimeReportId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    DateOfRegistration = table.Column<DateTime>(nullable: false),
                    WorkTime = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timereports", x => x.TimeReportId);
                    table.ForeignKey(
                        name: "FK_Timereports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timereports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CompanyName", "CustomerEmail", "CustomerName", "CustomerPhone" },
                values: new object[,]
                {
                    { 1, "Qlok", "Tobias@Qlok.se", "Tobias", "0708090989" },
                    { 2, "Qlok", "Anas@Qlok.se", "Anas", "0907567623" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Adress", "FirstName", "LastName", "PhoneNumber", "ProjectId", "Salary" },
                values: new object[,]
                {
                    { 1, "Hertings Allé 5A", "Lucas", "Narfgren", "0707409223", null, 32300.00m },
                    { 2, "Kalles Väg 36", "Johhny", "Karlsson", "0709804567", null, 38500.00m },
                    { 3, "Stor Gatan 13", "Felix", "Jönsson", "0908458712", null, 45500.00m }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Completed", "CustomerId", "EstimatedPrice", "ProjectDescription", "ProjectEndDate", "ProjectName", "ProjectStartDate" },
                values: new object[] { 1, false, 1, 10000.00m, "Skapa en application för tidsrapportering.", new DateTime(2022, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avancerad.NET Projekt", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Completed", "CustomerId", "EstimatedPrice", "ProjectDescription", "ProjectEndDate", "ProjectName", "ProjectStartDate" },
                values: new object[] { 2, true, 2, 25000.00m, "Skapa ett simpelt spel för försäljning.", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spel Projekt", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "Id", "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Timereports",
                columns: new[] { "TimeReportId", "DateOfRegistration", "Description", "EmployeeId", "ProjectId", "WorkTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Börjat skapa en grund för applicationen", 1, 1, 8.5m },
                    { 2, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Börjat med projektet i form av planering", 2, 2, 4.5m },
                    { 3, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Börjat med projektet i form av planering", 3, 2, 4.5m },
                    { 4, new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Börjat skapa en grund för Spelet", 3, 2, 8.0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EmployeeId",
                table: "EmployeeProjects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Timereports_EmployeeId",
                table: "Timereports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Timereports_ProjectId",
                table: "Timereports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Timereports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
