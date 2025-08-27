using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClinicManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0a58a587-e7f7-4686-a986-6ac4f77041ee"), null, "Patient", "PATIENT" },
                    { new Guid("a2325752-ac16-48e9-afcf-41f069b24070"), null, "Doctor", "DOCTOR" },
                    { new Guid("e1471676-1fc6-467d-ada7-7abdb62a2ddd"), null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a58a587-e7f7-4686-a986-6ac4f77041ee"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2325752-ac16-48e9-afcf-41f069b24070"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1471676-1fc6-467d-ada7-7abdb62a2ddd"));
        }
    }
}
