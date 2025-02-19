using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalHeader_Customer_CustomerId1",
                table: "RentalHeader");

            migrationBuilder.DropIndex(
                name: "IX_RentalHeader_CustomerId1",
                table: "RentalHeader");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "RentalHeader");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Customer",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customer",
                newName: "FullName");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "RentalHeader",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalHeader_CustomerId1",
                table: "RentalHeader",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalHeader_Customer_CustomerId1",
                table: "RentalHeader",
                column: "CustomerId1",
                principalTable: "Customer",
                principalColumn: "CustomerId");
        }
    }
}
