using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Battles_BattleID",
                table: "Samurais");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_BattleID",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "BattleID",
                table: "Samurais");

            migrationBuilder.CreateTable(
                name: "BattleSamurai",
                columns: table => new
                {
                    BattlesBattleID = table.Column<int>(type: "int", nullable: false),
                    SamuraisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleSamurai", x => new { x.BattlesBattleID, x.SamuraisId });
                    table.ForeignKey(
                        name: "FK_BattleSamurai_Battles_BattlesBattleID",
                        column: x => x.BattlesBattleID,
                        principalTable: "Battles",
                        principalColumn: "BattleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BattleSamurai_Samurais_SamuraisId",
                        column: x => x.SamuraisId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleSamurai_SamuraisId",
                table: "BattleSamurai",
                column: "SamuraisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleSamurai");

            migrationBuilder.AddColumn<int>(
                name: "BattleID",
                table: "Samurais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_BattleID",
                table: "Samurais",
                column: "BattleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Battles_BattleID",
                table: "Samurais",
                column: "BattleID",
                principalTable: "Battles",
                principalColumn: "BattleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
