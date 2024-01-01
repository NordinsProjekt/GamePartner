using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicRepositories.Migrations
{
    /// <inheritdoc />
    public partial class SubTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CardSubTypeId",
                table: "CardTypeMagicCards",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CardSubType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardSubType", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CardSubTypeMagicCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CardSubTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicCardId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardSubTypeMagicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardSubTypeMagicCards_CardSubType_CardSubTypeId",
                        column: x => x.CardSubTypeId,
                        principalTable: "CardSubType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardSubTypeMagicCards_MagicCards_MagicCardId",
                        column: x => x.MagicCardId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CardTypeMagicCards_CardSubTypeId",
                table: "CardTypeMagicCards",
                column: "CardSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CardSubTypeMagicCards_CardSubTypeId",
                table: "CardSubTypeMagicCards",
                column: "CardSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CardSubTypeMagicCards_MagicCardId",
                table: "CardSubTypeMagicCards",
                column: "MagicCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardTypeMagicCards_CardSubType_CardSubTypeId",
                table: "CardTypeMagicCards",
                column: "CardSubTypeId",
                principalTable: "CardSubType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardTypeMagicCards_CardSubType_CardSubTypeId",
                table: "CardTypeMagicCards");

            migrationBuilder.DropTable(
                name: "CardSubTypeMagicCards");

            migrationBuilder.DropTable(
                name: "CardSubType");

            migrationBuilder.DropIndex(
                name: "IX_CardTypeMagicCards_CardSubTypeId",
                table: "CardTypeMagicCards");

            migrationBuilder.DropColumn(
                name: "CardSubTypeId",
                table: "CardTypeMagicCards");
        }
    }
}
