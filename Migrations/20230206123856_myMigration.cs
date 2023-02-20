using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthPlus.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.RenameColumn(
                name: "SUgarLevel",
                table: "Consultations",
                newName: "SugarLevel");

            //migrationBuilder.AddColumn<string>(
            //    name: "CreatedBy",
            //    table: "MedicalRecords",
            //    type: "longtext",
            //    nullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DateCreated",
            //    table: "MedicalRecords",
            //    type: "datetime(6)",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DateUpdated",
            //    table: "MedicalRecords",
            //    type: "datetime(6)",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDeleted",
            //    table: "MedicalRecords",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "ModifiedBy",
            //    table: "MedicalRecords",
            //    type: "longtext",
            //    nullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AlterColumn<int>(
            //    name: "MedicalRecordId",
            //    table: "Consultations",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Complaint",
            //    table: "Consultations",
            //    type: "longtext",
            //    nullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AddColumn<string>(
            //    name: "CreatedBy",
            //    table: "Consultations",
            //    type: "longtext",
            //    nullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DateCreated",
            //    table: "Consultations",
            //    type: "datetime(6)",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "DateUpdated",
            //    table: "Consultations",
            //    type: "datetime(6)",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDeleted",
            //    table: "Consultations",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<string>(
            //    name: "ModifiedBy",
            //    table: "Consultations",
            //    type: "longtext",
            //    nullable: true)
            //    .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalRecords_MedicalRecordId",
                table: "Consultations",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "Complaint",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Consultations");

            migrationBuilder.RenameColumn(
                name: "SugarLevel",
                table: "Consultations",
                newName: "SUgarLevel");

            migrationBuilder.AddColumn<int>(
                name: "ConsultationId",
                table: "MedicalRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "Consultations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_ConsultationId",
                table: "MedicalRecords",
                column: "ConsultationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalRecords_MedicalRecordId",
                table: "Consultations",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Consultations_ConsultationId",
                table: "MedicalRecords",
                column: "ConsultationId",
                principalTable: "Consultations",
                principalColumn: "Id");
        }
    }
}
