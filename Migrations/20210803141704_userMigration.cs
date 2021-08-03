using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksStore.Migrations
{
    public partial class userMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreditCardNumber",
                table: "User",
                newName: "CreditCardNumberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreditCardNumberId",
                table: "User",
                newName: "CreditCardNumber");
        }
    }
}
