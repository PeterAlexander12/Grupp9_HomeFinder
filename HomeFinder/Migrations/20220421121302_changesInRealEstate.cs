using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeFinder.Migrations
{
    public partial class changesInRealEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FormOfLease",
                table: "RealEstate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LotArea",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubsidiaryArea",
                table: "RealEstate",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormOfLease",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "LotArea",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "SubsidiaryArea",
                table: "RealEstate");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
