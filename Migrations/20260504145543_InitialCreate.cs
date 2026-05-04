using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gruppe20App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organisasjoner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Organisasjonsnummer = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    Organisasjonsform = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisasjoner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RollePersoner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Rolle = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    OrganisasjonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollePersoner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollePersoner_Organisasjoner_OrganisasjonId",
                        column: x => x.OrganisasjonId,
                        principalTable: "Organisasjoner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RollePersoner_OrganisasjonId",
                table: "RollePersoner",
                column: "OrganisasjonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RollePersoner");

            migrationBuilder.DropTable(
                name: "Organisasjoner");
        }
    }
}
