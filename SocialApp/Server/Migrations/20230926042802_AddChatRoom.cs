using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class AddChatRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatRooms_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatRoomId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_ChatRooms_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 26, 4, 28, 1, 690, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 26, 4, 28, 1, 690, DateTimeKind.Utc).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 26, 4, 28, 1, 690, DateTimeKind.Utc).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 26, 4, 28, 1, 690, DateTimeKind.Utc).AddTicks(8792));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 26, 4, 28, 1, 690, DateTimeKind.Utc).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 26, 4, 28, 1, 690, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 9, 26, 4, 28, 1, 690, DateTimeKind.Utc).AddTicks(7796), new DateTime(2023, 9, 26, 4, 28, 1, 690, DateTimeKind.Utc).AddTicks(7798), new byte[] { 173, 191, 195, 168, 254, 233, 118, 140, 28, 142, 65, 173, 182, 220, 3, 159, 179, 206, 96, 51, 78, 62, 183, 145, 187, 56, 34, 185, 203, 69, 222, 16, 202, 65, 68, 21, 224, 139, 229, 108, 142, 97, 109, 113, 161, 176, 135, 3, 147, 19, 40, 125, 245, 40, 149, 247, 59, 137, 255, 179, 69, 168, 201, 161 }, new byte[] { 227, 126, 27, 26, 78, 128, 8, 148, 35, 49, 241, 39, 83, 200, 119, 219, 110, 210, 55, 253, 156, 66, 50, 213, 130, 43, 223, 134, 207, 172, 74, 185, 26, 176, 246, 233, 41, 179, 163, 188, 235, 2, 114, 207, 153, 182, 8, 47, 157, 122, 214, 167, 93, 205, 26, 125, 236, 250, 167, 216, 225, 35, 182, 88, 83, 110, 176, 126, 183, 121, 250, 221, 155, 162, 69, 22, 102, 202, 54, 5, 89, 212, 148, 238, 105, 62, 1, 236, 204, 59, 52, 138, 247, 138, 157, 185, 211, 98, 76, 82, 171, 240, 45, 135, 9, 167, 3, 253, 239, 7, 198, 12, 209, 252, 199, 225, 103, 134, 99, 203, 237, 68, 206, 31, 168, 188, 211, 166 } });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatRoomId",
                table: "ChatMessages",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRooms_EventId",
                table: "ChatRooms",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1578));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1581));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(626), new DateTime(2023, 9, 15, 9, 22, 25, 739, DateTimeKind.Utc).AddTicks(629), new byte[] { 125, 182, 248, 125, 181, 86, 180, 205, 24, 66, 196, 14, 149, 216, 68, 165, 139, 171, 220, 155, 163, 227, 140, 76, 24, 213, 79, 191, 139, 234, 45, 63, 21, 126, 8, 220, 63, 125, 186, 128, 61, 5, 43, 52, 203, 17, 114, 195, 243, 5, 209, 138, 4, 71, 127, 81, 197, 61, 163, 15, 175, 211, 140, 212 }, new byte[] { 159, 177, 61, 32, 193, 203, 50, 91, 34, 167, 110, 116, 110, 122, 150, 182, 61, 19, 55, 75, 245, 95, 93, 86, 19, 232, 157, 26, 92, 65, 56, 200, 44, 127, 42, 154, 16, 217, 120, 94, 95, 115, 143, 89, 249, 25, 153, 238, 189, 73, 176, 169, 234, 238, 157, 172, 94, 157, 167, 24, 46, 16, 146, 100, 99, 89, 55, 211, 231, 161, 47, 166, 174, 170, 91, 210, 249, 59, 98, 183, 51, 146, 91, 158, 116, 242, 166, 73, 246, 136, 41, 251, 186, 95, 128, 159, 134, 244, 189, 243, 95, 220, 144, 90, 144, 116, 164, 190, 50, 21, 204, 176, 231, 195, 45, 254, 195, 37, 27, 205, 231, 177, 134, 246, 146, 169, 47, 186 } });
        }
    }
}
