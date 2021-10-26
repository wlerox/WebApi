using Microsoft.EntityFrameworkCore.Migrations;

namespace UserInfo.DataAccess.Migrations
{
    public partial class addCrytoPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RoleId", "Username" },
                values: new object[] { 1, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RoleId", "Username" },
                values: new object[] { 2, "Bret" });
        }
    }
}
