using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BattleID",
                table: "Samurais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    BattleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.BattleID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Battles_BattleID",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_BattleID",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "BattleID",
                table: "Samurais");
        }
    }
}
