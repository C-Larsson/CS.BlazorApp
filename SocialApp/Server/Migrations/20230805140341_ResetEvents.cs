using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class ResetEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxAttendees",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(4925), new DateTime(2023, 8, 5, 14, 3, 41, 28, DateTimeKind.Utc).AddTicks(4927), new byte[] { 66, 161, 60, 133, 9, 113, 64, 133, 54, 84, 57, 10, 74, 13, 117, 131, 122, 136, 186, 90, 177, 172, 245, 192, 35, 104, 104, 74, 234, 11, 126, 244, 47, 51, 6, 187, 255, 1, 255, 129, 166, 189, 22, 255, 8, 237, 143, 179, 54, 113, 6, 195, 54, 55, 243, 54, 137, 2, 191, 241, 240, 109, 126, 64 }, new byte[] { 125, 7, 217, 214, 76, 222, 91, 51, 22, 224, 146, 69, 31, 74, 205, 128, 80, 16, 60, 223, 138, 139, 189, 193, 101, 105, 234, 49, 169, 131, 4, 55, 13, 97, 35, 203, 80, 82, 168, 190, 221, 171, 102, 185, 37, 21, 86, 200, 180, 20, 231, 0, 222, 6, 142, 73, 188, 115, 159, 231, 10, 158, 151, 142, 107, 161, 216, 58, 37, 168, 109, 120, 96, 162, 104, 222, 207, 82, 190, 142, 115, 144, 50, 113, 185, 203, 185, 136, 183, 89, 9, 252, 203, 231, 115, 55, 143, 44, 115, 50, 36, 121, 84, 81, 168, 98, 218, 188, 202, 181, 21, 79, 103, 47, 33, 191, 7, 222, 29, 213, 183, 153, 167, 98, 55, 108, 123, 235 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(7412));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(7417));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxAttendees",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(6431), new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(6433), new byte[] { 170, 28, 8, 200, 229, 158, 104, 83, 67, 117, 79, 56, 132, 3, 71, 151, 58, 95, 16, 167, 112, 124, 3, 75, 249, 16, 235, 174, 67, 22, 33, 134, 113, 134, 80, 61, 32, 74, 206, 138, 184, 177, 138, 222, 109, 243, 131, 151, 42, 161, 199, 185, 225, 109, 160, 45, 53, 248, 167, 68, 50, 249, 147, 45 }, new byte[] { 104, 85, 174, 155, 67, 178, 132, 209, 47, 130, 216, 210, 216, 96, 39, 120, 84, 155, 22, 179, 120, 66, 86, 13, 129, 37, 242, 119, 165, 27, 51, 32, 132, 47, 3, 184, 96, 225, 91, 168, 51, 163, 54, 152, 105, 130, 235, 192, 146, 91, 237, 43, 103, 132, 140, 235, 155, 86, 182, 105, 111, 229, 86, 69, 29, 143, 207, 46, 154, 37, 140, 38, 235, 208, 168, 64, 25, 192, 209, 249, 9, 143, 89, 80, 77, 183, 164, 254, 138, 238, 122, 97, 40, 133, 185, 124, 19, 102, 124, 197, 104, 131, 131, 40, 6, 41, 227, 91, 223, 238, 86, 168, 172, 243, 210, 247, 224, 24, 87, 129, 9, 31, 32, 3, 209, 192, 49, 197 } });
        }
    }
}
