using Microsoft.EntityFrameworkCore.Migrations;

namespace authf.Migrations
{
    public partial class fixesenum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ushort>(
                name: "Guard",
                table: "Accounts",
                nullable: false,
                defaultValue: (ushort)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guard",
                table: "Accounts");
        }
    }
}
