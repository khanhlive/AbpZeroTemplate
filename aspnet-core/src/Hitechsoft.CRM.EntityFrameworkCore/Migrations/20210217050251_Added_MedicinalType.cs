using Microsoft.EntityFrameworkCore.Migrations;

namespace Hitechsoft.CRM.Migrations
{
    public partial class Added_MedicinalType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dic");

            migrationBuilder.RenameTable(
                name: "Ethnicities",
                newName: "Ethnicities",
                newSchema: "dic");

            migrationBuilder.CreateTable(
                name: "MedicinalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 12, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinalTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicinalTypes_TenantId",
                table: "MedicinalTypes",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicinalTypes");

            migrationBuilder.RenameTable(
                name: "Ethnicities",
                schema: "dic",
                newName: "Ethnicities");
        }
    }
}
