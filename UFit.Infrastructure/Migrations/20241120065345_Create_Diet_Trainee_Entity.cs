using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Diet_Trainee_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "diet_trainees",
                columns: table => new
                {
                    diet_id = table.Column<Guid>(type: "uuid", nullable: false),
                    trainee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diet_trainees", x => new { x.diet_id, x.trainee_id });
                    table.ForeignKey(
                        name: "fk_diet_trainees_diets_diet_id",
                        column: x => x.diet_id,
                        principalTable: "diets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_diet_trainees_trainees_trainee_id",
                        column: x => x.trainee_id,
                        principalTable: "trainees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_diet_trainees_trainee_id",
                table: "diet_trainees",
                column: "trainee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diet_trainees");
        }
    }
}
