using Microsoft.EntityFrameworkCore.Migrations;

namespace JustMVP.DAL.Migrations
{
    public partial class AddUserRobots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRobot_Robots_RobotId",
                table: "UserRobot");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRobot_AspNetUsers_UserId",
                table: "UserRobot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRobot",
                table: "UserRobot");

            migrationBuilder.RenameTable(
                name: "UserRobot",
                newName: "UserRobots");

            migrationBuilder.RenameIndex(
                name: "IX_UserRobot_UserId",
                table: "UserRobots",
                newName: "IX_UserRobots_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRobots",
                table: "UserRobots",
                columns: new[] { "RobotId", "UserId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e9656141-f716-4ce8-854a-e551198c0d48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "70094eb7-36a2-4c90-bcb6-f80d773c41c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "af6932a2-49be-49d2-82d4-e25913de6510", "AQAAAAEAACcQAAAAEI/IpBJKe6mYUxafsD+/2qMa+9RtoFSpoAj0vMxH8QEGgODjRkAvajRsw6gPijNmsA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "999faf2f-5ea8-4aac-be31-671ddecde4e3", "AQAAAAEAACcQAAAAENYaZHVNz+gQrLZs+PSzbkyM54w/wGdpta1LaQiiCXTR1bjbT5z6olxj9zXOV5pybg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ffbdf70e-84df-439a-9ec6-9a1f97373b01", "AQAAAAEAACcQAAAAEKnnpVIgibcHXPmtg6nwPrZBJF/wWxsoVxAKSzu21qEDmeae5Dj0OqI0eSAXW4Hw0Q==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRobots_Robots_RobotId",
                table: "UserRobots",
                column: "RobotId",
                principalTable: "Robots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRobots_AspNetUsers_UserId",
                table: "UserRobots",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRobots_Robots_RobotId",
                table: "UserRobots");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRobots_AspNetUsers_UserId",
                table: "UserRobots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRobots",
                table: "UserRobots");

            migrationBuilder.RenameTable(
                name: "UserRobots",
                newName: "UserRobot");

            migrationBuilder.RenameIndex(
                name: "IX_UserRobots_UserId",
                table: "UserRobot",
                newName: "IX_UserRobot_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRobot",
                table: "UserRobot",
                columns: new[] { "RobotId", "UserId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserRobot_Robots_RobotId",
                table: "UserRobot",
                column: "RobotId",
                principalTable: "Robots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRobot_AspNetUsers_UserId",
                table: "UserRobot",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
