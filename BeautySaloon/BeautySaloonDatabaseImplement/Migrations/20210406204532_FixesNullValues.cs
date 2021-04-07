using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautySaloonDatabaseImplement.Migrations
{
    public partial class FixesNullValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Purchases_PurchaseId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Distributions_DistributionId",
                table: "Visits");

            migrationBuilder.AlterColumn<int>(
                name: "DistributionId",
                table: "Visits",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "Receipts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Purchases_PurchaseId",
                table: "Receipts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Distributions_DistributionId",
                table: "Visits",
                column: "DistributionId",
                principalTable: "Distributions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Purchases_PurchaseId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Distributions_DistributionId",
                table: "Visits");

            migrationBuilder.AlterColumn<int>(
                name: "DistributionId",
                table: "Visits",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseId",
                table: "Receipts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Purchases_PurchaseId",
                table: "Receipts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Distributions_DistributionId",
                table: "Visits",
                column: "DistributionId",
                principalTable: "Distributions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
