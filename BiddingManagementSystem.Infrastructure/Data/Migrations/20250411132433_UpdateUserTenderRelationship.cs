using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTenderRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Tenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_UserId",
                table: "Tenders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenders_Users_UserId",
                table: "Tenders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenders_Users_UserId",
                table: "Tenders");

            migrationBuilder.DropIndex(
                name: "IX_Tenders_UserId",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tenders");
        }
    }
}
