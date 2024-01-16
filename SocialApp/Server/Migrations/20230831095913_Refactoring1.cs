using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class Refactoring1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Profiles_ProfileId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfileId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProfileId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EventId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ProfileImageId",
                table: "Profiles",
                newName: "ImageId");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Events",
                type: "int",
                nullable: true);

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
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ImageId",
                table: "Profiles",
                column: "ImageId");

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
                name: "FK_Events_Addresses_AddressId",
                table: "Events",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Images_ImageId",
                table: "Profiles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Addresses_AddressId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Images_ImageId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ImageId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Events_AddressId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Profiles",
                newName: "ProfileImageId");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Addresses",
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

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProfileId",
                table: "Images",
                column: "ProfileId",
                unique: true,
                filter: "[ProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EventId",
                table: "Addresses",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Profiles_ProfileId",
                table: "Images",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Profiles_ProfileId",
                table: "Users",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
