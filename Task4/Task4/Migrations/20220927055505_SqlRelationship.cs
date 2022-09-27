using Microsoft.EntityFrameworkCore.Migrations;

namespace Task4.Migrations
{
    public partial class SqlRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeModal",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wfm_Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeModal", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    wfm_manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lockstatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    profile_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    skillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.skillId);
                });

            migrationBuilder.CreateTable(
                name: "SkillMaps",
                columns: table => new
                {
                    employee_Id = table.Column<int>(type: "int", nullable: false),
                    skillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillMaps", x => new { x.employee_Id, x.skillId });
                    table.ForeignKey(
                        name: "FK_SkillMaps_Employees_employee_Id",
                        column: x => x.employee_Id,
                        principalTable: "Employees",
                        principalColumn: "employee_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillMaps_Skills_skillId",
                        column: x => x.skillId,
                        principalTable: "Skills",
                        principalColumn: "skillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillMaps_skillId",
                table: "SkillMaps",
                column: "skillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeModal");

            migrationBuilder.DropTable(
                name: "SkillMaps");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
