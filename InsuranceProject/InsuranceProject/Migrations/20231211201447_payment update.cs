using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceProject.Migrations
{
    /// <inheritdoc />
    public partial class paymentupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerInsuranceAccountId",
                table: "PolicyPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerInsuranceAccountId",
                table: "PolicyClaims",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyPayments_CustomerInsuranceAccountId",
                table: "PolicyPayments",
                column: "CustomerInsuranceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyClaims_CustomerInsuranceAccountId",
                table: "PolicyClaims",
                column: "CustomerInsuranceAccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyClaims_CustomerInsuranceAccounts_CustomerInsuranceAccountId",
                table: "PolicyClaims",
                column: "CustomerInsuranceAccountId",
                principalTable: "CustomerInsuranceAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyPayments_CustomerInsuranceAccounts_CustomerInsuranceAccountId",
                table: "PolicyPayments",
                column: "CustomerInsuranceAccountId",
                principalTable: "CustomerInsuranceAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyClaims_CustomerInsuranceAccounts_CustomerInsuranceAccountId",
                table: "PolicyClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyPayments_CustomerInsuranceAccounts_CustomerInsuranceAccountId",
                table: "PolicyPayments");

            migrationBuilder.DropIndex(
                name: "IX_PolicyPayments_CustomerInsuranceAccountId",
                table: "PolicyPayments");

            migrationBuilder.DropIndex(
                name: "IX_PolicyClaims_CustomerInsuranceAccountId",
                table: "PolicyClaims");

            migrationBuilder.DropColumn(
                name: "CustomerInsuranceAccountId",
                table: "PolicyPayments");

            migrationBuilder.DropColumn(
                name: "CustomerInsuranceAccountId",
                table: "PolicyClaims");
        }
    }
}
