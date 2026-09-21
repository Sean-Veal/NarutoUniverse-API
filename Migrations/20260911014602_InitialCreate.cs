using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Naruto_Universe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NArcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NArcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NChakraNatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NChakraNatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NClans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NClans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NJutsuClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NJutsuClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NKekkeiGenkais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NKekkeiGenkais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NMediae",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntryIndex = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    MediaType = table.Column<int>(type: "integer", nullable: false),
                    NArcId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NMediae", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NMediae_NArcs_NArcId",
                        column: x => x.NArcId,
                        principalTable: "NArcs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NVillages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVillages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NVillages_NCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "NCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NCharacters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    VillageStatus = table.Column<int>(type: "integer", nullable: true),
                    KekkeiGenkaiId = table.Column<int>(type: "integer", nullable: true),
                    ClanId = table.Column<int>(type: "integer", nullable: true),
                    VillageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NCharacters_NClans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "NClans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NCharacters_NKekkeiGenkais_KekkeiGenkaiId",
                        column: x => x.KekkeiGenkaiId,
                        principalTable: "NKekkeiGenkais",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NCharacters_NVillages_VillageId",
                        column: x => x.VillageId,
                        principalTable: "NVillages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NChakraNatureNCharacter",
                columns: table => new
                {
                    ChakraNaturesId = table.Column<int>(type: "integer", nullable: false),
                    NCharactersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NChakraNatureNCharacter", x => new { x.ChakraNaturesId, x.NCharactersId });
                    table.ForeignKey(
                        name: "FK_NChakraNatureNCharacter_NChakraNatures_ChakraNaturesId",
                        column: x => x.ChakraNaturesId,
                        principalTable: "NChakraNatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NChakraNatureNCharacter_NCharacters_NCharactersId",
                        column: x => x.NCharactersId,
                        principalTable: "NCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NCharacterNMedia",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "integer", nullable: false),
                    MediaListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCharacterNMedia", x => new { x.CharactersId, x.MediaListId });
                    table.ForeignKey(
                        name: "FK_NCharacterNMedia_NCharacters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "NCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCharacterNMedia_NMediae_MediaListId",
                        column: x => x.MediaListId,
                        principalTable: "NMediae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NJutsus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: true),
                    Classes = table.Column<int[]>(type: "integer[]", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NJutsus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NJutsus_NCharacters_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "NCharacters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NCharacterNJutsu",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "integer", nullable: false),
                    JutsusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCharacterNJutsu", x => new { x.CharactersId, x.JutsusId });
                    table.ForeignKey(
                        name: "FK_NCharacterNJutsu_NCharacters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "NCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCharacterNJutsu_NJutsus_JutsusId",
                        column: x => x.JutsusId,
                        principalTable: "NJutsus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NJutsuNJutsuClassification",
                columns: table => new
                {
                    JutsuClassificationsId = table.Column<int>(type: "integer", nullable: false),
                    JutsusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NJutsuNJutsuClassification", x => new { x.JutsuClassificationsId, x.JutsusId });
                    table.ForeignKey(
                        name: "FK_NJutsuNJutsuClassification_NJutsuClassifications_JutsuClass~",
                        column: x => x.JutsuClassificationsId,
                        principalTable: "NJutsuClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NJutsuNJutsuClassification_NJutsus_JutsusId",
                        column: x => x.JutsusId,
                        principalTable: "NJutsus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NJutsuNMedia",
                columns: table => new
                {
                    JutsusId = table.Column<int>(type: "integer", nullable: false),
                    MediaListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NJutsuNMedia", x => new { x.JutsusId, x.MediaListId });
                    table.ForeignKey(
                        name: "FK_NJutsuNMedia_NJutsus_JutsusId",
                        column: x => x.JutsusId,
                        principalTable: "NJutsus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NJutsuNMedia_NMediae_MediaListId",
                        column: x => x.MediaListId,
                        principalTable: "NMediae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NArcs_Name",
                table: "NArcs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NChakraNatureNCharacter_NCharactersId",
                table: "NChakraNatureNCharacter",
                column: "NCharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_NChakraNatures_Name",
                table: "NChakraNatures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NCharacterNJutsu_JutsusId",
                table: "NCharacterNJutsu",
                column: "JutsusId");

            migrationBuilder.CreateIndex(
                name: "IX_NCharacterNMedia_MediaListId",
                table: "NCharacterNMedia",
                column: "MediaListId");

            migrationBuilder.CreateIndex(
                name: "IX_NCharacters_ClanId",
                table: "NCharacters",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_NCharacters_KekkeiGenkaiId",
                table: "NCharacters",
                column: "KekkeiGenkaiId");

            migrationBuilder.CreateIndex(
                name: "IX_NCharacters_Name",
                table: "NCharacters",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NCharacters_VillageId",
                table: "NCharacters",
                column: "VillageId");

            migrationBuilder.CreateIndex(
                name: "IX_NClans_Name",
                table: "NClans",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NCountries_Name",
                table: "NCountries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NJutsuClassifications_Name",
                table: "NJutsuClassifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NJutsuNJutsuClassification_JutsusId",
                table: "NJutsuNJutsuClassification",
                column: "JutsusId");

            migrationBuilder.CreateIndex(
                name: "IX_NJutsuNMedia_MediaListId",
                table: "NJutsuNMedia",
                column: "MediaListId");

            migrationBuilder.CreateIndex(
                name: "IX_NJutsus_CreatorId",
                table: "NJutsus",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_NJutsus_Name",
                table: "NJutsus",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NKekkeiGenkais_Name",
                table: "NKekkeiGenkais",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NMediae_EntryIndex_MediaType",
                table: "NMediae",
                columns: new[] { "EntryIndex", "MediaType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NMediae_NArcId",
                table: "NMediae",
                column: "NArcId");

            migrationBuilder.CreateIndex(
                name: "IX_NVillages_CountryId",
                table: "NVillages",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_NVillages_Name",
                table: "NVillages",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NChakraNatureNCharacter");

            migrationBuilder.DropTable(
                name: "NCharacterNJutsu");

            migrationBuilder.DropTable(
                name: "NCharacterNMedia");

            migrationBuilder.DropTable(
                name: "NJutsuNJutsuClassification");

            migrationBuilder.DropTable(
                name: "NJutsuNMedia");

            migrationBuilder.DropTable(
                name: "NChakraNatures");

            migrationBuilder.DropTable(
                name: "NJutsuClassifications");

            migrationBuilder.DropTable(
                name: "NJutsus");

            migrationBuilder.DropTable(
                name: "NMediae");

            migrationBuilder.DropTable(
                name: "NCharacters");

            migrationBuilder.DropTable(
                name: "NArcs");

            migrationBuilder.DropTable(
                name: "NClans");

            migrationBuilder.DropTable(
                name: "NKekkeiGenkais");

            migrationBuilder.DropTable(
                name: "NVillages");

            migrationBuilder.DropTable(
                name: "NCountries");
        }
    }
}
