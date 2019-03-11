using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Krunsave.Migrations
{
    public partial class InitialTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "availablefoodtags",
                columns: table => new
                {
                    availableFoodID = table.Column<int>(nullable: false),
                    foodTagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_availablefoodtags", x => new { x.foodTagID, x.availableFoodID });
                });

            migrationBuilder.CreateTable(
                name: "Foodtags",
                columns: table => new
                {
                    foodTagID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tagName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodtags", x => x.foodTagID);
                });

            migrationBuilder.CreateTable(
                name: "Foodtypes",
                columns: table => new
                {
                    foodTypeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foodtypes", x => x.foodTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    roleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "Storetypes",
                columns: table => new
                {
                    storeTypeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storetypes", x => x.storeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(nullable: true),
                    passwordHash = table.Column<byte[]>(nullable: true),
                    passwordSalt = table.Column<byte[]>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    roleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleID",
                        column: x => x.roleID,
                        principalTable: "Roles",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    storeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    storeName = table.Column<string>(nullable: true),
                    managerName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    lat = table.Column<decimal>(nullable: false),
                    lng = table.Column<decimal>(nullable: false),
                    openTime = table.Column<string>(nullable: true),
                    closeTime = table.Column<string>(nullable: true),
                    storeTypeID = table.Column<int>(nullable: false),
                    userID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.storeID);
                    table.ForeignKey(
                        name: "FK_Stores_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availablefoods",
                columns: table => new
                {
                    availableFoodID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    engName = table.Column<string>(nullable: true),
                    thaiName = table.Column<string>(nullable: true),
                    totalUnits = table.Column<int>(nullable: true),
                    unitType = table.Column<string>(nullable: true),
                    availableUnits = table.Column<int>(nullable: true),
                    discountPerUnit = table.Column<int>(nullable: true),
                    pricePerUnit = table.Column<int>(nullable: true),
                    cookedDate = table.Column<string>(nullable: true),
                    expiryDate = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    foodTypeID = table.Column<int>(nullable: true),
                    storeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availablefoods", x => x.availableFoodID);
                    table.ForeignKey(
                        name: "FK_Availablefoods_Stores_storeID",
                        column: x => x.storeID,
                        principalTable: "Stores",
                        principalColumn: "storeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Userviews",
                columns: table => new
                {
                    userViewID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    viewDate = table.Column<string>(nullable: true),
                    viewTime = table.Column<string>(nullable: true),
                    userID = table.Column<int>(nullable: false),
                    storeID = table.Column<int>(nullable: false),
                    availableFoodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userviews", x => x.userViewID);
                    table.ForeignKey(
                        name: "FK_Userviews_Availablefoods_availableFoodID",
                        column: x => x.availableFoodID,
                        principalTable: "Availablefoods",
                        principalColumn: "availableFoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Userviews_Stores_storeID",
                        column: x => x.storeID,
                        principalTable: "Stores",
                        principalColumn: "storeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Userviews_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availablefoods_storeID",
                table: "Availablefoods",
                column: "storeID");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_userID",
                table: "Stores",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleID",
                table: "Users",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_Userviews_availableFoodID",
                table: "Userviews",
                column: "availableFoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Userviews_storeID",
                table: "Userviews",
                column: "storeID");

            migrationBuilder.CreateIndex(
                name: "IX_Userviews_userID",
                table: "Userviews",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "availablefoodtags");

            migrationBuilder.DropTable(
                name: "Foodtags");

            migrationBuilder.DropTable(
                name: "Foodtypes");

            migrationBuilder.DropTable(
                name: "Storetypes");

            migrationBuilder.DropTable(
                name: "Userviews");

            migrationBuilder.DropTable(
                name: "Availablefoods");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
