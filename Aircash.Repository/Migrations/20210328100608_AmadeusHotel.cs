using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aircash.Repository.Migrations
{
    public partial class AmadeusHotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Description",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HotelId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChainCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    DescriptionID = table.Column<int>(type: "int", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hotel_Address_AddressID",
                        column: x => x.AddressID,
                        principalSchema: "dbo",
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotel_Description_DescriptionID",
                        column: x => x.DescriptionID,
                        principalSchema: "dbo",
                        principalTable: "Description",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceID = table.Column<int>(type: "int", nullable: true),
                    HotelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offer_Hotel_HotelID",
                        column: x => x.HotelID,
                        principalSchema: "dbo",
                        principalTable: "Hotel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offer_Price_PriceID",
                        column: x => x.PriceID,
                        principalSchema: "dbo",
                        principalTable: "Price",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_AddressID",
                schema: "dbo",
                table: "Hotel",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_DescriptionID",
                schema: "dbo",
                table: "Hotel",
                column: "DescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_HotelID",
                schema: "dbo",
                table: "Offer",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_PriceID",
                schema: "dbo",
                table: "Offer",
                column: "PriceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Hotel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Price",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Description",
                schema: "dbo");
        }
    }
}
