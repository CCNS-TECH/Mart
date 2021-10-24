using Microsoft.EntityFrameworkCore.Migrations;

namespace resm_app.Migrations
{
    public partial class v002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "CCNS_MenuPermission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "dbo",
                table: "CCNS_MenuPermission",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
