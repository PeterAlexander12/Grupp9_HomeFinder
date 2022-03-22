using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeFinder.Migrations
{
    public partial class multipleImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstateImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealEstateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateImages_RealEstate_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateImages_RealEstateId",
                table: "RealEstateImages",
                column: "RealEstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateImages");
        }
    }
}
