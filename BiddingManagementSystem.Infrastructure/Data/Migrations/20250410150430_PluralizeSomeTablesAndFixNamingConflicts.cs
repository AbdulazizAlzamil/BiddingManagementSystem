using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiddingManagementSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class PluralizeSomeTablesAndFixNamingConflicts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_EvaluationCriteria_EvaluationCriteriaId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_Score_Evaluations_EvaluationId",
                table: "Score");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderCategories_TenderCategory_CategoriesId",
                table: "TenderCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderCategories_Tenders_TendersId",
                table: "TenderCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderDocument_Tenders_TenderId",
                table: "TenderDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderDocument",
                table: "TenderDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderCategories",
                table: "TenderCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Score",
                table: "Score");

            migrationBuilder.RenameTable(
                name: "TenderDocument",
                newName: "TenderDocuments");

            migrationBuilder.RenameTable(
                name: "TenderCategories",
                newName: "TenderCategoryMappings");

            migrationBuilder.RenameTable(
                name: "Score",
                newName: "Scores");

            migrationBuilder.RenameIndex(
                name: "IX_TenderDocument_TenderId",
                table: "TenderDocuments",
                newName: "IX_TenderDocuments_TenderId");

            migrationBuilder.RenameIndex(
                name: "IX_TenderCategories_TendersId",
                table: "TenderCategoryMappings",
                newName: "IX_TenderCategoryMappings_TendersId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_EvaluationId",
                table: "Scores",
                newName: "IX_Scores_EvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_Score_EvaluationCriteriaId",
                table: "Scores",
                newName: "IX_Scores_EvaluationCriteriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderDocuments",
                table: "TenderDocuments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderCategoryMappings",
                table: "TenderCategoryMappings",
                columns: new[] { "CategoriesId", "TendersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scores",
                table: "Scores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_EvaluationCriteria_EvaluationCriteriaId",
                table: "Scores",
                column: "EvaluationCriteriaId",
                principalTable: "EvaluationCriteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Evaluations_EvaluationId",
                table: "Scores",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderCategoryMappings_TenderCategory_CategoriesId",
                table: "TenderCategoryMappings",
                column: "CategoriesId",
                principalTable: "TenderCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderCategoryMappings_Tenders_TendersId",
                table: "TenderCategoryMappings",
                column: "TendersId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderDocuments_Tenders_TenderId",
                table: "TenderDocuments",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_EvaluationCriteria_EvaluationCriteriaId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Evaluations_EvaluationId",
                table: "Scores");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderCategoryMappings_TenderCategory_CategoriesId",
                table: "TenderCategoryMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderCategoryMappings_Tenders_TendersId",
                table: "TenderCategoryMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TenderDocuments_Tenders_TenderId",
                table: "TenderDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderDocuments",
                table: "TenderDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TenderCategoryMappings",
                table: "TenderCategoryMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scores",
                table: "Scores");

            migrationBuilder.RenameTable(
                name: "TenderDocuments",
                newName: "TenderDocument");

            migrationBuilder.RenameTable(
                name: "TenderCategoryMappings",
                newName: "TenderCategories");

            migrationBuilder.RenameTable(
                name: "Scores",
                newName: "Score");

            migrationBuilder.RenameIndex(
                name: "IX_TenderDocuments_TenderId",
                table: "TenderDocument",
                newName: "IX_TenderDocument_TenderId");

            migrationBuilder.RenameIndex(
                name: "IX_TenderCategoryMappings_TendersId",
                table: "TenderCategories",
                newName: "IX_TenderCategories_TendersId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_EvaluationId",
                table: "Score",
                newName: "IX_Score_EvaluationId");

            migrationBuilder.RenameIndex(
                name: "IX_Scores_EvaluationCriteriaId",
                table: "Score",
                newName: "IX_Score_EvaluationCriteriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderDocument",
                table: "TenderDocument",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TenderCategories",
                table: "TenderCategories",
                columns: new[] { "CategoriesId", "TendersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Score",
                table: "Score",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_EvaluationCriteria_EvaluationCriteriaId",
                table: "Score",
                column: "EvaluationCriteriaId",
                principalTable: "EvaluationCriteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Evaluations_EvaluationId",
                table: "Score",
                column: "EvaluationId",
                principalTable: "Evaluations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderCategories_TenderCategory_CategoriesId",
                table: "TenderCategories",
                column: "CategoriesId",
                principalTable: "TenderCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderCategories_Tenders_TendersId",
                table: "TenderCategories",
                column: "TendersId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenderDocument_Tenders_TenderId",
                table: "TenderDocument",
                column: "TenderId",
                principalTable: "Tenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
