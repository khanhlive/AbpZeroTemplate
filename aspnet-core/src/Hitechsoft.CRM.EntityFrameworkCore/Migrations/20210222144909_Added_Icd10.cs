using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hitechsoft.CRM.Migrations
{
    public partial class Added_Icd10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Icd10s",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    DiseaseChapterCode = table.Column<string>(maxLength: 10, nullable: true),
                    DiseaseChapterName = table.Column<string>(maxLength: 250, nullable: true),
                    WHOeName = table.Column<string>(maxLength: 500, nullable: true),
                    WHOName = table.Column<string>(maxLength: 500, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icd10s", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Icd10s_TenantId",
                table: "Icd10s",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Icd10s");
        }
    }
}
