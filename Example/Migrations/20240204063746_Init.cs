using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Example.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeName = table.Column<string>(type: "nvarchar(45)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(45)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(225)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ImageID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.ProductID, x.ImageID });
                    table.ForeignKey(
                        name: "FK_ProductImages_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SizeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => new { x.ProductID, x.SizeID });
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizeID",
                        column: x => x.SizeID,
                        principalTable: "Sizes",
                        principalColumn: "SizeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => new { x.UserID, x.AddressID });
                    table.ForeignKey(
                        name: "FK_UserAddresses_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => new { x.UserID, x.ImageID });
                    table.ForeignKey(
                        name: "FK_UserImages_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserImages_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressID", "City", "Country", "Street" },
                values: new object[,]
                {
                    { 1, "City1", "Country1", "Street1" },
                    { 2, "City2", "Country2", "Street2" },
                    { 3, "City3", "Country3", "Street3" },
                    { 4, "City4", "Country4", "Street4" },
                    { 5, "City5", "Country5", "Street5" },
                    { 6, "City6", "Country6", "Street6" },
                    { 7, "City7", "Country7", "Street7" },
                    { 8, "City8", "Country8", "Street8" },
                    { 9, "City9", "Country9", "Street9" },
                    { 10, "City10", "Country10", "Street10" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Category0" },
                    { 2, "Category1" },
                    { 3, "Category2" },
                    { 4, "Category3" },
                    { 5, "Category4" },
                    { 6, "Category5" },
                    { 7, "Category6" },
                    { 8, "Category7" },
                    { 9, "Category8" },
                    { 10, "Category9" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "ImageUrl" },
                values: new object[,]
                {
                    { "031474cc-e31d-41fb-864c-ac4ebb836dc3", "https://picsum.photos/id/4/400/300" },
                    { "2991fcd6-c043-4f03-9c77-c98f57fa9ee4", "https://picsum.photos/id/6/400/300" },
                    { "2ddafcca-9f67-4886-b3ad-b975eaca2c8c", "https://picsum.photos/id/8/400/300" },
                    { "3596cecf-2812-47b6-ae48-fef6b490cd83", "https://picsum.photos/id/2/400/300" },
                    { "71746c9f-8b34-49d7-8c1f-d10ef3a98fde", "https://picsum.photos/id/5/400/300" },
                    { "83dee5cc-f5b7-46d9-ba10-7562e82c27e2", "https://picsum.photos/id/3/400/300" },
                    { "8b8d9934-2ed9-4b8a-9a0c-b295cdddd59a", "https://picsum.photos/id/9/400/300" },
                    { "a045ff2e-2306-4c23-a1a5-306fa7a63e2b", "https://picsum.photos/id/1/400/300" },
                    { "a729e6ad-e7c6-4dd6-8691-5f865d1d89da", "https://picsum.photos/id/0/400/300" },
                    { "bccf35ee-5790-4176-b8a4-48bf4513be86", "https://picsum.photos/id/7/400/300" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "ProductName" },
                values: new object[,]
                {
                    { 1, "Product0" },
                    { 2, "Product1" },
                    { 3, "Product2" },
                    { 4, "Product3" },
                    { 5, "Product4" },
                    { 6, "Product5" },
                    { 7, "Product6" },
                    { 8, "Product7" },
                    { 9, "Product8" },
                    { 10, "Product9" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeID", "SizeName" },
                values: new object[,]
                {
                    { 1, "Size0" },
                    { 2, "Size1" },
                    { 3, "Size2" },
                    { 4, "Size3" },
                    { 5, "Size4" },
                    { 6, "Size5" },
                    { 7, "Size6" },
                    { 8, "Size7" },
                    { 9, "Size8" },
                    { 10, "Size9" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { "339578d1-a71b-4cf0-bf38-8e205162d92e", "user8@example.com", "FirstName8", "LastName8", "123456788" },
                    { "4796a57d-752c-4de2-ac2d-b9d4ff7ecf40", "user1@example.com", "FirstName1", "LastName1", "123456781" },
                    { "5ed8107a-e130-4cd0-a1fb-1047e37daf8e", "user7@example.com", "FirstName7", "LastName7", "123456787" },
                    { "7c38ac63-d286-4050-8266-18ef5e89b73e", "user4@example.com", "FirstName4", "LastName4", "123456784" },
                    { "875675eb-a97a-4cfe-8669-e021697a0244", "user9@example.com", "FirstName9", "LastName9", "123456789" },
                    { "8faa718f-0a94-450b-ac4b-f6a874c0f1c9", "user6@example.com", "FirstName6", "LastName6", "123456786" },
                    { "9acd3af6-8610-4994-9f3d-1242446bf7fc", "user10@example.com", "FirstName10", "LastName10", "1234567810" },
                    { "ae4f3421-e051-490f-b5d3-c73e6ada82bd", "user5@example.com", "FirstName5", "LastName5", "123456785" },
                    { "b1c4b075-6433-41f9-a8e7-ec5226b676fd", "user3@example.com", "FirstName3", "LastName3", "123456783" },
                    { "efe68746-c5b6-4702-bb7b-6a267fcf5157", "user2@example.com", "FirstName2", "LastName2", "123456782" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryID", "ProductID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageID", "ProductID" },
                values: new object[,]
                {
                    { "a729e6ad-e7c6-4dd6-8691-5f865d1d89da", 1 },
                    { "a045ff2e-2306-4c23-a1a5-306fa7a63e2b", 2 },
                    { "3596cecf-2812-47b6-ae48-fef6b490cd83", 3 },
                    { "83dee5cc-f5b7-46d9-ba10-7562e82c27e2", 4 },
                    { "031474cc-e31d-41fb-864c-ac4ebb836dc3", 5 },
                    { "71746c9f-8b34-49d7-8c1f-d10ef3a98fde", 6 },
                    { "2991fcd6-c043-4f03-9c77-c98f57fa9ee4", 7 },
                    { "bccf35ee-5790-4176-b8a4-48bf4513be86", 8 },
                    { "2ddafcca-9f67-4886-b3ad-b975eaca2c8c", 9 },
                    { "8b8d9934-2ed9-4b8a-9a0c-b295cdddd59a", 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "ProductID", "SizeID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "UserAddresses",
                columns: new[] { "AddressID", "UserID" },
                values: new object[,]
                {
                    { 8, "339578d1-a71b-4cf0-bf38-8e205162d92e" },
                    { 1, "4796a57d-752c-4de2-ac2d-b9d4ff7ecf40" },
                    { 7, "5ed8107a-e130-4cd0-a1fb-1047e37daf8e" },
                    { 4, "7c38ac63-d286-4050-8266-18ef5e89b73e" },
                    { 9, "875675eb-a97a-4cfe-8669-e021697a0244" },
                    { 6, "8faa718f-0a94-450b-ac4b-f6a874c0f1c9" },
                    { 10, "9acd3af6-8610-4994-9f3d-1242446bf7fc" },
                    { 5, "ae4f3421-e051-490f-b5d3-c73e6ada82bd" },
                    { 3, "b1c4b075-6433-41f9-a8e7-ec5226b676fd" },
                    { 2, "efe68746-c5b6-4702-bb7b-6a267fcf5157" }
                });

            migrationBuilder.InsertData(
                table: "UserImages",
                columns: new[] { "ImageID", "UserID" },
                values: new object[,]
                {
                    { "bccf35ee-5790-4176-b8a4-48bf4513be86", "339578d1-a71b-4cf0-bf38-8e205162d92e" },
                    { "a729e6ad-e7c6-4dd6-8691-5f865d1d89da", "4796a57d-752c-4de2-ac2d-b9d4ff7ecf40" },
                    { "2991fcd6-c043-4f03-9c77-c98f57fa9ee4", "5ed8107a-e130-4cd0-a1fb-1047e37daf8e" },
                    { "83dee5cc-f5b7-46d9-ba10-7562e82c27e2", "7c38ac63-d286-4050-8266-18ef5e89b73e" },
                    { "2ddafcca-9f67-4886-b3ad-b975eaca2c8c", "875675eb-a97a-4cfe-8669-e021697a0244" },
                    { "71746c9f-8b34-49d7-8c1f-d10ef3a98fde", "8faa718f-0a94-450b-ac4b-f6a874c0f1c9" },
                    { "8b8d9934-2ed9-4b8a-9a0c-b295cdddd59a", "9acd3af6-8610-4994-9f3d-1242446bf7fc" },
                    { "031474cc-e31d-41fb-864c-ac4ebb836dc3", "ae4f3421-e051-490f-b5d3-c73e6ada82bd" },
                    { "3596cecf-2812-47b6-ae48-fef6b490cd83", "b1c4b075-6433-41f9-a8e7-ec5226b676fd" },
                    { "a045ff2e-2306-4c23-a1a5-306fa7a63e2b", "efe68746-c5b6-4702-bb7b-6a267fcf5157" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryID",
                table: "ProductCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ImageID",
                table: "ProductImages",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizeID",
                table: "ProductSizes",
                column: "SizeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_AddressID",
                table: "UserAddresses",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_ImageID",
                table: "UserImages",
                column: "ImageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
