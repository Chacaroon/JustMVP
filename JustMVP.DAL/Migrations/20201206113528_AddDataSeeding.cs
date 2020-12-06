using Microsoft.EntityFrameworkCore.Migrations;

namespace JustMVP.DAL.Migrations
{
    public partial class AddDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Robots",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableForChildren",
                table: "Robots",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Jobs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "c940af7f-2e3d-457d-9467-5deb6e3e1687", "User", "USER" },
                    { 2, "65893ceb-6c95-4803-bb6e-d0bd26859506", "Child", "CHILD" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "9702418c-bdcb-4c63-9905-1ebf59fb3ec9", null, false, false, null, null, "USER1", "AQAAAAEAACcQAAAAEJo64qqBQrWUAWzknpho6tbBxpPpC99OmWjTesfqh9bCf6rIkyTSNkGY9ippvu59Lw==", null, false, null, false, "User1" },
                    { 2, 0, "8063184b-4e2a-4d51-a0db-3bd38dc833db", null, false, false, null, null, "USER2", "AQAAAAEAACcQAAAAEMFI8ROtjPdoYJmOENSh9JOKydDixeSF17efP59YpU7r5ULFbI70lB+BUUk8FqCItw==", null, false, null, false, "User2" },
                    { 3, 0, "f61e0a84-0b68-4a2f-be5a-b482f7e6eda1", null, false, false, null, null, "USER3", "AQAAAAEAACcQAAAAEGW/cKxAKCdAygxnh/DSfrD/ceZrowePqJhhrDELuABPbBgCMsFMoSJeJZTEwUTpTQ==", null, false, null, false, "User3" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Name", "Params" },
                values: new object[,]
                {
                    { 1, "Job 1", null },
                    { 2, "Job 2", null },
                    { 3, "Job 3", null }
                });

            migrationBuilder.InsertData(
                table: "Robots",
                columns: new[] { "Id", "AvailableForChildren", "BatteryLevel", "CurrentJobId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, true, 100, null, "Robot 1", 0 },
                    { 2, true, 100, null, "Robot 2", 0 },
                    { 3, true, 100, null, "Robot 3", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Robots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "AvailableForChildren",
                table: "Robots");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Robots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
