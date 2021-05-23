using Microsoft.EntityFrameworkCore.Migrations;

namespace workings.Server.Migrations
{
    public partial class AddBlindRod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlindRodId",
                table: "BlindModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BlindRod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Height = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlindRod", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlindModel_BlindRodId",
                table: "BlindModel",
                column: "BlindRodId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlindModel_BlindRod_BlindRodId",
                table: "BlindModel",
                column: "BlindRodId",
                principalTable: "BlindRod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlindModel_BlindRod_BlindRodId",
                table: "BlindModel");

            migrationBuilder.DropTable(
                name: "BlindRod");

            migrationBuilder.DropIndex(
                name: "IX_BlindModel_BlindRodId",
                table: "BlindModel");

            migrationBuilder.DropColumn(
                name: "BlindRodId",
                table: "BlindModel");
        }
    }
}
