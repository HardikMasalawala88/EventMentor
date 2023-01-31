using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.DB.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventList_InquiryList_InquiryId",
                table: "EventList");

            migrationBuilder.DropIndex(
                name: "IX_EventList_InquiryId",
                table: "EventList");

            migrationBuilder.AlterColumn<long>(
                name: "InquiryId",
                table: "EventList",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventList_InquiryId",
                table: "EventList",
                column: "InquiryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventList_InquiryList_InquiryId",
                table: "EventList",
                column: "InquiryId",
                principalTable: "InquiryList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventList_InquiryList_InquiryId",
                table: "EventList");

            migrationBuilder.DropIndex(
                name: "IX_EventList_InquiryId",
                table: "EventList");

            migrationBuilder.AlterColumn<long>(
                name: "InquiryId",
                table: "EventList",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
    }
}
