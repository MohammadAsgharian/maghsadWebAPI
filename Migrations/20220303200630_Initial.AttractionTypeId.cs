using Microsoft.EntityFrameworkCore.Migrations;

namespace maghsadAPI.Migrations
{
    public partial class InitialAttractionTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_AttractionType_AttractionId",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "AttractionId",
                table: "Places",
                newName: "AttractionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_AttractionId",
                table: "Places",
                newName: "IX_Places_AttractionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_AttractionType_AttractionTypeId",
                table: "Places",
                column: "AttractionTypeId",
                principalTable: "AttractionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_AttractionType_AttractionTypeId",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "AttractionTypeId",
                table: "Places",
                newName: "AttractionId");

            migrationBuilder.RenameIndex(
                name: "IX_Places_AttractionTypeId",
                table: "Places",
                newName: "IX_Places_AttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_AttractionType_AttractionId",
                table: "Places",
                column: "AttractionId",
                principalTable: "AttractionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
