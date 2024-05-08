using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lezioniEcommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class recreate_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BRANDS",
                columns: table => new
                {
                    BRAND_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BRAND_NAME = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANDS", x => x.BRAND_ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                columns: table => new
                {
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CATEGORY_NAME = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIES", x => x.CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_USERNAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    USER_FIRSTNAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    USER_LASTNAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    USER_PASSWORD = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    USER_EMAIL = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCT_NAME = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PRODUCT_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRODUCT_PRICE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRODUCT_ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    BRAND_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.PRODUCT_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_BRANDS_BRAND_ID",
                        column: x => x.BRAND_ID,
                        principalTable: "BRANDS",
                        principalColumn: "BRAND_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CARTS",
                columns: table => new
                {
                    CART_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARTS", x => x.CART_ID);
                    table.ForeignKey(
                        name: "FK_CARTS_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS_CATEGORIES",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS_CATEGORIES", x => new { x.PRODUCT_ID, x.CATEGORY_ID });
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORIES_CATEGORIES_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORIES",
                        principalColumn: "CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_CATEGORIES_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CART_ITEMS",
                columns: table => new
                {
                    CART_ITEM_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CART_QUANTITY = table.Column<int>(type: "int", nullable: false),
                    CART_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CART_ITEMS", x => x.CART_ITEM_ID);
                    table.ForeignKey(
                        name: "FK_CART_ITEMS_CARTS_CART_ID",
                        column: x => x.CART_ID,
                        principalTable: "CARTS",
                        principalColumn: "CART_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CART_ITEMS_PRODUCTS_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CART_ITEMS_CART_ID",
                table: "CART_ITEMS",
                column: "CART_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CART_ITEMS_PRODUCT_ID",
                table: "CART_ITEMS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CARTS_USER_ID",
                table: "CARTS",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_BRAND_ID",
                table: "PRODUCTS",
                column: "BRAND_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORIES_CATEGORY_ID",
                table: "PRODUCTS_CATEGORIES",
                column: "CATEGORY_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CART_ITEMS");

            migrationBuilder.DropTable(
                name: "PRODUCTS_CATEGORIES");

            migrationBuilder.DropTable(
                name: "CARTS");

            migrationBuilder.DropTable(
                name: "CATEGORIES");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "BRANDS");
        }
    }
}
