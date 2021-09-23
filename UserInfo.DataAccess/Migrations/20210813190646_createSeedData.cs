using Microsoft.EntityFrameworkCore.Migrations;

namespace UserInfo.DataAccess.Migrations
{
    public partial class createSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "GeoId", "Street", "Suite", "Zipcode" },
                values: new object[,]
                {
                    { 1, "Gwenborough", 1, "Kulas Light", "Apt. 556", "92998-3874" },
                    { 2, "Wisokyburgh", 2, "Victor Plains", "Suite 879", "90566-7771" },
                    { 3, "McKenziehaven", 3, "Douglas Extension", "Suite 847", "59590-4157" },
                    { 4, "South Elvis", 4, "Hoeger Mall", "Apt. 692", "53919-4257" },
                    { 5, "Roscoeview", 5, "Skiles Walks", "Suite 351", "33263" },
                    { 6, "South Christy", 6, "Norberto Crossing", "Apt. 950", "23505-1337" },
                    { 7, "Howemouth", 7, "Rex Trail", "Suite 280", "58804-1099" },
                    { 8, "Aliyaview", 8, "Ellsworth Summit", "Suite 729", "45169" },
                    { 9, "Bartholomebury", 9, "Dayna Park", "Suite 449", "76495-3109" },
                    { 10, "Lebsackbury", 10, "Kattie Turnpike", "Suite 198", "31428-2261" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Bs", "Catchphrase", "Name" },
                values: new object[,]
                {
                    { 9, "aggregate real-time technologies", "Switchable contextually-based project", "Yost and Sons" },
                    { 8, "e-enable extensible e-tailers", "Implemented secondary concept", "Abernathy Group" },
                    { 7, "generate enterprise e-tailers", "Configurable multimedia task-force", "Johns Group" },
                    { 6, "e-enable innovative applications", "Synchronised bottom-line interface", "Considine-Lockman" },
                    { 10, "target end-to-end models", "Centralized empowering task-force", "Hoeger LLC" },
                    { 4, "transition cutting-edge web services", "Multi-tiered zero tolerance productivity", "Robel-Corkery" },
                    { 3, "e-enable strategic applications", "Face to face bifurcated interface", "Romaguera-Jacobson" },
                    { 2, "synergize scalable supply-chains", "Proactive didactic contingency", "Deckow-Crist" },
                    { 1, "harness real-time e-markets", "Multi-layered client-server neural-net", "Romaguera-Crona" },
                    { 5, "revolutionize end-to-end systems", "User-centric fault-tolerant solution", "Keebler LLC" }
                });

            migrationBuilder.InsertData(
                table: "Geolocations",
                columns: new[] { "Id", "Lat", "Lng" },
                values: new object[,]
                {
                    { 10, "-38.2386", "57.2232" },
                    { 9, "24.6463", "-168.8889" },
                    { 7, "24.8918", "21.8984" },
                    { 6, "-71.4197", "71.7478" },
                    { 8, "-14.3990", "-120.7677" },
                    { 4, "29.4572", "-164.2990" },
                    { 3, "-68.6102", "-47.0653" },
                    { 2, "-43.9509", "-34.4618" },
                    { 1, "-37.3159", "81.1496" },
                    { 5, "-31.8129", "62.5342" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AddressId", "CompanyId", "Email", "Name", "Phone", "Username", "Website" },
                values: new object[,]
                {
                    { 9, 9, 9, "Chaim_McDermott@dana.io", "Glenna Reichert", "(775)976-6794 x41206", "Delphine", "conrad.com" },
                    { 1, 1, 1, "Sincere@april.biz", "Leanne Graham", "1-770-736-8031 x56442", "Bret", "hildegard.org" },
                    { 2, 2, 2, "Shanna@melissa.tv", "Ervin Howell", "010-692-6593 x09125", "Antonette", "anastasia.net" },
                    { 3, 3, 3, "Nathan@yesenia.net", "Clementine Bauch", "1-463-123-4447", "Samantha", "ramiro.info" },
                    { 4, 4, 4, "Julianne.OConner@kory.org", "Patricia Lebsack", "493-170-9623 x156", "Karianne", "kale.biz" },
                    { 5, 5, 5, "Lucio_Hettinger@annie.ca", "Chelsey Dietrich", "(254)954-1289", "Kamren", "demarco.info" },
                    { 6, 6, 6, "Karley_Dach@jasper.info", "Mrs. Dennis Schulist", "1-477-935-8478 x6430", "Leopoldo_Corkery", "ola.org" },
                    { 7, 7, 7, "Telly.Hoeger@billy.biz", "Kurtis Weissnat", "210.067.6132", "Elwyn.Skiles", "elvis.io" },
                    { 8, 8, 8, "Sherwood@rosamond.me", "Nicholas Runolfsdottir V", "586.493.6943 x140", "Maxime_Nienow", "jacynthe.com" },
                    { 10, 10, 10, "Rey.Padberg@karina.biz", "Clementina DuBuque", "024-648-3804", "Moriah.Stanton", "ambrose.net" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Geolocations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
