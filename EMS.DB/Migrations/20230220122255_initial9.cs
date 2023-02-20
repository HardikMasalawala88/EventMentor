using Microsoft.EntityFrameworkCore.Migrations;

namespace EMS.DB.Migrations
{
    public partial class initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryServices_EventCategories_EventCategoryId",
                table: "CategoryServices");

            migrationBuilder.DropIndex(
                name: "IX_Payments_EventId",
                table: "Payments");

            migrationBuilder.AlterColumn<long>(
                name: "EventCategoryId",
                table: "CategoryServices",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EventId",
                table: "Payments",
                column: "EventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryServices_EventCategories_EventCategoryId",
                table: "CategoryServices",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryServices_EventCategories_EventCategoryId",
                table: "CategoryServices");

            migrationBuilder.DropIndex(
                name: "IX_Payments_EventId",
                table: "Payments");

            migrationBuilder.AlterColumn<long>(
                name: "EventCategoryId",
                table: "CategoryServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EventId",
                table: "Payments",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryServices_EventCategories_EventCategoryId",
                table: "CategoryServices",
                column: "EventCategoryId",
                principalTable: "EventCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
