using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class UpdateToProfilesAndAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "Attendees",
                table: "Events",
                newName: "AttendeeCount");

            migrationBuilder.AddColumn<int>(
                name: "ProfilePicId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Adressess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfilePicId",
                table: "Profiles",
                column: "ProfilePicId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_AddressId",
                table: "Events",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Adressess_AddressId",
                table: "Events",
                column: "AddressId",
                principalTable: "Adressess",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Images_ProfilePicId",
                table: "Profiles",
                column: "ProfilePicId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Adressess_AddressId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Images_ProfilePicId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfilePicId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Events_AddressId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ProfilePicId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Adressess");

            migrationBuilder.RenameColumn(
                name: "AttendeeCount",
                table: "Events",
                newName: "Attendees");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

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
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(7341), new DateTime(2023, 8, 10, 11, 56, 4, 974, DateTimeKind.Utc).AddTicks(7342), new byte[] { 232, 174, 12, 28, 145, 157, 5, 150, 98, 96, 16, 155, 167, 206, 118, 151, 17, 71, 2, 193, 85, 122, 134, 15, 132, 202, 188, 49, 39, 229, 175, 88, 196, 119, 90, 99, 113, 125, 141, 105, 241, 164, 131, 201, 78, 103, 161, 155, 181, 239, 164, 163, 233, 201, 123, 221, 102, 183, 172, 205, 187, 154, 247, 73 }, new byte[] { 130, 243, 19, 29, 15, 160, 84, 127, 139, 164, 245, 235, 98, 0, 229, 225, 208, 217, 114, 20, 144, 113, 56, 19, 89, 35, 178, 61, 126, 24, 95, 36, 76, 116, 30, 181, 163, 252, 147, 89, 98, 225, 59, 251, 247, 104, 64, 57, 150, 219, 97, 146, 95, 160, 228, 104, 201, 110, 52, 66, 228, 131, 6, 148, 46, 142, 156, 209, 35, 247, 32, 79, 97, 88, 94, 133, 81, 58, 31, 22, 8, 6, 213, 15, 252, 135, 196, 202, 13, 136, 218, 173, 150, 55, 213, 143, 67, 188, 4, 17, 188, 245, 138, 223, 203, 149, 74, 53, 12, 126, 218, 223, 154, 213, 105, 116, 59, 204, 230, 160, 109, 146, 25, 118, 40, 62, 216, 54 } });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId");
        }
    }
}
