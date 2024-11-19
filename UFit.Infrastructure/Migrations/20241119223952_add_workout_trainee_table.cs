using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_workout_trainee_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_completed",
                table: "workouts");

            migrationBuilder.CreateTable(
                name: "workout_trainees",
                columns: table => new
                {
                    workout_id = table.Column<Guid>(type: "uuid", nullable: false),
                    trainee_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workout_trainees", x => new { x.workout_id, x.trainee_id });
                    table.ForeignKey(
                        name: "fk_workout_trainees_trainees_trainee_id",
                        column: x => x.trainee_id,
                        principalTable: "trainees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workout_trainees_workouts_workout_id",
                        column: x => x.workout_id,
                        principalTable: "workouts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workout_trainees_trainee_id",
                table: "workout_trainees",
                column: "trainee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workout_trainees");

            migrationBuilder.AddColumn<bool>(
                name: "is_completed",
                table: "workouts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
