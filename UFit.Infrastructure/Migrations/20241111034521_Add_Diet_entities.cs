using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Diet_entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "diets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    goal = table.Column<string>(type: "text", nullable: false),
                    calories_min = table.Column<int>(type: "integer", nullable: false),
                    calories_max = table.Column<int>(type: "integer", nullable: false),
                    proteins_min = table.Column<int>(type: "integer", nullable: false),
                    proteins_max = table.Column<int>(type: "integer", nullable: false),
                    carbohydrates_min = table.Column<int>(type: "integer", nullable: false),
                    carbohydrates_max = table.Column<int>(type: "integer", nullable: false),
                    fats_min = table.Column<int>(type: "integer", nullable: false),
                    fats_max = table.Column<int>(type: "integer", nullable: false),
                    duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    diet_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    schedule_time = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meals", x => x.id);
                    table.ForeignKey(
                        name: "fk_meals_diets_diet_id",
                        column: x => x.diet_id,
                        principalTable: "diets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "food_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    meal_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    macronutrients_protein = table.Column<double>(type: "double precision", nullable: false),
                    macronutrients_carbohydrates = table.Column<double>(type: "double precision", nullable: false),
                    macronutrients_fat = table.Column<double>(type: "double precision", nullable: false),
                    quantity = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_food_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_food_items_meal_meal_id",
                        column: x => x.meal_id,
                        principalTable: "meals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_food_items_meal_id",
                table: "food_items",
                column: "meal_id");

            migrationBuilder.CreateIndex(
                name: "ix_meals_diet_id",
                table: "meals",
                column: "diet_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "food_items");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "diets");
        }
    }
}
