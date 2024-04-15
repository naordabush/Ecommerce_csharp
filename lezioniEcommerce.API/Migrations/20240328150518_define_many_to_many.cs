using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lezioniEcommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class define_many_to_many : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCTS_CATEGORIES",
                table: "PRODUCTS_CATEGORIES");

            migrationBuilder.DropIndex(
                name: "IX_PRODUCTS_CATEGORIES_PRODUCT_ID",
                table: "PRODUCTS_CATEGORIES");

            migrationBuilder.DropColumn(
                name: "PRODUCT_CATEGORY_ID",
                table: "PRODUCTS_CATEGORIES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCTS_CATEGORIES",
                table: "PRODUCTS_CATEGORIES",
                columns: new[] { "PRODUCT_ID", "CATEGORY_ID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PRODUCTS_CATEGORIES",
                table: "PRODUCTS_CATEGORIES");

            migrationBuilder.AddColumn<int>(
                name: "PRODUCT_CATEGORY_ID",
                table: "PRODUCTS_CATEGORIES",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRODUCTS_CATEGORIES",
                table: "PRODUCTS_CATEGORIES",
                column: "PRODUCT_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_CATEGORIES_PRODUCT_ID",
                table: "PRODUCTS_CATEGORIES",
                column: "PRODUCT_ID");
        }
    }
}
