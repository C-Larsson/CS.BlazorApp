using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class FeaturedEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Featured",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Featured",
                value: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Featured",
                value: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "Featured",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(2937), new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(2938), new byte[] { 128, 174, 89, 178, 160, 136, 217, 162, 29, 64, 172, 248, 108, 238, 227, 130, 104, 216, 253, 229, 80, 161, 239, 24, 136, 114, 16, 207, 205, 10, 221, 214, 30, 248, 121, 151, 128, 18, 40, 56, 38, 74, 228, 19, 191, 235, 42, 46, 138, 231, 1, 72, 57, 77, 42, 70, 172, 198, 245, 191, 119, 41, 87, 219 }, new byte[] { 52, 47, 64, 133, 71, 160, 23, 166, 194, 102, 44, 104, 59, 6, 39, 236, 94, 220, 124, 202, 8, 168, 15, 230, 222, 34, 114, 57, 162, 11, 204, 17, 43, 36, 151, 40, 246, 99, 253, 68, 62, 152, 164, 202, 225, 92, 88, 79, 186, 193, 135, 234, 87, 236, 202, 135, 46, 157, 75, 120, 62, 62, 224, 172, 134, 88, 125, 185, 50, 144, 36, 109, 21, 57, 186, 97, 160, 217, 89, 161, 195, 240, 238, 183, 141, 106, 236, 102, 178, 0, 254, 95, 87, 132, 175, 117, 219, 187, 37, 226, 206, 213, 179, 155, 136, 62, 19, 141, 234, 26, 211, 230, 219, 206, 229, 175, 231, 35, 246, 71, 77, 60, 127, 197, 110, 9, 185, 202 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Featured",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(6413), new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(6417), new byte[] { 17, 206, 148, 13, 195, 125, 137, 127, 167, 118, 225, 158, 40, 175, 206, 141, 173, 235, 139, 72, 17, 208, 99, 39, 242, 202, 69, 84, 0, 13, 253, 122, 180, 229, 125, 226, 34, 219, 159, 209, 251, 125, 216, 86, 35, 36, 30, 251, 79, 178, 110, 216, 45, 85, 158, 223, 88, 226, 9, 31, 134, 139, 168, 64 }, new byte[] { 207, 208, 165, 151, 147, 65, 176, 146, 125, 1, 75, 90, 24, 34, 15, 19, 71, 178, 6, 113, 176, 167, 165, 223, 105, 176, 33, 17, 68, 214, 51, 59, 33, 239, 110, 170, 243, 25, 8, 186, 134, 27, 88, 56, 245, 197, 186, 142, 180, 148, 183, 117, 89, 198, 135, 185, 71, 205, 122, 72, 151, 30, 127, 148, 171, 158, 50, 9, 68, 168, 23, 91, 170, 179, 213, 52, 224, 180, 209, 248, 1, 117, 2, 74, 20, 105, 26, 6, 198, 202, 185, 50, 147, 153, 72, 21, 110, 238, 115, 126, 123, 140, 110, 227, 196, 138, 171, 144, 37, 122, 23, 100, 73, 238, 216, 11, 85, 185, 60, 122, 222, 86, 229, 212, 191, 152, 37, 7 } });
        }
    }
}
