using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAppTracker.Migrations.JobApplicationDb
{
    /// <inheritdoc />
    public partial class AddDefaultDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
            name: "DateApplied",
            table: "JobApps",
            nullable: false,
            defaultValue: DateTime.Now,
            oldClrType: typeof(DateTime),
            oldNullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
            name: "DateApplied",
            table: "JobApps",
            nullable: true,
            oldClrType: typeof(DateTime));

        }
    }
}
