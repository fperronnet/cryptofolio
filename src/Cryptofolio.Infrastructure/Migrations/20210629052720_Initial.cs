﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Cryptofolio.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asset",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    symbol = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asset", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asset");
        }
    }
}
