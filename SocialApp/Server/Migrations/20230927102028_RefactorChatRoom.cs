using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class RefactorChatRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_ChatRooms_ChatRoomId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Users_SenderId",
                table: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ChatRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "EventMessages");

            migrationBuilder.RenameColumn(
                name: "ChatRoomId",
                table: "EventMessages",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_SenderId",
                table: "EventMessages",
                newName: "IX_EventMessages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ChatRoomId",
                table: "EventMessages",
                newName: "IX_EventMessages_EventId");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventMessages",
                table: "EventMessages",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 27, 10, 20, 28, 343, DateTimeKind.Utc).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 27, 10, 20, 28, 343, DateTimeKind.Utc).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 27, 10, 20, 28, 343, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 27, 10, 20, 28, 343, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 27, 10, 20, 28, 343, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 9, 27, 10, 20, 28, 343, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 9, 27, 10, 20, 28, 343, DateTimeKind.Utc).AddTicks(1314), new DateTime(2023, 9, 27, 10, 20, 28, 343, DateTimeKind.Utc).AddTicks(1315), new byte[] { 32, 90, 63, 62, 188, 119, 250, 86, 27, 235, 73, 56, 210, 108, 131, 184, 218, 123, 207, 14, 56, 210, 156, 108, 11, 43, 102, 242, 203, 191, 14, 94, 16, 201, 176, 161, 28, 159, 254, 217, 41, 141, 211, 174, 186, 252, 80, 179, 28, 21, 23, 75, 158, 101, 36, 113, 139, 226, 173, 15, 109, 193, 135, 215 }, new byte[] { 110, 175, 82, 75, 48, 53, 151, 199, 214, 112, 204, 229, 85, 111, 193, 59, 66, 22, 184, 19, 157, 196, 1, 47, 49, 241, 18, 71, 156, 178, 214, 60, 23, 107, 26, 82, 108, 235, 133, 223, 208, 245, 167, 197, 13, 221, 6, 150, 3, 235, 238, 108, 150, 205, 247, 59, 0, 168, 88, 147, 197, 230, 30, 155, 50, 207, 182, 60, 57, 123, 205, 48, 136, 216, 236, 219, 235, 133, 192, 171, 213, 10, 227, 9, 29, 242, 217, 92, 252, 164, 37, 125, 51, 57, 116, 67, 103, 112, 221, 3, 147, 12, 245, 63, 228, 13, 231, 50, 250, 177, 106, 144, 183, 183, 106, 242, 150, 78, 93, 247, 187, 137, 245, 78, 125, 234, 135, 161 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventId",
                table: "Users",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventMessages_Events_EventId",
                table: "EventMessages",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMessages_Users_SenderId",
                table: "EventMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventMessages_Events_EventId",
                table: "EventMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMessages_Users_SenderId",
                table: "EventMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EventId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventMessages",
                table: "EventMessages");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "EventMessages",
                newName: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "ChatMessages",
                newName: "ChatRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_EventMessages_SenderId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_EventMessages_EventId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ChatRoomId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "Id");

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
                name: "IX_ChatRooms_EventId",
                table: "ChatRooms",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_ChatRooms_ChatRoomId",
                table: "ChatMessages",
                column: "ChatRoomId",
                principalTable: "ChatRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Users_SenderId",
                table: "ChatMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
