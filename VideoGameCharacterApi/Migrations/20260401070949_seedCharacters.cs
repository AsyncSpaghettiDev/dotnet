using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameCharacterApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedCharacters : Migration
    {

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: ["Id", "Name", "Game", "Role"],
                values: new object[,]
                {
                    { 1, "Mario", "Super Mario Bros", "Hero" },
                    { 2, "Link", "The Legend of Zelda", "Hero" },
                    { 3, "Bowser", "Super Mario Bros", "Villain" },
                    { 4, "Zelda", "The Legend of Zelda", "Princess" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
