using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace resm_app.Migrations
{
    public partial class v003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CCNS_SetPermission",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(35)", nullable: true),
                    Created_by = table.Column<long>(type: "bigint", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updated_by = table.Column<long>(type: "bigint", nullable: true),
                    Update_At = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNS_SetPermission", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CCNS_SetPermission",
                schema: "dbo");
        }
    }
}
