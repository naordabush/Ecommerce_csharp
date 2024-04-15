using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lezioniEcommerce.API.Migrations
{
    /// <inheritdoc />
    public partial class USERS_fix_length_password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USER_PASSWORD",
                table: "USERS",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "USER_PASSWORD",
                table: "USERS",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);
        }
    }
}
