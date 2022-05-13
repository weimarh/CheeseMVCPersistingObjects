using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheeseMVCPersistingObjects.Migrations
{
    public partial class CheeseCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Cheeses",
                newName: "CategoryId");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cheeses_CategoryId",
                table: "Cheeses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheeses_Categories_CategoryId",
                table: "Cheeses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheeses_Categories_CategoryId",
                table: "Cheeses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Cheeses_CategoryId",
                table: "Cheeses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Cheeses",
                newName: "Type");
        }
    }
}
