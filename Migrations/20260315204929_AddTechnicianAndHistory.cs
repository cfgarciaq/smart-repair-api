using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartRepairApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTechnicianAndHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Repairs",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechnicianId",
                table: "Repairs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RepairHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RepairId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairHistories_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Specialization = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_TechnicianId",
                table: "Repairs",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairHistories_RepairId",
                table: "RepairHistories",
                column: "RepairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Technicians_TechnicianId",
                table: "Repairs",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Technicians_TechnicianId",
                table: "Repairs");

            migrationBuilder.DropTable(
                name: "RepairHistories");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_TechnicianId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "TechnicianId",
                table: "Repairs");
        }
    }
}
