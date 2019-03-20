using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketValidator.Migrations
{
    public partial class Added_EventNaam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventNaam",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventNaam",
                table: "Tickets");
        }
    }
}
