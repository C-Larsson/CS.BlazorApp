using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class Refactoring2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Profiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "UserId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 8, 38, 37, 707, DateTimeKind.Utc).AddTicks(4935));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 8, 38, 37, 707, DateTimeKind.Utc).AddTicks(4939));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 8, 38, 37, 707, DateTimeKind.Utc).AddTicks(4940));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 8, 38, 37, 707, DateTimeKind.Utc).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 8, 38, 37, 707, DateTimeKind.Utc).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 2, 8, 38, 37, 707, DateTimeKind.Utc).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 9, 2, 8, 38, 37, 707, DateTimeKind.Utc).AddTicks(3542), new DateTime(2023, 9, 2, 8, 38, 37, 707, DateTimeKind.Utc).AddTicks(3546), new byte[] { 152, 20, 210, 210, 61, 44, 125, 22, 206, 226, 203, 201, 10, 169, 180, 203, 164, 8, 244, 34, 207, 6, 182, 88, 41, 7, 103, 176, 137, 25, 20, 41, 26, 193, 43, 181, 153, 48, 88, 28, 88, 244, 231, 124, 42, 103, 94, 118, 218, 226, 28, 46, 199, 75, 210, 57, 222, 83, 66, 110, 251, 75, 82, 48 }, new byte[] { 156, 29, 108, 186, 1, 153, 229, 217, 25, 34, 120, 97, 64, 197, 216, 139, 200, 202, 120, 232, 252, 165, 113, 42, 24, 87, 6, 250, 130, 243, 78, 160, 47, 185, 10, 31, 231, 67, 200, 135, 164, 16, 95, 199, 221, 245, 110, 186, 142, 6, 61, 60, 246, 39, 14, 121, 255, 12, 105, 20, 65, 206, 238, 249, 110, 88, 14, 62, 237, 210, 86, 152, 74, 24, 62, 32, 248, 166, 71, 130, 108, 219, 55, 154, 228, 101, 87, 177, 240, 92, 32, 170, 89, 199, 16, 151, 103, 21, 225, 136, 67, 48, 252, 35, 74, 204, 53, 158, 22, 207, 233, 65, 126, 196, 170, 180, 249, 39, 216, 177, 224, 216, 105, 182, 225, 205, 17, 129 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 9, 59, 12, 103, DateTimeKind.Utc).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 9, 59, 12, 103, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 9, 59, 12, 103, DateTimeKind.Utc).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 9, 59, 12, 103, DateTimeKind.Utc).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 9, 59, 12, 103, DateTimeKind.Utc).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 9, 59, 12, 103, DateTimeKind.Utc).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 31, 9, 59, 12, 103, DateTimeKind.Utc).AddTicks(3778), new DateTime(2023, 8, 31, 9, 59, 12, 103, DateTimeKind.Utc).AddTicks(3780), new byte[] { 70, 77, 43, 191, 1, 88, 86, 11, 150, 254, 207, 86, 180, 75, 99, 145, 88, 245, 111, 28, 232, 133, 222, 217, 174, 141, 142, 116, 184, 129, 146, 241, 248, 42, 23, 224, 211, 1, 110, 247, 168, 114, 113, 97, 110, 212, 60, 47, 139, 142, 30, 171, 127, 66, 6, 37, 5, 91, 9, 170, 90, 87, 246, 185 }, new byte[] { 162, 233, 31, 36, 144, 12, 240, 147, 57, 230, 72, 66, 171, 111, 183, 244, 245, 5, 0, 63, 216, 81, 147, 14, 68, 87, 46, 119, 224, 99, 64, 123, 237, 68, 110, 254, 177, 164, 130, 129, 56, 56, 165, 22, 112, 107, 238, 114, 239, 7, 183, 191, 45, 84, 246, 176, 37, 8, 220, 153, 189, 114, 155, 100, 193, 247, 232, 78, 216, 157, 120, 10, 206, 80, 244, 134, 1, 43, 108, 56, 68, 11, 232, 36, 124, 200, 2, 179, 251, 88, 197, 192, 143, 66, 19, 67, 162, 194, 249, 124, 239, 241, 55, 164, 255, 139, 251, 228, 143, 244, 66, 130, 108, 78, 21, 22, 209, 125, 203, 134, 168, 205, 118, 53, 211, 6, 36, 138 } });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);
        }
    }
}
