using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTenderCategoryToOneToManyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenderCategoryMappings");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tenders");

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "TenderCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "TenderCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TenderId",
                table: "TenderCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TenderCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TenderCategories_TenderId",
                table: "TenderCategories",
                column: "TenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderCategories_Tenders_TenderId",
                table: "TenderCategories",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderCategories_Tenders_TenderId",
                table: "TenderCategories");

            migrationBuilder.DropIndex(
                name: "IX_TenderCategories_TenderId",
                table: "TenderCategories");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "TenderCategories");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "TenderCategories");

            migrationBuilder.DropColumn(
                name: "TenderId",
                table: "TenderCategories");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TenderCategories");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tenders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TenderCategoryMappings",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    TendersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderCategoryMappings", x => new { x.CategoriesId, x.TendersId });
                    table.ForeignKey(
                        name: "FK_TenderCategoryMappings_TenderCategories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "TenderCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenderCategoryMappings_Tenders_TendersId",
                        column: x => x.TendersId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenderCategoryMappings_TendersId",
                table: "TenderCategoryMappings",
                column: "TendersId");
        }
    }
}
