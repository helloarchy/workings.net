using Microsoft.EntityFrameworkCore.Migrations;

namespace workings.Server.Data.Migrations
{
    public partial class AddBlindProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlindModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BusinessClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    Customer = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Reference = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    CountBlinds = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<decimal>(type: "TEXT", nullable: false),
                    Height = table.Column<decimal>(type: "TEXT", nullable: false),
                    CountWidths = table.Column<int>(type: "INTEGER", nullable: false),
                    RailingId = table.Column<int>(type: "INTEGER", nullable: false),
                    RailingDepth = table.Column<decimal>(type: "TEXT", nullable: false),
                    StackType = table.Column<int>(type: "INTEGER", nullable: false),
                    WaterfallIncrements = table.Column<decimal>(type: "TEXT", nullable: false),
                    Reveal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Folds = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlindModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlindProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DefaultValuesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlindProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlindProfiles_BlindModel_DefaultValuesId",
                        column: x => x.DefaultValuesId,
                        principalTable: "BlindModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlindProfiles_DefaultValuesId",
                table: "BlindProfiles",
                column: "DefaultValuesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlindProfiles");

            migrationBuilder.DropTable(
                name: "BlindModel");
        }
    }
}
