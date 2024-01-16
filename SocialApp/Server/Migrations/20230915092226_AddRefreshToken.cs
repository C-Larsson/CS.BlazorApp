using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class AddRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenCreated",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpires",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt", "RefreshToken" },
                values: new object[] { new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(626), new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(629), new byte[] { 125, 182, 248, 125, 181, 86, 180, 205, 24, 66, 196, 14, 149, 216, 68, 165, 139, 171, 220, 155, 163, 227, 140, 76, 24, 213, 79, 191, 139, 234, 45, 63, 21, 126, 8, 220, 63, 125, 186, 128, 61, 5, 43, 52, 203, 17, 114, 195, 243, 5, 209, 138, 4, 71, 127, 81, 197, 61, 163, 15, 175, 211, 140, 212 }, new byte[] { 159, 177, 61, 32, 193, 203, 50, 91, 34, 167, 110, 116, 110, 122, 150, 182, 61, 19, 55, 75, 245, 95, 93, 86, 19, 232, 157, 26, 92, 65, 56, 200, 44, 127, 42, 154, 16, 217, 120, 94, 95, 115, 143, 89, 249, 25, 153, 238, 189, 73, 176, 169, 234, 238, 157, 172, 94, 157, 167, 24, 46, 16, 146, 100, 99, 89, 55, 211, 231, 161, 47, 166, 174, 170, 91, 210, 249, 59, 98, 183, 51, 146, 91, 158, 116, 242, 166, 73, 246, 136, 41, 251, 186, 95, 128, 159, 134, 244, 189, 243, 95, 220, 144, 90, 144, 116, 164, 190, 50, 21, 204, 176, 231, 195, 45, 254, 195, 37, 27, 205, 231, 177, 134, 246, 146, 169, 47, 186 }, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenCreated",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenExpires",
                table: "Users");

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
    }
}
