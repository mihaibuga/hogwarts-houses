using Microsoft.EntityFrameworkCore.Migrations;

namespace HogwartsPotions.Migrations
{
    public partial class AddDefaultRoomsAndStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Capacity" },
                values: new object[,]
                {
                    { 1L, 2 },
                    { 2L, 2 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "HouseType", "Name", "PetType", "RoomID" },
                values: new object[,]
                {
                    { 1L, (byte)0, "Hermione Granger", (byte)1, null },
                    { 2L, (byte)3, "Draco Malfoy", (byte)3, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2L);
        }
    }
}
