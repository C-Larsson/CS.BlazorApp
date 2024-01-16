using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class CreateReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EventId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Events",
                newName: "CurrencyCode");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "Attendees",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AttendeeCount = table.Column<int>(type: "int", nullable: false),
                    SpecialRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReservationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(573));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 9, 9, 42, 53, 482, DateTimeKind.Utc).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 9, 9, 42, 53, 481, DateTimeKind.Utc).AddTicks(9873), new DateTime(2023, 8, 9, 9, 42, 53, 481, DateTimeKind.Utc).AddTicks(9873), new byte[] { 18, 11, 103, 112, 201, 113, 110, 206, 133, 130, 153, 229, 59, 210, 147, 52, 88, 244, 82, 162, 50, 252, 192, 117, 225, 88, 203, 203, 112, 84, 179, 167, 142, 106, 108, 44, 92, 37, 124, 194, 2, 43, 8, 53, 201, 167, 232, 202, 89, 46, 32, 65, 36, 33, 49, 188, 137, 245, 120, 132, 28, 2, 208, 143 }, new byte[] { 126, 39, 145, 208, 155, 221, 253, 117, 139, 190, 235, 12, 90, 222, 199, 70, 107, 83, 55, 220, 169, 211, 19, 163, 179, 223, 232, 165, 161, 15, 0, 68, 16, 139, 244, 244, 240, 14, 146, 81, 226, 233, 42, 6, 34, 238, 102, 2, 150, 161, 30, 32, 124, 6, 47, 179, 212, 3, 158, 17, 7, 214, 57, 115, 131, 153, 229, 88, 182, 102, 183, 146, 5, 138, 99, 114, 4, 197, 39, 165, 142, 218, 182, 30, 161, 158, 109, 173, 108, 7, 156, 89, 223, 48, 244, 22, 107, 70, 94, 122, 81, 93, 103, 184, 227, 22, 171, 249, 228, 24, 87, 151, 131, 205, 212, 92, 153, 227, 124, 246, 156, 255, 253, 238, 212, 32, 235, 104 } });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EventId",
                table: "Reservations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropColumn(
                name: "Attendees",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "CurrencyCode",
                table: "Events",
                newName: "Currency");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4650));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4651));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4655));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(3632), new DateTime(2023, 8, 8, 4, 49, 24, 5, DateTimeKind.Utc).AddTicks(3636), new byte[] { 99, 8, 181, 3, 44, 1, 121, 161, 39, 250, 28, 123, 83, 158, 55, 138, 142, 24, 148, 80, 88, 19, 137, 216, 153, 217, 218, 90, 107, 199, 41, 238, 169, 148, 118, 139, 46, 220, 248, 92, 51, 232, 112, 108, 107, 186, 90, 71, 178, 116, 75, 153, 201, 244, 1, 177, 45, 131, 111, 144, 70, 212, 164, 137 }, new byte[] { 1, 166, 144, 234, 37, 102, 91, 208, 113, 47, 112, 95, 242, 75, 23, 196, 222, 54, 70, 215, 21, 208, 194, 30, 102, 200, 153, 25, 251, 16, 13, 185, 27, 121, 121, 216, 243, 81, 170, 211, 238, 225, 46, 237, 233, 24, 75, 119, 87, 223, 119, 127, 169, 80, 173, 106, 118, 34, 67, 68, 38, 67, 153, 190, 235, 144, 102, 51, 229, 43, 5, 72, 59, 222, 104, 18, 225, 227, 55, 93, 163, 74, 241, 219, 153, 184, 170, 133, 100, 197, 185, 115, 225, 214, 159, 170, 63, 244, 41, 212, 239, 98, 209, 116, 32, 177, 18, 209, 44, 222, 213, 242, 185, 250, 21, 118, 86, 184, 198, 32, 9, 142, 92, 178, 129, 143, 246, 68 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventId",
                table: "Users",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
