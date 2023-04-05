using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsWise.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "Review_PublisherId1",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimId1",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Claims_ClaimId1",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ReviewPublisher_Review_PublisherId1",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "Review_PublisherId1",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClaimId1",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Claims_ClaimId1",
                table: "Review",
                column: "ClaimId1",
                principalTable: "Claims",
                principalColumn: "ClaimId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ReviewPublisher_Review_PublisherId1",
                table: "Review",
                column: "Review_PublisherId1",
                principalTable: "ReviewPublisher",
                principalColumn: "Review_PublisherId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
