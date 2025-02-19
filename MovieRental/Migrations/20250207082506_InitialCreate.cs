using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieRental.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalDetail",
                table: "RentalDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "DateOnly",
                table: "RentalDetail");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "RentalDetail",
                newName: "RentalDetails");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "RentalDetails",
                newName: "RentalHeaderId");

            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "RentalDetails",
                newName: "RentalDetailId");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "RentalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalDetails",
                table: "RentalDetails",
                column: "RentalDetailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "CustomerId");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "RentalHeader",
                columns: table => new
                {
                    RentalHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalHeader", x => x.RentalHeaderId);
                    table.ForeignKey(
                        name: "FK_RentalHeader_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_MovieId",
                table: "RentalDetails",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalDetails_RentalHeaderId",
                table: "RentalDetails",
                column: "RentalHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalHeader_CustomerId",
                table: "RentalHeader",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_Movies_MovieId",
                table: "RentalDetails",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentalDetails_RentalHeader_RentalHeaderId",
                table: "RentalDetails",
                column: "RentalHeaderId",
                principalTable: "RentalHeader",
                principalColumn: "RentalHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_Movies_MovieId",
                table: "RentalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RentalDetails_RentalHeader_RentalHeaderId",
                table: "RentalDetails");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "RentalHeader");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalDetails",
                table: "RentalDetails");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetails_MovieId",
                table: "RentalDetails");

            migrationBuilder.DropIndex(
                name: "IX_RentalDetails_RentalHeaderId",
                table: "RentalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "RentalDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "RentalDetails",
                newName: "RentalDetail");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameColumn(
                name: "RentalHeaderId",
                table: "RentalDetail",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "RentalDetailId",
                table: "RentalDetail",
                newName: "RentalId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "RentalDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "RentalDetail",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RentalDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOnly",
                table: "RentalDetail",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalDetail",
                table: "RentalDetail",
                column: "RentalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "CustomerName");

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                });
        }
    }
}
