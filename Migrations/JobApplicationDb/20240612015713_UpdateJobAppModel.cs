using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAppTracker.Migrations.JobApplicationDb
{
    /// <inheritdoc />
    public partial class UpdateJobAppModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "JobApps");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "JobApps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
