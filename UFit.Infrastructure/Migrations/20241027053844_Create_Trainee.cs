using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UFit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_Trainee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "trainees",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name_first = table.Column<string>(type: "text", nullable: false),
                    name_last = table.Column<string>(type: "text", nullable: false),
                    measurements_height = table.Column<decimal>(type: "numeric", nullable: false),
                    measurements_weight = table.Column<decimal>(type: "numeric", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    fitness_goal = table.Column<string>(type: "text", nullable: false),
                    target_weight = table.Column<decimal>(type: "numeric", nullable: false),
                    points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainees", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_trainees_email",
                table: "trainees",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "trainees");
        }
    }
}
