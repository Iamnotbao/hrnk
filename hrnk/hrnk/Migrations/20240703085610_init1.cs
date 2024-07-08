using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hrnk.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    hash_password = table.Column<byte[]>(type: "binary(32)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_create_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_update_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    user_update_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
