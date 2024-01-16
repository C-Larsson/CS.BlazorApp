using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialApp.Server.Migrations
{
    public partial class AddSampleEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7617));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7621));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7623));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(7628));

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Currency", "Deleted", "Description", "EndDate", "EventSeriesId", "HostId", "ImageUrl", "LocationId", "MaxAttendees", "PageUrl", "Price", "StartDate", "Title", "Visible" },
                values: new object[,]
                {
                    { 1, 1, "SEK", false, "Do you love great food? Then join one of our events to have a great dinner with drinks and fun.", new DateTime(2024, 8, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "https://i.pinimg.com/564x/27/31/d1/2731d160096f7788c5ac8b970dbe609a.jpg", 2, 6, "events/200001", 50m, new DateTime(2024, 8, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), "Dinner Party", true },
                    { 2, 2, "", false, "To do yoga online for anti-aging, health, healing, stress management and workplace productivity. An elite team of teachers from Thailand, Bali, Washington DC and Costa Rica will help you on your way to achieving your goals. We also will hold yoga retreats in exotic place around the world.", new DateTime(2024, 8, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "https://i.pinimg.com/564x/f7/28/96/f72896cd838b7c4d2db0fdc19b6d2d40.jpg", 1, 10, "events/200002", 0m, new DateTime(2024, 8, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "Yoga in the Park", true },
                    { 3, 3, "", false, "Want to stay up-to-date on the latest AI technologies? Do you want to learn from and collaborate with other programmers? If so, then this group is for you!\r\n\r\nWe meet regularly at a local cafe to discuss and learn about new programming technologies. We welcome programmers of all skill levels and interests.", new DateTime(2024, 8, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "https://i.pinimg.com/564x/c9/2d/2d/c92d2d693a0b50d620beb2340b76b51f.jpg", 3, 10, "events/200003", 0m, new DateTime(2024, 8, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), "AI Coding in Bangkok", true },
                    { 4, 4, "USD", false, "Do you love to cook or want to have a first unforgettable experience of cooking? Come and join us. We are a group of foodie who want to cook what we eat. We would pick all good ingredients by ourselves(NO MSG.) and cook them in fun and friendly atmosphere!", new DateTime(2024, 8, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "https://i.pinimg.com/564x/0e/6e/9e/0e6e9e2e2e2e2e2e2e2e2e2e2e2e2e2.jpg", 4, 10, "events/200004", 50m, new DateTime(2024, 8, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), "Learn to Cook", true },
                    { 5, 5, "GBP", false, "This group is open to anyone and everyone who is interested in dancing. You may be a professional dancer or never danced before, everyone is welcome, even if you have two left feet...\r\n\r\nThe idea is to create a platform for all types of dancers to come together, share their passion, inspire each-other and feel the divine pleasure of dancing...\r\n\r\nIf you are someone who appreciate dance, would like to try dancing, dance enthusiast, learning to dance, trained dancer, dance instructor, performer please join us. It doesn't matter which dance you know or you are interested in.\r\n\r\nWhen you join, please send us a message why you thought of joining us and may be if you already have dance experience and would like to share it with us. We could organize workshops, gatherings, performances, charity and etc...", new DateTime(2024, 8, 5, 20, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "https://i.pinimg.com/564x/3a/21/06/3a2106ca530f116bf6aadf8e3b46794d.jpg", 5, 8, "events/200005", 50m, new DateTime(2024, 8, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), "Let's Dance", true },
                    { 6, 4, "EUR", false, "Artists who would like to work with painting on the human body as the canvas should join these events together with members of Naturist Association Thailand. For the artists it would be an opportunity to work on painting a group of people and for the naturists / nudists it would be a fun event to be part of. We already have regular life drawing events with sketching and painting artists.", new DateTime(2024, 8, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), null, 1, "https://i.pinimg.com/564x/2d/d9/b1/2dd9b1b66fa618f8e94104421a3444b7.jpg", 6, 15, "events/200006", 5m, new DateTime(2024, 8, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), "Body Painting in Paris", true }
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                column: "State",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(6413), new DateTime(2023, 8, 2, 11, 13, 56, 418, DateTimeKind.Utc).AddTicks(6417), new byte[] { 17, 206, 148, 13, 195, 125, 137, 127, 167, 118, 225, 158, 40, 175, 206, 141, 173, 235, 139, 72, 17, 208, 99, 39, 242, 202, 69, 84, 0, 13, 253, 122, 180, 229, 125, 226, 34, 219, 159, 209, 251, 125, 216, 86, 35, 36, 30, 251, 79, 178, 110, 216, 45, 85, 158, 223, 88, 226, 9, 31, 134, 139, 168, 64 }, new byte[] { 207, 208, 165, 151, 147, 65, 176, 146, 125, 1, 75, 90, 24, 34, 15, 19, 71, 178, 6, 113, 176, 167, 165, 223, 105, 176, 33, 17, 68, 214, 51, 59, 33, 239, 110, 170, 243, 25, 8, 186, 134, 27, 88, 56, 245, 197, 186, 142, 180, 148, 183, 117, 89, 198, 135, 185, 71, 205, 122, 72, 151, 30, 127, 148, 171, 158, 50, 9, 68, 168, 23, 91, 170, 179, 213, 52, 224, 180, 209, 248, 1, 117, 2, 74, 20, 105, 26, 6, 198, 202, 185, 50, 147, 153, 72, 21, 110, 238, 115, 126, 123, 140, 110, 227, 196, 138, 171, 144, 37, 122, 23, 100, 73, 238, 216, 11, 85, 185, 60, 122, 222, 86, 229, 212, 191, 152, 37, 7 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 12,
                column: "State",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 8, 2, 11, 11, 3, 648, DateTimeKind.Utc).AddTicks(9651), new DateTime(2023, 8, 2, 11, 11, 3, 648, DateTimeKind.Utc).AddTicks(9652), new byte[] { 80, 156, 9, 247, 32, 144, 190, 249, 148, 93, 171, 70, 64, 17, 105, 61, 6, 96, 29, 123, 222, 25, 86, 92, 177, 25, 118, 69, 175, 133, 247, 242, 107, 36, 15, 190, 162, 175, 130, 11, 204, 193, 36, 52, 37, 254, 104, 188, 120, 166, 151, 138, 169, 9, 168, 161, 216, 149, 45, 119, 71, 155, 47, 63 }, new byte[] { 170, 143, 153, 153, 109, 84, 230, 215, 161, 150, 124, 36, 40, 21, 25, 27, 207, 80, 87, 172, 163, 103, 206, 137, 3, 14, 215, 245, 169, 200, 236, 123, 88, 108, 116, 251, 139, 234, 238, 226, 69, 171, 242, 221, 44, 227, 70, 180, 24, 131, 232, 212, 94, 117, 44, 236, 169, 148, 117, 203, 132, 148, 247, 230, 70, 248, 102, 96, 189, 17, 133, 38, 150, 195, 250, 187, 179, 107, 41, 239, 25, 210, 76, 149, 228, 89, 87, 157, 215, 203, 128, 20, 6, 251, 177, 233, 235, 226, 156, 239, 117, 215, 156, 235, 12, 70, 140, 154, 42, 188, 37, 198, 158, 154, 171, 163, 246, 237, 56, 108, 170, 85, 157, 229, 5, 51, 113, 223 } });
        }
    }
}
