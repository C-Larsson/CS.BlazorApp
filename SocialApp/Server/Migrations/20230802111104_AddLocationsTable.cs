using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class AddLocationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Location_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSeries_Location_LocationId",
                table: "EventSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Location_LocationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 11, 3, 649, DateTimeKind.Utc).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 11, 3, 649, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 11, 3, 649, DateTimeKind.Utc).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 11, 3, 649, DateTimeKind.Utc).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 11, 3, 649, DateTimeKind.Utc).AddTicks(559));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 11, 3, 649, DateTimeKind.Utc).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 2, 11, 11, 3, 648, DateTimeKind.Utc).AddTicks(9651), new DateTime(2023, 8, 2, 11, 11, 3, 648, DateTimeKind.Utc).AddTicks(9652), new byte[] { 80, 156, 9, 247, 32, 144, 190, 249, 148, 93, 171, 70, 64, 17, 105, 61, 6, 96, 29, 123, 222, 25, 86, 92, 177, 25, 118, 69, 175, 133, 247, 242, 107, 36, 15, 190, 162, 175, 130, 11, 204, 193, 36, 52, 37, 254, 104, 188, 120, 166, 151, 138, 169, 9, 168, 161, 216, 149, 45, 119, 71, 155, 47, 63 }, new byte[] { 170, 143, 153, 153, 109, 84, 230, 215, 161, 150, 124, 36, 40, 21, 25, 27, 207, 80, 87, 172, 163, 103, 206, 137, 3, 14, 215, 245, 169, 200, 236, 123, 88, 108, 116, 251, 139, 234, 238, 226, 69, 171, 242, 221, 44, 227, 70, 180, 24, 131, 232, 212, 94, 117, 44, 236, 169, 148, 117, 203, 132, 148, 247, 230, 70, 248, 102, 96, 189, 17, 133, 38, 150, 195, 250, 187, 179, 107, 41, 239, 25, 210, 76, 149, 228, 89, 87, 157, 215, 203, 128, 20, 6, 251, 177, 233, 235, 226, 156, 239, 117, 215, 156, 235, 12, 70, 140, 154, 42, 188, 37, 198, 158, 154, 171, 163, 246, 237, 56, 108, 170, 85, 157, 229, 5, 51, 113, 223 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSeries_Locations_LocationId",
                table: "EventSeries",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Locations_LocationId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSeries_Locations_LocationId",
                table: "EventSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Locations_LocationId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(238));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(246));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(247));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 8, 2, 147, DateTimeKind.Utc).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 2, 11, 8, 2, 146, DateTimeKind.Utc).AddTicks(9388), new DateTime(2023, 8, 2, 11, 8, 2, 146, DateTimeKind.Utc).AddTicks(9390), new byte[] { 22, 20, 238, 143, 82, 84, 138, 226, 142, 17, 183, 31, 247, 25, 174, 120, 151, 196, 98, 3, 21, 239, 247, 224, 215, 7, 91, 184, 115, 145, 100, 97, 83, 253, 20, 98, 101, 12, 163, 137, 235, 51, 138, 208, 151, 114, 132, 169, 11, 7, 140, 107, 6, 227, 120, 78, 44, 75, 66, 165, 8, 239, 180, 240 }, new byte[] { 92, 194, 195, 212, 73, 227, 141, 96, 89, 23, 73, 107, 175, 239, 55, 142, 82, 226, 233, 36, 254, 82, 249, 199, 98, 78, 130, 53, 143, 124, 131, 171, 119, 201, 160, 31, 73, 215, 77, 29, 18, 142, 41, 158, 36, 131, 38, 41, 89, 82, 22, 201, 183, 10, 89, 44, 104, 215, 99, 73, 29, 59, 171, 156, 129, 180, 65, 151, 181, 19, 161, 196, 60, 81, 142, 147, 252, 166, 129, 14, 223, 228, 149, 48, 247, 105, 1, 221, 119, 234, 193, 234, 90, 220, 222, 55, 7, 243, 123, 87, 136, 22, 38, 245, 165, 83, 121, 219, 92, 206, 30, 247, 244, 47, 4, 158, 154, 96, 100, 102, 159, 170, 32, 72, 216, 163, 5, 190 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Location_LocationId",
                table: "Events",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSeries_Location_LocationId",
                table: "EventSeries",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Location_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
