using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEvaluationScoreAndBidRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Evaluations_BidId",
                table: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "Score_Value",
                table: "Evaluations",
                newName: "TotalScore");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_BidId",
                table: "Evaluations",
                column: "BidId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Evaluations_BidId",
                table: "Evaluations");

            migrationBuilder.RenameColumn(
                name: "TotalScore",
                table: "Evaluations",
                newName: "Score_Value");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_BidId",
                table: "Evaluations",
                column: "BidId");
        }
    }
}
