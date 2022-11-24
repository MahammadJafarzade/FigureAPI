using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class CreateCircleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Radius = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoordinateX = table.Column<double>(type: "float", nullable: false),
                    CoordinateY = table.Column<double>(type: "float", nullable: false),
                    CircleId = table.Column<int>(type: "int", nullable: true),
                    RectangleId = table.Column<int>(type: "int", nullable: true),
                    SquareId = table.Column<int>(type: "int", nullable: true),
                    TriangleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_Circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "Circles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rectangles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SideA = table.Column<double>(type: "float", nullable: false),
                    SideB = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rectangles_Points_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squares_Points_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Triangles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SideA = table.Column<double>(type: "float", nullable: false),
                    SideB = table.Column<double>(type: "float", nullable: false),
                    SideC = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    CenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Triangles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Triangles_Points_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Points",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circles_CenterId",
                table: "Circles",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_CircleId",
                table: "Points",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_RectangleId",
                table: "Points",
                column: "RectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_SquareId",
                table: "Points",
                column: "SquareId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_TriangleId",
                table: "Points",
                column: "TriangleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_CenterId",
                table: "Rectangles",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Squares_CenterId",
                table: "Squares",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Triangles_CenterId",
                table: "Triangles",
                column: "CenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circles_Points_CenterId",
                table: "Circles",
                column: "CenterId",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Rectangles_RectangleId",
                table: "Points",
                column: "RectangleId",
                principalTable: "Rectangles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Squares_SquareId",
                table: "Points",
                column: "SquareId",
                principalTable: "Squares",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Triangles_TriangleId",
                table: "Points",
                column: "TriangleId",
                principalTable: "Triangles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circles_Points_CenterId",
                table: "Circles");

            migrationBuilder.DropForeignKey(
                name: "FK_Rectangles_Points_CenterId",
                table: "Rectangles");

            migrationBuilder.DropForeignKey(
                name: "FK_Squares_Points_CenterId",
                table: "Squares");

            migrationBuilder.DropForeignKey(
                name: "FK_Triangles_Points_CenterId",
                table: "Triangles");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Circles");

            migrationBuilder.DropTable(
                name: "Rectangles");

            migrationBuilder.DropTable(
                name: "Squares");

            migrationBuilder.DropTable(
                name: "Triangles");
        }
    }
}
