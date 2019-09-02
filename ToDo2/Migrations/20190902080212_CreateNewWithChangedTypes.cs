using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasklist.Migrations
{
    public partial class CreateNewWithChangedTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifiedOnUtc = table.Column<DateTimeOffset>(nullable: false),
                    CreatedOnUtc = table.Column<DateTimeOffset>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
