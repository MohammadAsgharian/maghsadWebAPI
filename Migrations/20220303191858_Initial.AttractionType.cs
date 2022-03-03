using Microsoft.EntityFrameworkCore.Migrations;

namespace maghsadAPI.Migrations
{
    public partial class InitialAttractionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AttractionId",
                table: "Places",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttractionType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_AttractionId",
                table: "Places",
                column: "AttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_AttractionType_AttractionId",
                table: "Places",
                column: "AttractionId",
                principalTable: "AttractionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_AttractionType_AttractionId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "AttractionType");

            migrationBuilder.DropIndex(
                name: "IX_Places_AttractionId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "AttractionId",
                table: "Places");
        }
    }
}
