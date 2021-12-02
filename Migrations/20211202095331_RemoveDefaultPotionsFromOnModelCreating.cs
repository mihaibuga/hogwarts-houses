using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsPotions.Migrations
{
    public partial class RemoveDefaultPotionsFromOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Potions",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Potions",
                keyColumn: "ID",
                keyValue: 2L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Potions",
                columns: new[] { "ID", "BrewingStatus", "Name", "RecipeID", "StudentID" },
                values: new object[] { 1L, (byte)0, "Ageing Potion", null, null });

            migrationBuilder.InsertData(
                table: "Potions",
                columns: new[] { "ID", "BrewingStatus", "Name", "RecipeID", "StudentID" },
                values: new object[] { 2L, (byte)0, "Bruise removal paste", null, null });
        }
    }
}
