using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeFinder.Migrations
{
    public partial class deletedFormOfLease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormOfLease",
                table: "RealEstate");

            migrationBuilder.RenameColumn(
                name: "Pictures",
                table: "RealEstate",
                newName: "CoverPictureURL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverPictureURL",
                table: "RealEstate",
                newName: "Pictures");

            migrationBuilder.AddColumn<string>(
                name: "FormOfLease",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
