using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrnk.Migrations
{
    /// <inheritdoc />
    public partial class change7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "hash_password",
                table: "User",
                type: "binary(255)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "hash_password",
                table: "User",
                type: "binary(50)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary(255)");
        }
    }
}
