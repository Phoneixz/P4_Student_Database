using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDatabase.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_CourseID",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Courses_CourseID",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Departments_DepartmentID",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_CourseID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Grades_GradeID",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "GradeID",
                table: "Student",
                newName: "GradeId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Student",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GradeID",
                table: "Student",
                newName: "IX_Student_GradeId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseID",
                table: "Student",
                newName: "IX_Student_CourseId");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Lecturers",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Lecturers",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "LecturerID",
                table: "Lecturers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturers_DepartmentID",
                table: "Lecturers",
                newName: "IX_Lecturers_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturers_CourseID",
                table: "Lecturers",
                newName: "IX_Lecturers_CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Grades",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "GradeID",
                table: "Grades",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_CourseID",
                table: "Grades",
                newName: "IX_Grades_CourseId");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Departments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Courses",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_CourseId",
                table: "Grades",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Courses_CourseId",
                table: "Lecturers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Departments_DepartmentId",
                table: "Lecturers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Grades_GradeId",
                table: "Student",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Courses_CourseId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Courses_CourseId",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_Departments_DepartmentId",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Grades_GradeId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "GradeId",
                table: "Student",
                newName: "GradeID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Student",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GradeId",
                table: "Student",
                newName: "IX_Student_GradeID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                newName: "IX_Student_CourseID");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Lecturers",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Lecturers",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lecturers",
                newName: "LecturerID");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturers_DepartmentId",
                table: "Lecturers",
                newName: "IX_Lecturers_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Lecturers_CourseId",
                table: "Lecturers",
                newName: "IX_Lecturers_CourseID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Grades",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Grades",
                newName: "GradeID");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_CourseId",
                table: "Grades",
                newName: "IX_Grades_CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Courses_CourseID",
                table: "Grades",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Courses_CourseID",
                table: "Lecturers",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_Departments_DepartmentID",
                table: "Lecturers",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_CourseID",
                table: "Student",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Grades_GradeID",
                table: "Student",
                column: "GradeID",
                principalTable: "Grades",
                principalColumn: "GradeID");
        }
    }
}
