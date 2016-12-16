using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AlcoholApp.Migrations
{
    public partial class removeNight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Glasses_Nights_NightId",
                table: "Glasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Glasses",
                table: "Glasses");

            migrationBuilder.DropIndex(
                name: "IX_Glasses_NightId",
                table: "Glasses");

            migrationBuilder.DropColumn(
                name: "NightId",
                table: "Glasses");

            migrationBuilder.DropTable(
                name: "Nights");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Glasses",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Glasses",
                table: "Glasses",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Glasses",
                table: "Glasses");

            migrationBuilder.CreateTable(
                name: "Nights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndTime = table.Column<DateTime>(nullable: false),
                    IsDriving = table.Column<bool>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nights_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "NightId",
                table: "Glasses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Glasses",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Glasses",
                table: "Glasses",
                columns: new[] { "NightId", "AlcoholId" });

            migrationBuilder.CreateIndex(
                name: "IX_Glasses_NightId",
                table: "Glasses",
                column: "NightId");

            migrationBuilder.CreateIndex(
                name: "IX_Nights_UserId",
                table: "Nights",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Glasses_Nights_NightId",
                table: "Glasses",
                column: "NightId",
                principalTable: "Nights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
