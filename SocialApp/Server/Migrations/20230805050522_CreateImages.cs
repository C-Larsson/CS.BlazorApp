using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class CreateImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

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
                columns: new[] { "CreatedDate", "Url" },
                values: new object[] { new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(6223), "wellness" });

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
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Want to stay up-to-date on the latest AI technologies? Do you want to learn from and collaborate with other programmers? If so, then this group is for you! We meet regularly at a local cafe to discuss and learn about new programming technologies. We welcome programmers of all skill levels and interests.");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Do you love to cook or want to have a first unforgettable experience of cooking? Come and join us. We are a group of foodie who want to cook what we eat. We would pick all good ingredients by ourselves and cook them in fun and friendly atmosphere!");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "This group is open to anyone and everyone who is interested in dancing. You may be a professional dancer or never danced before, everyone is welcome, even if you have two left feet. The idea is to create a platform for all types of dancers to come together, share their passion, inspire each-other and feel the divine pleasure of dancing. If you are someone who appreciate dance, would like to try dancing, dance enthusiast, learning to dance, trained dancer, dance instructor, performer please join us. It doesn't matter which dance you know or you are interested in. When you join, please send us a message why you thought of joining us and may be if you already have dance experience and would like to share it with us. We could organize workshops, gatherings, performances, charity and etc...");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(5061), new DateTime(2023, 8, 5, 5, 5, 21, 169, DateTimeKind.Utc).AddTicks(5061), new byte[] { 225, 154, 184, 41, 182, 41, 30, 99, 62, 230, 223, 150, 3, 221, 186, 85, 80, 69, 52, 90, 53, 26, 180, 150, 88, 191, 56, 52, 75, 163, 210, 160, 7, 48, 243, 164, 62, 210, 7, 206, 48, 191, 201, 89, 163, 113, 85, 128, 88, 68, 59, 253, 151, 86, 190, 11, 53, 149, 236, 117, 18, 75, 89, 108 }, new byte[] { 129, 197, 9, 134, 22, 253, 243, 249, 128, 151, 55, 91, 31, 191, 219, 186, 6, 183, 129, 249, 79, 54, 233, 22, 29, 130, 60, 41, 205, 134, 79, 28, 164, 21, 229, 7, 138, 58, 163, 62, 186, 123, 13, 230, 190, 66, 120, 253, 70, 96, 247, 243, 25, 155, 82, 191, 194, 127, 25, 248, 120, 209, 241, 219, 48, 177, 96, 99, 145, 117, 125, 27, 254, 131, 120, 57, 2, 90, 228, 90, 198, 176, 62, 235, 160, 107, 202, 212, 27, 90, 94, 42, 157, 52, 167, 203, 100, 165, 35, 246, 206, 221, 173, 221, 244, 216, 226, 120, 246, 110, 35, 168, 208, 115, 133, 119, 231, 168, 45, 79, 47, 138, 95, 111, 162, 82, 1, 74 } });

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventId",
                table: "Images",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Url" },
                values: new object[] { new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3898), "wellnes" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3899));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3901));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3902));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Want to stay up-to-date on the latest AI technologies? Do you want to learn from and collaborate with other programmers? If so, then this group is for you!\r\n\r\nWe meet regularly at a local cafe to discuss and learn about new programming technologies. We welcome programmers of all skill levels and interests.");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Do you love to cook or want to have a first unforgettable experience of cooking? Come and join us. We are a group of foodie who want to cook what we eat. We would pick all good ingredients by ourselves(NO MSG.) and cook them in fun and friendly atmosphere!");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "This group is open to anyone and everyone who is interested in dancing. You may be a professional dancer or never danced before, everyone is welcome, even if you have two left feet...\r\n\r\nThe idea is to create a platform for all types of dancers to come together, share their passion, inspire each-other and feel the divine pleasure of dancing...\r\n\r\nIf you are someone who appreciate dance, would like to try dancing, dance enthusiast, learning to dance, trained dancer, dance instructor, performer please join us. It doesn't matter which dance you know or you are interested in.\r\n\r\nWhen you join, please send us a message why you thought of joining us and may be if you already have dance experience and would like to share it with us. We could organize workshops, gatherings, performances, charity and etc...");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(2937), new DateTime(2023, 8, 3, 9, 4, 7, 401, DateTimeKind.Utc).AddTicks(2938), new byte[] { 128, 174, 89, 178, 160, 136, 217, 162, 29, 64, 172, 248, 108, 238, 227, 130, 104, 216, 253, 229, 80, 161, 239, 24, 136, 114, 16, 207, 205, 10, 221, 214, 30, 248, 121, 151, 128, 18, 40, 56, 38, 74, 228, 19, 191, 235, 42, 46, 138, 231, 1, 72, 57, 77, 42, 70, 172, 198, 245, 191, 119, 41, 87, 219 }, new byte[] { 52, 47, 64, 133, 71, 160, 23, 166, 194, 102, 44, 104, 59, 6, 39, 236, 94, 220, 124, 202, 8, 168, 15, 230, 222, 34, 114, 57, 162, 11, 204, 17, 43, 36, 151, 40, 246, 99, 253, 68, 62, 152, 164, 202, 225, 92, 88, 79, 186, 193, 135, 234, 87, 236, 202, 135, 46, 157, 75, 120, 62, 62, 224, 172, 134, 88, 125, 185, 50, 144, 36, 109, 21, 57, 186, 97, 160, 217, 89, 161, 195, 240, 238, 183, 141, 106, 236, 102, 178, 0, 254, 95, 87, 132, 175, 117, 219, 187, 37, 226, 206, 213, 179, 155, 136, 62, 19, 141, 234, 26, 211, 230, 219, 206, 229, 175, 231, 35, 246, 71, 77, 60, 127, 197, 110, 9, 185, 202 } });
        }
    }
}
