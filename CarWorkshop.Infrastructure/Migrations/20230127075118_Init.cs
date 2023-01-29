using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarWorkshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactDetailsPhoneNumber = table.Column<string>(name: "ContactDetails_PhoneNumber", type: "nvarchar(max)", nullable: true),
                    ContactDetailsStreet = table.Column<string>(name: "ContactDetails_Street", type: "nvarchar(max)", nullable: true),
                    ContactDetailsCity = table.Column<string>(name: "ContactDetails_City", type: "nvarchar(max)", nullable: true),
                    ContactDetailsPostalCode = table.Column<string>(name: "ContactDetails_PostalCode", type: "nvarchar(max)", nullable: true),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWorkshops", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarWorkshops");
        }
    }
}
