using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSystemOfMicroClimat.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    House = table.Column<bool>(type: "bit", nullable: false),
                    Flat = table.Column<bool>(type: "bit", nullable: false),
                    GreenHouse = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Humidities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Humidifier = table.Column<bool>(type: "bit", nullable: false),
                    Fan = table.Column<bool>(type: "bit", nullable: false),
                    Dehydrator = table.Column<bool>(type: "bit", nullable: false),
                    Protector = table.Column<bool>(type: "bit", nullable: false),
                    Regulator = table.Column<bool>(type: "bit", nullable: false),
                    Hygrometer = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humidities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Humidities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimmer = table.Column<bool>(type: "bit", nullable: false),
                    LampLight = table.Column<bool>(type: "bit", nullable: false),
                    LedLamp = table.Column<bool>(type: "bit", nullable: false),
                    Curtains = table.Column<bool>(type: "bit", nullable: false),
                    Jalousie = table.Column<bool>(type: "bit", nullable: false),
                    Reflector = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lights_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Battery = table.Column<bool>(type: "bit", nullable: false),
                    Kotel = table.Column<bool>(type: "bit", nullable: false),
                    Bottom = table.Column<bool>(type: "bit", nullable: false),
                    Kamin = table.Column<bool>(type: "bit", nullable: false),
                    Obigriv = table.Column<bool>(type: "bit", nullable: false),
                    Cond = table.Column<bool>(type: "bit", nullable: false),
                    Lamp = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temps_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    ValueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    Light = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.ValueID);
                    table.ForeignKey(
                        name: "FK_Values_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Humidities_UserId",
                table: "Humidities",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lights_UserId",
                table: "Lights",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Temps_UserId",
                table: "Temps",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Values_UserId",
                table: "Values",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humidities");

            migrationBuilder.DropTable(
                name: "Lights");

            migrationBuilder.DropTable(
                name: "Temps");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
