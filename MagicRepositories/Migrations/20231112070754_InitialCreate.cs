using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicRepositories.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "SuperCardType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperCardType", x => x.Id);
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
                    CollectingNumber = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicCards_MagicSets_MagicSetId",
                        column: x => x.MagicSetId,
                        principalTable: "MagicSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CardTypeMagicCard",
                columns: table => new
                {
                    CardTypesId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicCardsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypeMagicCard", x => new { x.CardTypesId, x.MagicCardsId });
                    table.ForeignKey(
                        name: "FK_CardTypeMagicCard_CardType_CardTypesId",
                        column: x => x.CardTypesId,
                        principalTable: "CardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardTypeMagicCard_MagicCards_MagicCardsId",
                        column: x => x.MagicCardsId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicAbilityMagicCard",
                columns: table => new
                {
                    AbilitiesId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CardsId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicAbilityMagicCard", x => new { x.AbilitiesId, x.CardsId });
                    table.ForeignKey(
                        name: "FK_MagicAbilityMagicCard_MagicAbility_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "MagicAbility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicAbilityMagicCard_MagicCards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicCardMagicLegality",
                columns: table => new
                {
                    CardsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    MagicLegalitiesId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicCardMagicLegality", x => new { x.CardsId, x.MagicLegalitiesId });
                    table.ForeignKey(
                        name: "FK_MagicCardMagicLegality_MagicCards_CardsId",
                        column: x => x.CardsId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicCardMagicLegality_MagicLegality_MagicLegalitiesId",
                        column: x => x.MagicLegalitiesId,
                        principalTable: "MagicLegality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MagicCardSuperCardType",
                columns: table => new
                {
                    MagicCardsId = table.Column<Guid>(type: "char(36)", nullable: false),
                    SuperCardTypesId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicCardSuperCardType", x => new { x.MagicCardsId, x.SuperCardTypesId });
                    table.ForeignKey(
                        name: "FK_MagicCardSuperCardType_MagicCards_MagicCardsId",
                        column: x => x.MagicCardsId,
                        principalTable: "MagicCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MagicCardSuperCardType_SuperCardType_SuperCardTypesId",
                        column: x => x.SuperCardTypesId,
                        principalTable: "SuperCardType",
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
                    MagicCardId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicRuling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MagicRuling_MagicCards_MagicCardId",
                        column: x => x.MagicCardId,
                        principalTable: "MagicCards",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CardTypeMagicCard_MagicCardsId",
                table: "CardTypeMagicCard",
                column: "MagicCardsId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicAbilityMagicCard_CardsId",
                table: "MagicAbilityMagicCard",
                column: "CardsId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCardMagicLegality_MagicLegalitiesId",
                table: "MagicCardMagicLegality",
                column: "MagicLegalitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCards_MagicSetId",
                table: "MagicCards",
                column: "MagicSetId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicCardSuperCardType_SuperCardTypesId",
                table: "MagicCardSuperCardType",
                column: "SuperCardTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_MagicRuling_MagicCardId",
                table: "MagicRuling",
                column: "MagicCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardTypeMagicCard");

            migrationBuilder.DropTable(
                name: "MagicAbilityMagicCard");

            migrationBuilder.DropTable(
                name: "MagicCardMagicLegality");

            migrationBuilder.DropTable(
                name: "MagicCardSuperCardType");

            migrationBuilder.DropTable(
                name: "MagicRuling");

            migrationBuilder.DropTable(
                name: "CardType");

            migrationBuilder.DropTable(
                name: "MagicAbility");

            migrationBuilder.DropTable(
                name: "MagicLegality");

            migrationBuilder.DropTable(
                name: "SuperCardType");

            migrationBuilder.DropTable(
                name: "MagicCards");

            migrationBuilder.DropTable(
                name: "MagicSets");
        }
    }
}
