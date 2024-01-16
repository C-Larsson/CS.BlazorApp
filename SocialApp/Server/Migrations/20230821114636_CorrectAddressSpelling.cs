using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class CorrectAddressSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Adressess_AddressId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSeries_Adressess_AddressId",
                table: "EventSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Adressess_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Events_AddressId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adressess",
                table: "Adressess");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Adressess",
                newName: "Addresses");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

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
                name: "IX_Addresses_EventId",
                table: "Addresses",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSeries_Addresses_AddressId",
                table: "EventSeries",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Events_EventId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSeries_Addresses_AddressId",
                table: "EventSeries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_EventId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Adressess");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adressess",
                table: "Adressess",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

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
                name: "FK_EventSeries_Adressess_AddressId",
                table: "EventSeries",
                column: "AddressId",
                principalTable: "Adressess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Adressess_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Adressess",
                principalColumn: "Id");
        }
    }
}
