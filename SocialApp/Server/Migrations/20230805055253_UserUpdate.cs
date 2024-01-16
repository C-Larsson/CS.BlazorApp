using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "LocationId", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(6431), new DateTime(2023, 8, 5, 5, 52, 52, 87, DateTimeKind.Utc).AddTicks(6433), null, new byte[] { 170, 28, 8, 200, 229, 158, 104, 83, 67, 117, 79, 56, 132, 3, 71, 151, 58, 95, 16, 167, 112, 124, 3, 75, 249, 16, 235, 174, 67, 22, 33, 134, 113, 134, 80, 61, 32, 74, 206, 138, 184, 177, 138, 222, 109, 243, 131, 151, 42, 161, 199, 185, 225, 109, 160, 45, 53, 248, 167, 68, 50, 249, 147, 45 }, new byte[] { 104, 85, 174, 155, 67, 178, 132, 209, 47, 130, 216, 210, 216, 96, 39, 120, 84, 155, 22, 179, 120, 66, 86, 13, 129, 37, 242, 119, 165, 27, 51, 32, 132, 47, 3, 184, 96, 225, 91, 168, 51, 163, 54, 152, 105, 130, 235, 192, 146, 91, 237, 43, 103, 132, 140, 235, 155, 86, 182, 105, 111, 229, 86, 69, 29, 143, 207, 46, 154, 37, 140, 38, 235, 208, 168, 64, 25, 192, 209, 249, 9, 143, 89, 80, 77, 183, 164, 254, 138, 238, 122, 97, 40, 133, 185, 124, 19, 102, 124, 197, 104, 131, 131, 40, 6, 41, 227, 91, 223, 238, 86, 168, 172, 243, 210, 247, 224, 24, 87, 129, 9, 31, 32, 3, 209, 192, 49, 197 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Adressess_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Adressess",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Adressess_AddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Users",
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
                value: new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(6218));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(6223));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(6224));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(6226));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(6239));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(6240));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "LocationId", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(5061), new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(5061), 2, new byte[] { 225, 154, 184, 41, 182, 41, 30, 99, 62, 230, 223, 150, 3, 221, 186, 85, 80, 69, 52, 90, 53, 26, 180, 150, 88, 191, 56, 52, 75, 163, 210, 160, 7, 48, 243, 164, 62, 210, 7, 206, 48, 191, 201, 89, 163, 113, 85, 128, 88, 68, 59, 253, 151, 86, 190, 11, 53, 149, 236, 117, 18, 75, 89, 108 }, new byte[] { 129, 197, 9, 134, 22, 253, 243, 249, 128, 151, 55, 91, 31, 191, 219, 186, 6, 183, 129, 249, 79, 54, 233, 22, 29, 130, 60, 41, 205, 134, 79, 28, 164, 21, 229, 7, 138, 58, 163, 62, 186, 123, 13, 230, 190, 66, 120, 253, 70, 96, 247, 243, 25, 155, 82, 191, 194, 127, 25, 248, 120, 209, 241, 219, 48, 177, 96, 99, 145, 117, 125, 27, 254, 131, 120, 57, 2, 90, 228, 90, 198, 176, 62, 235, 160, 107, 202, 212, 27, 90, 94, 42, 157, 52, 167, 203, 100, 165, 35, 246, 206, 221, 173, 221, 244, 216, 226, 120, 246, 110, 35, 168, 208, 115, 133, 119, 231, 168, 45, 79, 47, 138, 95, 111, 162, 82, 1, 74 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
