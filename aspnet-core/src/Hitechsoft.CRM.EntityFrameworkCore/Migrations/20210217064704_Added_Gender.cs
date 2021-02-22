using Microsoft.EntityFrameworkCore.Migrations;

namespace Hitechsoft.CRM.Migrations
{
    public partial class Added_Gender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "MedicinalTypes",
                newName: "MedicinalTypes",
                newSchema: "dic");

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 12, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gender_TenantId",
                table: "Gender",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.RenameTable(
                name: "MedicinalTypes",
                schema: "dic",
                newName: "MedicinalTypes");
        }
    }
}
