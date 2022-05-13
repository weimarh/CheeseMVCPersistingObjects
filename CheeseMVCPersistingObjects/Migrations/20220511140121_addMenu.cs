using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseMVCPersistingObjects.Migrations
{
    public partial class addMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheeseMenus",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    CheeseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheeseMenus", x => new { x.CheeseID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_CheeseMenus_Cheeses_CheeseID",
                        column: x => x.CheeseID,
                        principalTable: "Cheeses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheeseMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheeseMenus_MenuID",
                table: "CheeseMenus",
                column: "MenuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheeseMenus");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
