using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class CurrencyDataTypeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(8536));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(8542));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(8545));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrencyCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "CurrencyCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "CurrencyCode",
                value: "EUR");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(7341), new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(7342), new byte[] { 232, 174, 12, 28, 145, 157, 5, 150, 98, 96, 16, 155, 167, 206, 118, 151, 17, 71, 2, 193, 85, 122, 134, 15, 132, 202, 188, 49, 39, 229, 175, 88, 196, 119, 90, 99, 113, 125, 141, 105, 241, 164, 131, 201, 78, 103, 161, 155, 181, 239, 164, 163, 233, 201, 123, 221, 102, 183, 172, 205, 187, 154, 247, 73 }, new byte[] { 130, 243, 19, 29, 15, 160, 84, 127, 139, 164, 245, 235, 98, 0, 229, 225, 208, 217, 114, 20, 144, 113, 56, 19, 89, 35, 178, 61, 126, 24, 95, 36, 76, 116, 30, 181, 163, 252, 147, 89, 98, 225, 59, 251, 247, 104, 64, 57, 150, 219, 97, 146, 95, 160, 228, 104, 201, 110, 52, 66, 228, 131, 6, 148, 46, 142, 156, 209, 35, 247, 32, 79, 97, 88, 94, 133, 81, 58, 31, 22, 8, 6, 213, 15, 252, 135, 196, 202, 13, 136, 218, 173, 150, 55, 213, 143, 67, 188, 4, 17, 188, 245, 138, 223, 203, 149, 74, 53, 12, 126, 218, 223, 154, 213, 105, 116, 59, 204, 230, 160, 109, 146, 25, 118, 40, 62, 216, 54 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrencyCode",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CurrencyCode",
                value: "");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "CurrencyCode",
                value: "");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "CurrencyCode",
                value: "GBP");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 9, 9, 42, 53, 481, DateTimeKind.Utc).AddTicks(9873), new DateTime(2023, 8, 9, 9, 42, 53, 481, DateTimeKind.Utc).AddTicks(9873), new byte[] { 18, 11, 103, 112, 201, 113, 110, 206, 133, 130, 153, 229, 59, 210, 147, 52, 88, 244, 82, 162, 50, 252, 192, 117, 225, 88, 203, 203, 112, 84, 179, 167, 142, 106, 108, 44, 92, 37, 124, 194, 2, 43, 8, 53, 201, 167, 232, 202, 89, 46, 32, 65, 36, 33, 49, 188, 137, 245, 120, 132, 28, 2, 208, 143 }, new byte[] { 126, 39, 145, 208, 155, 221, 253, 117, 139, 190, 235, 12, 90, 222, 199, 70, 107, 83, 55, 220, 169, 211, 19, 163, 179, 223, 232, 165, 161, 15, 0, 68, 16, 139, 244, 244, 240, 14, 146, 81, 226, 233, 42, 6, 34, 238, 102, 2, 150, 161, 30, 32, 124, 6, 47, 179, 212, 3, 158, 17, 7, 214, 57, 115, 131, 153, 229, 88, 182, 102, 183, 146, 5, 138, 99, 114, 4, 197, 39, 165, 142, 218, 182, 30, 161, 158, 109, 173, 108, 7, 156, 89, 223, 48, 244, 22, 107, 70, 94, 122, 81, 93, 103, 184, 227, 22, 171, 249, 228, 24, 87, 151, 131, 205, 212, 92, 153, 227, 124, 246, 156, 255, 253, 238, 212, 32, 235, 104 } });
        }
    }
}
