using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lezioniEcommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class remove_OpenIdAuth_property_to_user_table1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenIdAuth",
                table: "USERS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OpenIdAuth",
                table: "USERS",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
