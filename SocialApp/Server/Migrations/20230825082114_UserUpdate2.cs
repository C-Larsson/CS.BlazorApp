using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class UserUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Blocked",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 8, 21, 13, 286, DateTimeKind.Utc).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 8, 21, 13, 286, DateTimeKind.Utc).AddTicks(857));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 8, 21, 13, 286, DateTimeKind.Utc).AddTicks(858));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 8, 21, 13, 286, DateTimeKind.Utc).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 8, 21, 13, 286, DateTimeKind.Utc).AddTicks(861));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 25, 8, 21, 13, 286, DateTimeKind.Utc).AddTicks(863));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 25, 8, 21, 13, 285, DateTimeKind.Utc).AddTicks(9925), new DateTime(2023, 8, 25, 8, 21, 13, 285, DateTimeKind.Utc).AddTicks(9927), new byte[] { 254, 236, 136, 204, 144, 13, 198, 163, 190, 173, 58, 90, 237, 137, 62, 74, 248, 27, 148, 213, 68, 211, 180, 117, 27, 131, 203, 139, 231, 12, 1, 174, 0, 176, 153, 232, 146, 1, 250, 14, 80, 234, 5, 236, 17, 97, 92, 108, 64, 27, 16, 21, 228, 168, 112, 128, 66, 250, 225, 74, 145, 168, 179, 154 }, new byte[] { 181, 118, 76, 126, 167, 207, 105, 1, 68, 174, 139, 30, 251, 248, 144, 220, 191, 200, 210, 114, 236, 110, 166, 35, 66, 136, 76, 206, 48, 127, 248, 131, 109, 244, 177, 147, 221, 68, 89, 188, 24, 223, 154, 208, 233, 156, 38, 134, 49, 44, 92, 140, 125, 21, 159, 239, 176, 147, 205, 99, 161, 118, 90, 143, 114, 90, 84, 97, 211, 201, 103, 75, 29, 63, 253, 75, 92, 41, 188, 87, 150, 165, 66, 10, 109, 11, 202, 45, 249, 98, 93, 18, 233, 187, 36, 219, 221, 103, 200, 172, 187, 59, 94, 43, 171, 86, 239, 89, 156, 165, 21, 70, 130, 17, 144, 96, 84, 42, 191, 1, 32, 245, 247, 15, 128, 216, 72, 83 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 23, 3, 6, 12, 22, DateTimeKind.Utc).AddTicks(677));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 23, 3, 6, 12, 22, DateTimeKind.Utc).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 23, 3, 6, 12, 22, DateTimeKind.Utc).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 23, 3, 6, 12, 22, DateTimeKind.Utc).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 23, 3, 6, 12, 22, DateTimeKind.Utc).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 23, 3, 6, 12, 22, DateTimeKind.Utc).AddTicks(688));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 23, 3, 6, 12, 21, DateTimeKind.Utc).AddTicks(9677), new DateTime(2023, 8, 23, 3, 6, 12, 21, DateTimeKind.Utc).AddTicks(9683), new byte[] { 124, 172, 71, 151, 197, 220, 246, 198, 109, 220, 248, 43, 76, 102, 19, 203, 15, 85, 22, 33, 107, 81, 171, 230, 196, 104, 213, 50, 159, 125, 214, 93, 212, 26, 250, 208, 83, 49, 228, 182, 237, 97, 39, 120, 128, 65, 64, 248, 13, 69, 72, 15, 32, 155, 68, 43, 126, 204, 64, 139, 33, 49, 235, 254 }, new byte[] { 169, 74, 190, 31, 160, 55, 98, 76, 114, 20, 128, 153, 215, 205, 248, 82, 112, 205, 192, 201, 215, 54, 235, 211, 193, 241, 132, 166, 159, 236, 199, 19, 234, 195, 184, 160, 247, 75, 142, 89, 250, 142, 185, 182, 99, 179, 8, 197, 107, 236, 181, 214, 245, 194, 249, 114, 75, 38, 123, 84, 115, 104, 67, 140, 137, 200, 13, 84, 117, 55, 84, 67, 0, 220, 150, 47, 112, 62, 74, 192, 189, 19, 207, 173, 91, 119, 11, 198, 183, 26, 23, 160, 101, 213, 221, 80, 156, 45, 51, 19, 46, 221, 179, 225, 92, 138, 130, 114, 19, 203, 16, 160, 150, 52, 243, 226, 204, 226, 109, 214, 221, 91, 109, 187, 242, 207, 148, 105 } });
        }
    }
}
