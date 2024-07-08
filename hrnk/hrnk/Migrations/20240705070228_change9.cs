using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrnk.Migrations
{
    /// <inheritdoc />
    public partial class change9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "User",
                newName: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "User",
                newName: "role");
        }
    }
}
