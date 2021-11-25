using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsPotions.Migrations
{
    public partial class CreatePotionDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PotionID",
                table: "Ingredients",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Potions",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrewingStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    StudentID = table.Column<long>(type: "bigint", nullable: true),
                    RecipeID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Potions_Recipes_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Potions_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PotionID",
                table: "Ingredients",
                column: "PotionID");

            migrationBuilder.CreateIndex(
                name: "IX_Potions_RecipeID",
                table: "Potions",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Potions_StudentID",
                table: "Potions",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Potions_PotionID",
                table: "Ingredients",
                column: "PotionID",
                principalTable: "Potions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Potions_PotionID",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "Potions");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_PotionID",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "PotionID",
                table: "Ingredients");
        }
    }
}
