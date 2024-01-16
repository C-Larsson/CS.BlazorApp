using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class UserUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7426));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7427));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(7430));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(6366), new DateTime(2023, 8, 31, 4, 1, 21, 837, DateTimeKind.Utc).AddTicks(6368), new byte[] { 10, 99, 49, 83, 58, 190, 13, 26, 17, 42, 20, 117, 145, 180, 207, 193, 181, 96, 103, 64, 158, 173, 57, 14, 229, 216, 86, 98, 241, 240, 87, 34, 18, 114, 54, 77, 133, 124, 140, 161, 99, 158, 254, 233, 93, 123, 110, 142, 131, 45, 239, 42, 100, 193, 52, 22, 128, 197, 21, 185, 169, 19, 159, 181 }, new byte[] { 148, 15, 86, 91, 217, 156, 161, 18, 144, 110, 165, 240, 200, 40, 235, 238, 16, 123, 147, 189, 195, 162, 4, 167, 210, 162, 142, 200, 156, 247, 38, 202, 174, 138, 24, 153, 38, 41, 86, 89, 28, 42, 138, 142, 79, 116, 131, 108, 153, 185, 175, 224, 165, 178, 249, 45, 124, 80, 4, 50, 136, 81, 251, 198, 216, 217, 238, 89, 138, 72, 46, 46, 151, 120, 163, 14, 185, 158, 250, 5, 132, 164, 162, 71, 194, 121, 68, 142, 106, 158, 130, 127, 186, 74, 32, 77, 32, 245, 87, 126, 33, 129, 128, 17, 199, 188, 243, 111, 47, 88, 28, 139, 106, 187, 131, 160, 12, 53, 246, 180, 112, 103, 37, 44, 176, 108, 156, 203 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId",
                unique: true,
                filter: "[ProfileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Users");

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

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
