using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicRepositories.Migrations
{
    /// <inheritdoc />
    public partial class FixingRelations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CardType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardType", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicAbility",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicAbility", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicLegality",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Format = table.Column<string>(type: "longtext", nullable: false),
                    LegalityName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicLegality", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    SetName = table.Column<string>(type: "longtext", nullable: false),
                    SetCode = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicSets", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SuperCardTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperCardTypes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CardId = table.Column<string>(type: "longtext", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: false),
                    MagicSetId = table.Column<Guid>(type: "char(36)", nullable: false),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false),
                    MultiverseId = table.Column<string>(type: "longtext", nullable: false),
                    Cmc = table.Column<int>(type: "int", nullable: false),
                    IsColorLess = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsMultiColor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ManaCost = table.Column<string>(type: "longtext", nullable: false),
                    CollectingNumber = table.Column<string>(type: "longtext", nullable: false),
                    MagicLegalityId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicCards_MagicLegality_MagicLegalityId",
                        column: x => x.MagicLegalityId,
                        principalTable: "MagicLegality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MagicCards_MagicSets_MagicSetId",
                        column: x => x.MagicSetId,
                        principalTable: "MagicSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CardTypeMagicCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CardTypeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicCardId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypeMagicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardTypeMagicCards_CardType_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardTypeMagicCards_MagicCards_MagicCardId",
                        column: x => x.MagicCardId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicAbilityMagicCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicAbilityId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicCardId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicAbilityMagicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicAbilityMagicCards_MagicAbility_MagicAbilityId",
                        column: x => x.MagicAbilityId,
                        principalTable: "MagicAbility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicAbilityMagicCards_MagicCards_MagicCardId",
                        column: x => x.MagicCardId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicCardMagicLegalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicCardId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicLegalityId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicCardMagicLegalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicCardMagicLegalities_MagicCards_MagicCardId",
                        column: x => x.MagicCardId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicCardMagicLegalities_MagicLegality_MagicLegalityId",
                        column: x => x.MagicLegalityId,
                        principalTable: "MagicLegality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicCardSuperCardTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicCardId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SuperCardTypeId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicCardSuperCardTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicCardSuperCardTypes_MagicCards_MagicCardId",
                        column: x => x.MagicCardId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicCardSuperCardTypes_SuperCardTypes_SuperCardTypeId",
                        column: x => x.SuperCardTypeId,
                        principalTable: "SuperCardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicRuling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: false),
                    MagicCardId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicRuling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicRuling_MagicCards_MagicCardId",
                        column: x => x.MagicCardId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicSetMagicCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicSetId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicCardId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicSetMagicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicSetMagicCards_MagicCards_MagicCardId",
                        column: x => x.MagicCardId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicSetMagicCards_MagicSets_MagicSetId",
                        column: x => x.MagicSetId,
                        principalTable: "MagicSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CardTypeMagicCards_CardTypeId",
                table: "CardTypeMagicCards",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CardTypeMagicCards_MagicCardId",
                table: "CardTypeMagicCards",
                column: "MagicCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicAbilityMagicCards_MagicAbilityId",
                table: "MagicAbilityMagicCards",
                column: "MagicAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicAbilityMagicCards_MagicCardId",
                table: "MagicAbilityMagicCards",
                column: "MagicCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCardMagicLegalities_MagicCardId",
                table: "MagicCardMagicLegalities",
                column: "MagicCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCardMagicLegalities_MagicLegalityId",
                table: "MagicCardMagicLegalities",
                column: "MagicLegalityId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCards_MagicLegalityId",
                table: "MagicCards",
                column: "MagicLegalityId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCards_MagicSetId",
                table: "MagicCards",
                column: "MagicSetId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCardSuperCardTypes_MagicCardId",
                table: "MagicCardSuperCardTypes",
                column: "MagicCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCardSuperCardTypes_SuperCardTypeId",
                table: "MagicCardSuperCardTypes",
                column: "SuperCardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicRuling_MagicCardId",
                table: "MagicRuling",
                column: "MagicCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicSetMagicCards_MagicCardId",
                table: "MagicSetMagicCards",
                column: "MagicCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicSetMagicCards_MagicSetId",
                table: "MagicSetMagicCards",
                column: "MagicSetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTypeMagicCards");

            migrationBuilder.DropTable(
                name: "MagicAbilityMagicCards");

            migrationBuilder.DropTable(
                name: "MagicCardMagicLegalities");

            migrationBuilder.DropTable(
                name: "MagicCardSuperCardTypes");

            migrationBuilder.DropTable(
                name: "MagicRuling");

            migrationBuilder.DropTable(
                name: "MagicSetMagicCards");

            migrationBuilder.DropTable(
                name: "CardType");

            migrationBuilder.DropTable(
                name: "MagicAbility");

            migrationBuilder.DropTable(
                name: "SuperCardTypes");

            migrationBuilder.DropTable(
                name: "MagicCards");

            migrationBuilder.DropTable(
                name: "MagicLegality");

            migrationBuilder.DropTable(
                name: "MagicSets");
        }
    }
}
