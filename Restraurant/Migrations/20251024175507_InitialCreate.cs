using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restraurant.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dishIngredients",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishIngredients", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_dishIngredients_dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dishIngredients_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dishes",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://example.com/spaghetti.jpg", "Spaghetti Bolognese", 12.99m },
                    { 2, "https://example.com/caesar.jpg", "Caesar Salad", 8.99m },
                    { 3, "https://example.com/margherita.jpg", "Margherita Pizza", 10.99m }
                });

            migrationBuilder.InsertData(
                table: "ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Spaghetti" },
                    { 2, "Ground Beef" },
                    { 3, "Tomato Sauce" },
                    { 4, "Lettuce" },
                    { 5, "Croutons" },
                    { 6, "Caesar Dressing" },
                    { 7, "Pizza Dough" },
                    { 8, "Tomato" },
                    { 9, "Mozzarella Cheese" }
                });

            migrationBuilder.InsertData(
                table: "dishIngredients",
                columns: new[] { "DishId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_dishIngredients_IngredientId",
                table: "dishIngredients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dishIngredients");

            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "ingredients");
        }
    }
}
