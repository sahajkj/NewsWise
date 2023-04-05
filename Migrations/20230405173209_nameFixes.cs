using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsWise.Migrations
{
    /// <inheritdoc />
    public partial class nameFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Claims_ClaimId1",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ReviewPublisher_Review_PublisherId1",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ClaimId1",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_Review_PublisherId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Claim_ReviewId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ClaimId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Review_PublisherId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "Review_PublisherId1",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "Review_PublisherId",
                table: "ReviewPublisher",
                newName: "ReviewPublisherId");

            migrationBuilder.RenameColumn(
                name: "Textual_Rating",
                table: "Review",
                newName: "TextualRating");

            migrationBuilder.RenameColumn(
                name: "Review_Date",
                table: "Review",
                newName: "ReviewDate");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimId",
                table: "Review",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ClaimReviewId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ReviewPublisherId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClaimDate",
                table: "Claims",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "ClaimReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ClaimId",
                table: "Review",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewPublisherId",
                table: "Review",
                column: "ReviewPublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Claims_ClaimId",
                table: "Review",
                column: "ClaimId",
                principalTable: "Claims",
                principalColumn: "ClaimId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ReviewPublisher_ReviewPublisherId",
                table: "Review",
                column: "ReviewPublisherId",
                principalTable: "ReviewPublisher",
                principalColumn: "ReviewPublisherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Claims_ClaimId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ReviewPublisher_ReviewPublisherId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ClaimId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ReviewPublisherId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ClaimReviewId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ReviewPublisherId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ReviewPublisherId",
                table: "ReviewPublisher",
                newName: "Review_PublisherId");

            migrationBuilder.RenameColumn(
                name: "TextualRating",
                table: "Review",
                newName: "Textual_Rating");

            migrationBuilder.RenameColumn(
                name: "ReviewDate",
                table: "Review",
                newName: "Review_Date");

            migrationBuilder.AlterColumn<string>(
                name: "ClaimId",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Claim_ReviewId",
                table: "Review",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClaimId1",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Review_PublisherId",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Review_PublisherId1",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClaimDate",
                table: "Claims",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Claim_ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ClaimId1",
                table: "Review",
                column: "ClaimId1");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Review_PublisherId1",
                table: "Review",
                column: "Review_PublisherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Claims_ClaimId1",
                table: "Review",
                column: "ClaimId1",
                principalTable: "Claims",
                principalColumn: "ClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ReviewPublisher_Review_PublisherId1",
                table: "Review",
                column: "Review_PublisherId1",
                principalTable: "ReviewPublisher",
                principalColumn: "Review_PublisherId");
        }
    }
}
