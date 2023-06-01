using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCoursePortal.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addIdentityTablesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "CourseBookings",
                newName: "UserEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "CourseBookings",
                newName: "StudentId");
        }
    }
}
