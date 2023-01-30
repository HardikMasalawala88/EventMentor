using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.DB.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScheduledOn",
                table: "EventList",
                newName: "Todate");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "EventList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InquiryId",
                table: "EventList",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ispaymentdone",
                table: "EventList",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_EventList_InquiryId",
                table: "EventList",
                column: "InquiryId",
                unique: true,
                filter: "[InquiryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EventList_InquiryList_InquiryId",
                table: "EventList",
                column: "InquiryId",
                principalTable: "InquiryList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventList_InquiryList_InquiryId",
                table: "EventList");

            migrationBuilder.DropIndex(
                name: "IX_EventList_InquiryId",
                table: "EventList");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "EventList");

            migrationBuilder.DropColumn(
                name: "InquiryId",
                table: "EventList");

            migrationBuilder.DropColumn(
                name: "Ispaymentdone",
                table: "EventList");

            migrationBuilder.RenameColumn(
                name: "Todate",
                table: "EventList",
                newName: "ScheduledOn");
        }
    }
}
