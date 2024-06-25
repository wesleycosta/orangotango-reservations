using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orangotango.Reservations.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Category_CategoryId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomCategoryId",
                table: "Room");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Category_CategoryId",
                table: "Room",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Category_CategoryId",
                table: "Room");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomCategoryId",
                table: "Room",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Category_CategoryId",
                table: "Room",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
