using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicRepositories.Migrations
{
    /// <inheritdoc />
    public partial class FixingRelations4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MagicCards_MagicLegality_MagicLegalityId",
                table: "MagicCards");

            migrationBuilder.DropIndex(
                name: "IX_MagicCards_MagicLegalityId",
                table: "MagicCards");

            migrationBuilder.DropColumn(
                name: "MagicLegalityId",
                table: "MagicCards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MagicLegalityId",
                table: "MagicCards",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MagicCards_MagicLegalityId",
                table: "MagicCards",
                column: "MagicLegalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MagicCards_MagicLegality_MagicLegalityId",
                table: "MagicCards",
                column: "MagicLegalityId",
                principalTable: "MagicLegality",
                principalColumn: "Id");
        }
    }
}
