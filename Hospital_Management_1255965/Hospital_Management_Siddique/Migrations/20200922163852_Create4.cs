using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_Siddique.Migrations
{
    public partial class Create4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoctorName",
                table: "DoctorPatients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "DoctorPatients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorName",
                table: "DoctorPatients");

            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "DoctorPatients");
        }
    }
}
