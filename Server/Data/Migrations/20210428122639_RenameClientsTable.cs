using Microsoft.EntityFrameworkCore.Migrations;

namespace workings.Server.Data.Migrations
{
    public partial class RenameClientsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "BusinessClients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessClients",
                table: "BusinessClients",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessClients",
                table: "BusinessClients");

            migrationBuilder.RenameTable(
                name: "BusinessClients",
                newName: "Clients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");
        }
    }
}
