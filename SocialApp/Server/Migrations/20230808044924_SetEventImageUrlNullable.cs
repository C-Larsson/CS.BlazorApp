using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class SetEventImageUrlNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
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
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(3632), new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(3636), new byte[] { 99, 8, 181, 3, 44, 1, 121, 161, 39, 250, 28, 123, 83, 158, 55, 138, 142, 24, 148, 80, 88, 19, 137, 216, 153, 217, 218, 90, 107, 199, 41, 238, 169, 148, 118, 139, 46, 220, 248, 92, 51, 232, 112, 108, 107, 186, 90, 71, 178, 116, 75, 153, 201, 244, 1, 177, 45, 131, 111, 144, 70, 212, 164, 137 }, new byte[] { 1, 166, 144, 234, 37, 102, 91, 208, 113, 47, 112, 95, 242, 75, 23, 196, 222, 54, 70, 215, 21, 208, 194, 30, 102, 200, 153, 25, 251, 16, 13, 185, 27, 121, 121, 216, 243, 81, 170, 211, 238, 225, 46, 237, 233, 24, 75, 119, 87, 223, 119, 127, 169, 80, 173, 106, 118, 34, 67, 68, 38, 67, 153, 190, 235, 144, 102, 51, 229, 43, 5, 72, 59, 222, 104, 18, 225, 227, 55, 93, 163, 74, 241, 219, 153, 184, 170, 133, 100, 197, 185, 115, 225, 214, 159, 170, 63, 244, 41, 212, 239, 98, 209, 116, 32, 177, 18, 209, 44, 222, 213, 242, 185, 250, 21, 118, 86, 184, 198, 32, 9, 142, 92, 178, 129, 143, 246, 68 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
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
                value: new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(4925), new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(4927), new byte[] { 66, 161, 60, 133, 9, 113, 64, 133, 54, 84, 57, 10, 74, 13, 117, 131, 122, 136, 186, 90, 177, 172, 245, 192, 35, 104, 104, 74, 234, 11, 126, 244, 47, 51, 6, 187, 255, 1, 255, 129, 166, 189, 22, 255, 8, 237, 143, 179, 54, 113, 6, 195, 54, 55, 243, 54, 137, 2, 191, 241, 240, 109, 126, 64 }, new byte[] { 125, 7, 217, 214, 76, 222, 91, 51, 22, 224, 146, 69, 31, 74, 205, 128, 80, 16, 60, 223, 138, 139, 189, 193, 101, 105, 234, 49, 169, 131, 4, 55, 13, 97, 35, 203, 80, 82, 168, 190, 221, 171, 102, 185, 37, 21, 86, 200, 180, 20, 231, 0, 222, 6, 142, 73, 188, 115, 159, 231, 10, 158, 151, 142, 107, 161, 216, 58, 37, 168, 109, 120, 96, 162, 104, 222, 207, 82, 190, 142, 115, 144, 50, 113, 185, 203, 185, 136, 183, 89, 9, 252, 203, 231, 115, 55, 143, 44, 115, 50, 36, 121, 84, 81, 168, 98, 218, 188, 202, 181, 21, 79, 103, 47, 33, 191, 7, 222, 29, 213, 183, 153, 167, 98, 55, 108, 123, 235 } });
        }
    }
}
