using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsWise.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claimants",
                columns: table => new
                {
                    ClaimantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimantName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claimants", x => x.ClaimantId);
                });

            migrationBuilder.CreateTable(
                name: "ReviewPublisher",
                columns: table => new
                {
                    Review_PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewPublisher", x => x.Review_PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimantId = table.Column<int>(type: "int", nullable: false),
                    ClaimDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claims_Claimants_ClaimantId",
                        column: x => x.ClaimantId,
                        principalTable: "Claimants",
                        principalColumn: "ClaimantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Claim_ReviewId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Textual_Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review_PublisherId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimId1 = table.Column<int>(type: "int", nullable: false),
                    Review_PublisherId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Claim_ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Claims_ClaimId1",
                        column: x => x.ClaimId1,
                        principalTable: "Claims",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_ReviewPublisher_Review_PublisherId1",
                        column: x => x.Review_PublisherId1,
                        principalTable: "ReviewPublisher",
                        principalColumn: "Review_PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimantId",
                table: "Claims",
                column: "ClaimantId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_ClaimId1",
                table: "Review",
                column: "ClaimId1");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Review_PublisherId1",
                table: "Review",
                column: "Review_PublisherId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "ReviewPublisher");

            migrationBuilder.DropTable(
                name: "Claimants");
        }
    }
}
