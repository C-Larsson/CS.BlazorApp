using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class ChangeInProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Images_ProfilePicId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ProfilePicId",
                table: "Profiles",
                newName: "ProfileImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProfilePicId",
                table: "Profiles",
                newName: "IX_Profiles_ProfileImageId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 15, 21, 517, DateTimeKind.Utc).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 15, 21, 517, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 15, 21, 517, DateTimeKind.Utc).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 15, 21, 517, DateTimeKind.Utc).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 15, 21, 517, DateTimeKind.Utc).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 15, 21, 517, DateTimeKind.Utc).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 21, 11, 15, 21, 517, DateTimeKind.Utc).AddTicks(5094), new DateTime(2023, 8, 21, 11, 15, 21, 517, DateTimeKind.Utc).AddTicks(5096), new byte[] { 133, 124, 178, 108, 89, 68, 132, 207, 47, 243, 217, 101, 212, 183, 3, 48, 50, 120, 235, 45, 88, 99, 26, 218, 1, 221, 189, 73, 16, 2, 32, 123, 123, 67, 148, 53, 252, 82, 108, 7, 41, 35, 121, 186, 156, 5, 192, 139, 63, 6, 128, 57, 204, 49, 191, 90, 151, 20, 18, 207, 41, 138, 80, 58 }, new byte[] { 42, 220, 13, 148, 153, 255, 205, 104, 195, 247, 188, 233, 100, 62, 11, 119, 75, 224, 78, 161, 158, 2, 206, 177, 114, 245, 188, 81, 122, 57, 239, 237, 49, 123, 83, 117, 253, 25, 157, 179, 137, 198, 178, 41, 123, 10, 185, 66, 147, 119, 125, 166, 192, 96, 232, 210, 242, 241, 225, 247, 30, 149, 152, 97, 133, 72, 60, 151, 193, 40, 22, 23, 215, 11, 182, 185, 40, 203, 105, 68, 168, 51, 57, 160, 115, 230, 98, 254, 196, 72, 232, 114, 16, 67, 13, 172, 35, 199, 25, 70, 77, 254, 25, 139, 75, 255, 232, 131, 99, 1, 230, 33, 103, 150, 209, 143, 126, 182, 129, 252, 204, 247, 212, 143, 78, 227, 234, 89 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Images_ProfileImageId",
                table: "Profiles",
                column: "ProfileImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Images_ProfileImageId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ProfileImageId",
                table: "Profiles",
                newName: "ProfilePicId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_ProfileImageId",
                table: "Profiles",
                newName: "IX_Profiles_ProfilePicId");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 6, 50, 57, 173, DateTimeKind.Utc).AddTicks(8403));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 6, 50, 57, 173, DateTimeKind.Utc).AddTicks(8407));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 6, 50, 57, 173, DateTimeKind.Utc).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 6, 50, 57, 173, DateTimeKind.Utc).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 6, 50, 57, 173, DateTimeKind.Utc).AddTicks(8412));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 6, 50, 57, 173, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 21, 6, 50, 57, 173, DateTimeKind.Utc).AddTicks(7389), new DateTime(2023, 8, 21, 6, 50, 57, 173, DateTimeKind.Utc).AddTicks(7389), new byte[] { 163, 16, 99, 226, 0, 209, 100, 233, 127, 157, 198, 108, 106, 237, 144, 69, 16, 245, 59, 13, 176, 148, 97, 163, 211, 197, 7, 39, 155, 50, 177, 75, 131, 27, 215, 24, 12, 253, 26, 60, 226, 89, 123, 198, 153, 74, 87, 174, 128, 126, 198, 129, 158, 112, 180, 20, 7, 211, 253, 110, 162, 28, 93, 120 }, new byte[] { 19, 193, 46, 55, 246, 188, 206, 238, 247, 112, 127, 1, 201, 92, 18, 149, 143, 226, 126, 161, 99, 217, 189, 165, 100, 4, 241, 8, 95, 173, 76, 255, 113, 239, 227, 175, 12, 242, 120, 233, 220, 92, 136, 161, 79, 149, 213, 110, 130, 40, 118, 157, 128, 64, 131, 48, 180, 93, 147, 28, 228, 116, 62, 213, 195, 159, 213, 245, 185, 188, 196, 145, 51, 11, 57, 104, 70, 166, 0, 87, 237, 147, 41, 135, 14, 189, 123, 235, 235, 244, 233, 38, 168, 104, 5, 81, 189, 23, 9, 70, 137, 151, 79, 214, 149, 196, 93, 22, 117, 103, 101, 41, 255, 245, 131, 245, 220, 16, 95, 191, 32, 243, 236, 254, 110, 197, 219, 73 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Images_ProfilePicId",
                table: "Profiles",
                column: "ProfilePicId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
