using System;
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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

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
                    GreenHouse = table.Column<bool>(type: "bit", nullable: false),
                    IsPayment = table.Column<bool>(type: "bit", nullable: false)
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
                name: "HumTimeOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HumidifierOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FanOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DehydratorOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProtectorOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegulatorOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HygrometerOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumTimeOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HumTimeOffs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HumTimeOns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HumidifierOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FanOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DehydratorOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProtectorOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RegulatorOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HygrometerOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumTimeOns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HumTimeOns_Users_UserId",
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
                name: "LightTimeOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimmerOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LampLightOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LedLampOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurtainsOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JalousieOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReflectorOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightTimeOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LightTimeOffs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LightTimeOns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimmerOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LampLightOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LedLampOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurtainsOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JalousieOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReflectorOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightTimeOns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LightTimeOns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
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
                name: "TempsTimeOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatteryOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KotelOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BottomOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaminOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObigrivOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CondOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LampOff = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempsTimeOffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempsTimeOffs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TempsTimeOns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatteryOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KotelOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BottomOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KaminOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObigrivOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CondOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LampOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempsTimeOns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempsTimeOns_Users_UserId",
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
                name: "IX_HumTimeOffs_UserId",
                table: "HumTimeOffs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HumTimeOns_UserId",
                table: "HumTimeOns",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lights_UserId",
                table: "Lights",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LightTimeOffs_UserId",
                table: "LightTimeOffs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LightTimeOns_UserId",
                table: "LightTimeOns",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Temps_UserId",
                table: "Temps",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TempsTimeOffs_UserId",
                table: "TempsTimeOffs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TempsTimeOns_UserId",
                table: "TempsTimeOns",
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
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Humidities");

            migrationBuilder.DropTable(
                name: "HumTimeOffs");

            migrationBuilder.DropTable(
                name: "HumTimeOns");

            migrationBuilder.DropTable(
                name: "Lights");

            migrationBuilder.DropTable(
                name: "LightTimeOffs");

            migrationBuilder.DropTable(
                name: "LightTimeOns");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Temps");

            migrationBuilder.DropTable(
                name: "TempsTimeOffs");

            migrationBuilder.DropTable(
                name: "TempsTimeOns");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
