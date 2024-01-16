using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class AddLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Adressess_AddressId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Adressess_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Events_AddressId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "City", "Country", "CountryCode", "Latitude", "Longitude", "State" },
                values: new object[,]
                {
                    { 1, "New York City", "United States", "US", 40.7128m, -74.0060m, "" },
                    { 2, "Stockholm", "Sweden", "SE", 59.3293m, 18.0686m, "" },
                    { 3, "Bangkok", "Thailand", "TH", 13.7563m, 100.5018m, "" },
                    { 4, "Tokyo", "Japan", "JP", 35.6762m, 139.6503m, "" },
                    { 5, "London", "United Kingdom", "GB", 51.5074m, -0.1278m, "" },
                    { 6, "Paris", "France", "FR", 48.8566m, 2.3522m, "" },
                    { 7, "Berlin", "Germany", "DE", 52.5200m, 13.4050m, "" },
                    { 8, "Rome", "Italy", "IT", 41.9028m, 12.4964m, "" },
                    { 9, "Madrid", "Spain", "ES", 40.4168m, -3.7038m, "" },
                    { 10, "Singapore", "Singapore", "SG", 1.3521m, 103.8198m, "" },
                    { 11, "Hong Kong", "Hong Kong", "HK", 22.3193m, 114.1694m, "" },
                    { 12, "Dubai", "United Arab Emirates", "AE", 25.2048m, 55.2708m, "" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CreatedDate", "Email", "EventId", "LastActive", "LocationId", "Name", "PasswordHash", "PasswordSalt", "Role" },
                values: new object[] { 1, null, new DateTime(2023, 8, 2, 11, 8, 2, 146, DateTimeKind.Utc).AddTicks(9388), "larsson.christoffer@gmail.com", null, new DateTime(2023, 8, 2, 11, 8, 2, 146, DateTimeKind.Utc).AddTicks(9390), 2, "Christoffer Larsson", new byte[] { 22, 20, 238, 143, 82, 84, 138, 226, 142, 17, 183, 31, 247, 25, 174, 120, 151, 196, 98, 3, 21, 239, 247, 224, 215, 7, 91, 184, 115, 145, 100, 97, 83, 253, 20, 98, 101, 12, 163, 137, 235, 51, 138, 208, 151, 114, 132, 169, 11, 7, 140, 107, 6, 227, 120, 78, 44, 75, 66, 165, 8, 239, 180, 240 }, new byte[] { 92, 194, 195, 212, 73, 227, 141, 96, 89, 23, 73, 107, 175, 239, 55, 142, 82, 226, 233, 36, 254, 82, 249, 199, 98, 78, 130, 53, 143, 124, 131, 171, 119, 201, 160, 31, 73, 215, 77, 29, 18, 142, 41, 158, 36, 131, 38, 41, 89, 82, 22, 201, 183, 10, 89, 44, 104, 215, 99, 73, 29, 59, 171, 156, 129, 180, 65, 151, 181, 19, 161, 196, 60, 81, 142, 147, 252, 166, 129, 14, 223, 228, 149, 48, 247, 105, 1, 221, 119, 234, 193, 234, 90, 220, 222, 55, 7, 243, 123, 87, 136, 22, 38, 245, 165, 83, 121, 219, 92, 206, 30, 247, 244, 47, 4, 158, 154, 96, 100, 102, 159, 170, 32, 72, 216, 163, 5, 190 }, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LocationId",
                table: "Users",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Location_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Location_LocationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_LocationId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 7, 51, 3, 90, DateTimeKind.Utc).AddTicks(5992));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 7, 51, 3, 90, DateTimeKind.Utc).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 7, 51, 3, 90, DateTimeKind.Utc).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 7, 51, 3, 90, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 7, 51, 3, 90, DateTimeKind.Utc).AddTicks(5998));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 7, 51, 3, 90, DateTimeKind.Utc).AddTicks(5999));

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Adressess_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Adressess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
