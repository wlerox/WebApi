using Microsoft.EntityFrameworkCore.Migrations;

namespace UserInfo.DataAccess.Migrations
{
    public partial class createAdminSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "ID", "Password", "UserName","Role" },
                values: new object[,] 
                { 
                    { 1, "admin", "1234", "Admin" },
                    { 2, "Delphine", "1234", "User" },
                    { 3, "Bret", "1234", "User" },
                    { 4, "Antonette", "1234", "User" },
                    { 5, "Samantha", "1234", "User" },
                    { 6, "Karianne", "1234", "User" },
                    { 7, "Kamren", "1234", "User" },
                    { 8, "Leopoldo_Corkery", "1234", "User" },
                    { 9, "Elwyn.Skiles", "1234", "User" },
                    { 10, "Maxime_Nienow", "1234", "User" },
                    { 11, "Moriah.Stanton", "1234", "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
