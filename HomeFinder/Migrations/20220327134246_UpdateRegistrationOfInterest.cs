using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeFinder.Migrations
{
    public partial class UpdateRegistrationOfInterest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationOfInterest_RealEstate_RealEstateId1",
                table: "RegistrationOfInterest");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationOfInterest_RealEstateId1",
                table: "RegistrationOfInterest");

            migrationBuilder.DropColumn(
                name: "RealEstateId1",
                table: "RegistrationOfInterest");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "RegistrationOfInterest",
                newName: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "RealEstateId",
                table: "RegistrationOfInterest",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationOfInterest_RealEstateId",
                table: "RegistrationOfInterest",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationOfInterest_RealEstate_RealEstateId",
                table: "RegistrationOfInterest",
                column: "RealEstateId",
                principalTable: "RealEstate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrationOfInterest_RealEstate_RealEstateId",
                table: "RegistrationOfInterest");

            migrationBuilder.DropIndex(
                name: "IX_RegistrationOfInterest_RealEstateId",
                table: "RegistrationOfInterest");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "RegistrationOfInterest",
                newName: "UserName");

            migrationBuilder.AlterColumn<string>(
                name: "RealEstateId",
                table: "RegistrationOfInterest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RealEstateId1",
                table: "RegistrationOfInterest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationOfInterest_RealEstateId1",
                table: "RegistrationOfInterest",
                column: "RealEstateId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrationOfInterest_RealEstate_RealEstateId1",
                table: "RegistrationOfInterest",
                column: "RealEstateId1",
                principalTable: "RealEstate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
