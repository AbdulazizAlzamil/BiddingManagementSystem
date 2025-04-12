using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWinningBidToTenders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinningBidId",
                table: "Tenders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_WinningBidId",
                table: "Tenders",
                column: "WinningBidId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenders_Bids_WinningBidId",
                table: "Tenders",
                column: "WinningBidId",
                principalTable: "Bids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenders_Bids_WinningBidId",
                table: "Tenders");

            migrationBuilder.DropIndex(
                name: "IX_Tenders_WinningBidId",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "WinningBidId",
                table: "Tenders");
        }
    }
}
