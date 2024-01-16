using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class ProfileImageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Images_ProfileImageId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_ProfileImageId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileImageId",
                table: "Profiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Images",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProfileId",
                table: "Images",
                column: "ProfileId",
                unique: true,
                filter: "[ProfileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Profiles_ProfileId",
                table: "Images",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Profiles_ProfileId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ProfileId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Images");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileImageId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 46, 35, 467, DateTimeKind.Utc).AddTicks(2640));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 46, 35, 467, DateTimeKind.Utc).AddTicks(2644));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 46, 35, 467, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 46, 35, 467, DateTimeKind.Utc).AddTicks(2647));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 46, 35, 467, DateTimeKind.Utc).AddTicks(2649));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 21, 11, 46, 35, 467, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 21, 11, 46, 35, 467, DateTimeKind.Utc).AddTicks(1595), new DateTime(2023, 8, 21, 11, 46, 35, 467, DateTimeKind.Utc).AddTicks(1600), new byte[] { 107, 57, 79, 201, 27, 238, 73, 137, 242, 105, 222, 234, 16, 69, 153, 32, 229, 95, 221, 149, 233, 64, 70, 157, 38, 139, 191, 164, 21, 7, 90, 87, 116, 48, 13, 32, 111, 26, 93, 85, 4, 106, 255, 141, 169, 32, 95, 158, 60, 238, 177, 86, 123, 88, 39, 72, 182, 202, 218, 191, 217, 78, 34, 30 }, new byte[] { 75, 214, 186, 136, 234, 2, 55, 60, 4, 14, 117, 204, 211, 71, 6, 67, 55, 172, 72, 92, 255, 234, 197, 216, 198, 32, 234, 65, 167, 57, 155, 176, 127, 169, 241, 95, 152, 186, 253, 139, 161, 240, 212, 174, 69, 187, 22, 45, 252, 200, 234, 217, 211, 106, 82, 243, 224, 38, 106, 164, 251, 180, 181, 185, 206, 150, 116, 84, 252, 238, 6, 123, 252, 131, 183, 253, 233, 254, 168, 220, 70, 7, 151, 203, 251, 35, 35, 237, 213, 28, 109, 191, 24, 93, 89, 165, 207, 153, 96, 204, 47, 124, 181, 193, 41, 61, 159, 59, 130, 32, 118, 109, 166, 167, 247, 14, 215, 15, 127, 245, 87, 201, 191, 198, 202, 105, 71, 162 } });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_ProfileImageId",
                table: "Profiles",
                column: "ProfileImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Images_ProfileImageId",
                table: "Profiles",
                column: "ProfileImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
