using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace maghsadAPI.Migrations
{
    public partial class InitialAddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLevels",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLevelID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    InstagramName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ActivationCodeEmail = table.Column<int>(type: "int", nullable: true),
                    ActivateSms = table.Column<int>(type: "int", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: true),
                    AvatarPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverPhotoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YourEarn = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserLevels_UserLevelID",
                        column: x => x.UserLevelID,
                        principalTable: "UserLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserLevelID",
                table: "Users",
                column: "UserLevelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserLevels");
        }
    }
}
