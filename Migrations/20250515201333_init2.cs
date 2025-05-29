using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkSpaceWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Spaces_RoomId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RoomId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Galleries",
                newName: "ImageURl");

            migrationBuilder.AddColumn<int>(
                name: "spaceId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ContactMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "ContactMessages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ContactMessages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ContactMessages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "ContactMessages",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ContactMessages",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsRead", "Message", "Subject" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 15, 20, 13, 32, 295, DateTimeKind.Utc).AddTicks(4019), "ahmed@example.com", "Ahmed Ali", false, "Can I get the pricing details and booking information?", "Inquiry about rooms" },
                    { 2, new DateTime(2025, 5, 15, 20, 13, 32, 295, DateTimeKind.Utc).AddTicks(4025), "sara@example.com", "Sara Mohamed", false, "I booked a room but didn’t receive a confirmation. Can you contact me?", "Issue with booking" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ApplicationUserId", "Comment", "CreatedAt", "Rating", "RoomId", "UserId", "spaceId" },
                values: new object[,]
                {
                    { 1, null, "Amazing place, very comfortable for studying!", new DateTime(2025, 5, 15, 20, 13, 32, 295, DateTimeKind.Utc).AddTicks(3946), 5, 1, 1, null },
                    { 2, null, "Nice, but could be a bit quieter.", new DateTime(2025, 5, 15, 20, 13, 32, 295, DateTimeKind.Utc).AddTicks(3953), 4, 2, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_spaceId",
                table: "Reviews",
                column: "spaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Spaces_spaceId",
                table: "Reviews",
                column: "spaceId",
                principalTable: "Spaces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Spaces_spaceId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_spaceId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "ContactMessages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactMessages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "spaceId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ContactMessages");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "ContactMessages");

            migrationBuilder.RenameColumn(
                name: "ImageURl",
                table: "Galleries",
                newName: "ImageUrl");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RoomId",
                table: "Reviews",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Spaces_RoomId",
                table: "Reviews",
                column: "RoomId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
