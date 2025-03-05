using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignments.Migrations.Country
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GamesID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GamesID);
                });

            migrationBuilder.CreateTable(
                name: "SportsTypes",
                columns: table => new
                {
                    SportTypeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportsTypes", x => x.SportTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    countryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamesID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportTypeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.countryID);
                    table.ForeignKey(
                        name: "FK_Countries_Game_GamesID",
                        column: x => x.GamesID,
                        principalTable: "Game",
                        principalColumn: "GamesID");
                    table.ForeignKey(
                        name: "FK_Countries_SportsTypes_SportTypeID",
                        column: x => x.SportTypeID,
                        principalTable: "SportsTypes",
                        principalColumn: "SportTypeID");
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "GamesID", "Name" },
                values: new object[,]
                {
                    { "para", "para" },
                    { "sum", "summer" },
                    { "win", "winter" },
                    { "youth", "youth" }
                });

            migrationBuilder.InsertData(
                table: "SportsTypes",
                columns: new[] { "SportTypeID", "SportName" },
                values: new object[,]
                {
                    { "ar-in", "Archery/Indoor" },
                    { "bob-ou", "Bobsleigh/Outdoor" },
                    { "bre-in", "Breakdancing/Indoor" },
                    { "can-ou", "Canoe Sprint/Outdoor" },
                    { "cu-in", "Curling/Indoor" },
                    { "cy-ou", "Cycling/Outdoor" },
                    { "di-in", "Diving/Indoor" },
                    { "ro-ou", "Road Cycling/Outdoor" },
                    { "ska-ou", "Skateboarding/Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "countryID", "Flag", "GamesID", "SportTypeID", "countryName" },
                values: new object[,]
                {
                    { "aus", "Flag_of_Austria.png", "para", "can-ou", "Austria" },
                    { "bra", "Flag_of_Brazil.png", "sum", "ro-ou", "Brazil" },
                    { "bri", "Flag_of_the_United_Kingdom.png", "win", "cu-in", "United Kingdom" },
                    { "can", "Flag_of_Canada.png", "win", "cu-in", "Canada" },
                    { "chi", "Flag_of_the_People's_Republic_of_China.png", "sum", "di-in", "China" },
                    { "cyp", "Flag_of_Cyprus.png", "youth", "bre-in", "Cyprus" },
                    { "fin", "Flag_of_Finland.png", "youth", "ska-ou", "Finland" },
                    { "fra", "Flag_of_France.png", "youth", "bre-in", "France" },
                    { "ger", "Flag_of_Germany.png", "sum", "di-in", "Germany" },
                    { "ita", "Italy.png", "win", "bob-ou", "Italy" },
                    { "jam", "Flag_of_Jamaica.png", "win", "bob-ou", "Jamaica" },
                    { "jap", "Japan.png", "win", "bob-ou", "Japan" },
                    { "mex", "Flag_of_Mexico.png", "sum", "di-in", "Mexico" },
                    { "net", "Flag_of_the_Netherlands.png", "sum", "cy-ou", "Netherland" },
                    { "pak", "Flag_of_Pakistan.png", "para", "can-ou", "Pakistan" },
                    { "por", "Flag_of_Portugal.png", "youth", "ska-ou", "Portugal" },
                    { "rus", "Flag_of_Russia.png", "youth", "bre-in", "Russia" },
                    { "slo", "Flag_of_Slovakia.png", "youth", "ska-ou", "Slovakia" },
                    { "swe", "Sweden.png", "win", "cu-in", "Sweden" },
                    { "thai", "Flag_of_Thailand.png", "para", "ar-in", "Thailand" },
                    { "ukr", "Flag_of_Ukraine.png", "para", "ar-in", "Ukrain" },
                    { "uru", "Flag_of_Uruguay.png", "para", "ar-in", "Urugauy" },
                    { "usa", "Flag_of_the_United_States.png", "sum", "ro-ou", "United States" },
                    { "zim", "Flag_of_Zimbabwe.png", "para", "can-ou", "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GamesID",
                table: "Countries",
                column: "GamesID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportTypeID",
                table: "Countries",
                column: "SportTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "SportsTypes");
        }
    }
}
