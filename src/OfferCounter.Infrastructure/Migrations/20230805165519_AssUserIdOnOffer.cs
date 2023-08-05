using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferCounter.Infrastructure.Migrations
{
    public partial class AssUserIdOnOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CrationDate",
                table: "Offer",
                newName: "CreationDate");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Offer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Offer");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Offer",
                newName: "CrationDate");
        }
    }
}
