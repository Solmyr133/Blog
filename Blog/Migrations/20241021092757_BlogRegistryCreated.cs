using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    /// <inheritdoc />
    public partial class BlogRegistryCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogRegistry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BloggerId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogRegistry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogRegistry_Bloggers_BloggerId",
                        column: x => x.BloggerId,
                        principalTable: "Bloggers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BlogRegistry_BloggerId",
                table: "BlogRegistry",
                column: "BloggerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogRegistry");
        }
    }
}
