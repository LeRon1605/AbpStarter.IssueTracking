using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpStarter.IssueTracking.Migrations
{
    public partial class init_issue_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpBuckets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBuckets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpIssue_Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpIssue_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpLabels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(124)", maxLength: 124, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLabels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AbpIssues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CloseReason = table.Column<int>(type: "int", nullable: true),
                    RepositoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BucketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpIssues_AbpBuckets_BucketId",
                        column: x => x.BucketId,
                        principalTable: "AbpBuckets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbpIssues_AbpIssue_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AbpIssue_Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbpComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpComments_AbpIssue_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpIssue_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpComments_AbpIssues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "AbpIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueLabels",
                columns: table => new
                {
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueLabels", x => new { x.IssueId, x.LabelId });
                    table.ForeignKey(
                        name: "FK_IssueLabels_AbpIssues_LabelId",
                        column: x => x.LabelId,
                        principalTable: "AbpIssues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueLabels_AbpLabels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "AbpLabels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpComments_IssueId",
                table: "AbpComments",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpComments_UserId",
                table: "AbpComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpIssue_Users_UserName",
                table: "AbpIssue_Users",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpIssues_AssignedUserId",
                table: "AbpIssues",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpIssues_BucketId",
                table: "AbpIssues",
                column: "BucketId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueLabels_LabelId",
                table: "IssueLabels",
                column: "LabelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpComments");

            migrationBuilder.DropTable(
                name: "IssueLabels");

            migrationBuilder.DropTable(
                name: "AbpIssues");

            migrationBuilder.DropTable(
                name: "AbpLabels");

            migrationBuilder.DropTable(
                name: "AbpBuckets");

            migrationBuilder.DropTable(
                name: "AbpIssue_Users");
        }
    }
}
