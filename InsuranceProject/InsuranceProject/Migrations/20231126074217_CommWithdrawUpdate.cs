using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceProject.Migrations
{
    /// <inheritdoc />
    public partial class CommWithdrawUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalWithdrawalAmount",
                table: "CommisionWithdrawals");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "CommisionWithdrawals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommisionWithdrawals_AgentId",
                table: "CommisionWithdrawals",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommisionWithdrawals_Agents_AgentId",
                table: "CommisionWithdrawals",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommisionWithdrawals_Agents_AgentId",
                table: "CommisionWithdrawals");

            migrationBuilder.DropIndex(
                name: "IX_CommisionWithdrawals_AgentId",
                table: "CommisionWithdrawals");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "CommisionWithdrawals");

            migrationBuilder.AddColumn<double>(
                name: "TotalWithdrawalAmount",
                table: "CommisionWithdrawals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
