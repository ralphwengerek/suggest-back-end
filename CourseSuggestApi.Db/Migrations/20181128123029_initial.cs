﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseSuggestApi.Db.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbilityLevels",
                columns: table => new
                {
                    AbilityLevelId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityLevels", x => x.AbilityLevelId);
                });

            migrationBuilder.CreateTable(
                name: "CourseSuggestions",
                columns: table => new
                {
                    CourseSuggestionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsRunningCourse = table.Column<bool>(nullable: false),
                    CourseName = table.Column<string>(nullable: true),
                    CourseDescription = table.Column<string>(nullable: true),
                    AbilityLevelId = table.Column<int>(nullable: true),
                    AuthorName = table.Column<string>(nullable: true),
                    AuthorRole = table.Column<string>(nullable: true),
                    AuthorLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSuggestions", x => x.CourseSuggestionId);
                    table.ForeignKey(
                        name: "FK_CourseSuggestions_AbilityLevels_AbilityLevelId",
                        column: x => x.AbilityLevelId,
                        principalTable: "AbilityLevels",
                        principalColumn: "AbilityLevelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseSuggestionId = table.Column<int>(nullable: false),
                    VoterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_Votes_CourseSuggestions_CourseSuggestionId",
                        column: x => x.CourseSuggestionId,
                        principalTable: "CourseSuggestions",
                        principalColumn: "CourseSuggestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSuggestions_AbilityLevelId",
                table: "CourseSuggestions",
                column: "AbilityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_CourseSuggestionId",
                table: "Votes",
                column: "CourseSuggestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "CourseSuggestions");

            migrationBuilder.DropTable(
                name: "AbilityLevels");
        }
    }
}
