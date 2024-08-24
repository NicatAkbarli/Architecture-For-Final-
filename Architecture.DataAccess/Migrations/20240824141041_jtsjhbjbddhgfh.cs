using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Architecture.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class jtsjhbjbddhgfh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affiliates_BaseUser_UserId",
                table: "Affiliates");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BaseUser_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_BaseUser_UserId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BaseUser_AppUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_BaseUser_UserId",
                table: "Shops");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_BaseUser_UserId",
                table: "WishLists");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "BaseUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "BaseUser");

            migrationBuilder.AddColumn<string>(
                name: "ShopName",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BaseUser_Id",
                        column: x => x.Id,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliates_Users_UserId",
                table: "Affiliates",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_Users_UserId",
                table: "Followers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_Users_UserId",
                table: "Shops",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Users_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affiliates_Users_UserId",
                table: "Affiliates");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_Users_UserId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_AppUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Shops_Users_UserId",
                table: "Shops");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Users_UserId",
                table: "WishLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "ShopName",
                table: "Shops");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseUser",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "BaseUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "BaseUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Affiliates_BaseUser_UserId",
                table: "Affiliates",
                column: "UserId",
                principalTable: "BaseUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BaseUser_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_BaseUser_UserId",
                table: "Followers",
                column: "UserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BaseUser_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_BaseUser_UserId",
                table: "Shops",
                column: "UserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_BaseUser_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
