using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.DB.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "city",
                table: "InquiryList",
                newName: "City");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "InquiryList",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Additionalnotes",
                table: "InquiryList",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Additionalnotes",
                table: "InquiryList");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "InquiryList",
                newName: "city");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "InquiryList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
