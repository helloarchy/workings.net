using Microsoft.EntityFrameworkCore.Migrations;

namespace workings.Server.Migrations
{
    public partial class UpdateProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlindRodId",
                table: "BlindProfile",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlindProfile_BlindRodId",
                table: "BlindProfile",
                column: "BlindRodId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlindProfile_BlindRod_BlindRodId",
                table: "BlindProfile",
                column: "BlindRodId",
                principalTable: "BlindRod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlindProfile_BlindRod_BlindRodId",
                table: "BlindProfile");

            migrationBuilder.DropIndex(
                name: "IX_BlindProfile_BlindRodId",
                table: "BlindProfile");

            migrationBuilder.DropColumn(
                name: "BlindRodId",
                table: "BlindProfile");
        }
    }
}
