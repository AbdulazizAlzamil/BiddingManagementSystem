using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTenderCategoryLookupTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderCategoryMappings_TenderCategory_CategoriesId",
                table: "TenderCategoryMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderCategory",
                table: "TenderCategory");

            migrationBuilder.RenameTable(
                name: "TenderCategory",
                newName: "TenderCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderCategories",
                table: "TenderCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderCategoryMappings_TenderCategories_CategoriesId",
                table: "TenderCategoryMappings",
                column: "CategoriesId",
                principalTable: "TenderCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenderCategoryMappings_TenderCategories_CategoriesId",
                table: "TenderCategoryMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderCategories",
                table: "TenderCategories");

            migrationBuilder.RenameTable(
                name: "TenderCategories",
                newName: "TenderCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderCategory",
                table: "TenderCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenderCategoryMappings_TenderCategory_CategoriesId",
                table: "TenderCategoryMappings",
                column: "CategoriesId",
                principalTable: "TenderCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
