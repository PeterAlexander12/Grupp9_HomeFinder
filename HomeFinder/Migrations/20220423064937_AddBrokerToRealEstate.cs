using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeFinder.Migrations
{
    public partial class AddBrokerToRealEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrokerId",
                table: "RealEstate",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_BrokerId",
                table: "RealEstate",
                column: "BrokerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_AspNetUsers_BrokerId",
                table: "RealEstate",
                column: "BrokerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_AspNetUsers_BrokerId",
                table: "RealEstate");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_BrokerId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "RealEstate");
        }
    }
}
