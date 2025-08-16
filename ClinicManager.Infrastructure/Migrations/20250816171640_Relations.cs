using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiagnosisId",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DiagnosisId",
                table: "DiagnosisMedications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MedicationId",
                table: "DiagnosisMedications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "Diagnoses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DiagnosisId",
                table: "Invoices",
                column: "DiagnosisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisMedications_DiagnosisId",
                table: "DiagnosisMedications",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisMedications_MedicationId",
                table: "DiagnosisMedications",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_AppointmentId",
                table: "Diagnoses",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Appointments_AppointmentId",
                table: "Diagnoses",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisMedications_Diagnoses_DiagnosisId",
                table: "DiagnosisMedications",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisMedications_Medications_MedicationId",
                table: "DiagnosisMedications",
                column: "MedicationId",
                principalTable: "Medications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Diagnoses_DiagnosisId",
                table: "Invoices",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Appointments_AppointmentId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisMedications_Diagnoses_DiagnosisId",
                table: "DiagnosisMedications");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisMedications_Medications_MedicationId",
                table: "DiagnosisMedications");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Diagnoses_DiagnosisId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_DiagnosisId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_DiagnosisMedications_DiagnosisId",
                table: "DiagnosisMedications");

            migrationBuilder.DropIndex(
                name: "IX_DiagnosisMedications_MedicationId",
                table: "DiagnosisMedications");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_AppointmentId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DiagnosisId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "DiagnosisId",
                table: "DiagnosisMedications");

            migrationBuilder.DropColumn(
                name: "MedicationId",
                table: "DiagnosisMedications");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Appointments");
        }
    }
}
