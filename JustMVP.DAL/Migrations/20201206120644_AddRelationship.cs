using Microsoft.EntityFrameworkCore.Migrations;

namespace JustMVP.DAL.Migrations
{
    public partial class AddRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Robots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserRobot",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RobotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRobot", x => new { x.RobotId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRobot_Robots_RobotId",
                        column: x => x.RobotId,
                        principalTable: "Robots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRobot_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0d877a53-312f-44c7-9d97-f0d446e84a48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0d438982-7ce2-430d-82c9-e9a0f92cc1c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19fdd3f1-6d20-41a9-9b97-35d02422415e", "AQAAAAEAACcQAAAAEBGy1b6Pe1+YHzrQkW9kzZVH+E0PCEc29FBINpgOsjLQqjPN3tmf+DIIoyWthtBh9w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6c155a93-da26-469c-9a54-68c2caaf43bd", "AQAAAAEAACcQAAAAEL5BapHzWlVxpk9g2M2W+5jn4m3MbngZ0TwQFPBqYnFVpKKygnUDF/iXy73pi7nzQA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "158b8b61-49cd-46ae-897a-bedb40a43671", "AQAAAAEAACcQAAAAELnBqoVmCHhARqEw6Ivd7KLumjGrhD0cs11RHtFRAuSZ5y+FbhT9ktrkzmRrNFbQiA==" });

            migrationBuilder.UpdateData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 1,
                column: "OwnerUserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 2,
                column: "OwnerUserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 3,
                column: "OwnerUserId",
                value: 3);

            migrationBuilder.InsertData(
                table: "UserRobot",
                columns: new[] { "RobotId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRobot_UserId",
                table: "UserRobot",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRobot");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Robots");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c940af7f-2e3d-457d-9467-5deb6e3e1687");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "65893ceb-6c95-4803-bb6e-d0bd26859506");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9702418c-bdcb-4c63-9905-1ebf59fb3ec9", "AQAAAAEAACcQAAAAEJo64qqBQrWUAWzknpho6tbBxpPpC99OmWjTesfqh9bCf6rIkyTSNkGY9ippvu59Lw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8063184b-4e2a-4d51-a0db-3bd38dc833db", "AQAAAAEAACcQAAAAEMFI8ROtjPdoYJmOENSh9JOKydDixeSF17efP59YpU7r5ULFbI70lB+BUUk8FqCItw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f61e0a84-0b68-4a2f-be5a-b482f7e6eda1", "AQAAAAEAACcQAAAAEGW/cKxAKCdAygxnh/DSfrD/ceZrowePqJhhrDELuABPbBgCMsFMoSJeJZTEwUTpTQ==" });
        }
    }
}
