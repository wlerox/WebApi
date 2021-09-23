using Microsoft.EntityFrameworkCore;
using UserInfo.Entities;
using UserInfo.Entities.Model;

namespace UserInfo.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //context.Database.EnsureCreated();
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator() { ID = 1, UserName = "admin", Password = "1234" });
            //modelBuilder.Entity<Administrator>().HasIndex(p => p.UserName).IsUnique();


            modelBuilder.Entity<Geolocation>().HasData(
                new Geolocation() { Id = 1, Lat = "-37.3159", Lng = "81.1496" },
                new Geolocation() { Id = 2, Lat = "-43.9509", Lng = "-34.4618" },
                new Geolocation() { Id = 3, Lat = "-68.6102", Lng = "-47.0653" },
                new Geolocation() { Id = 4, Lat = "29.4572", Lng = "-164.2990" },
                new Geolocation() { Id = 5, Lat = "-31.8129", Lng = "62.5342" },
                new Geolocation() { Id = 6, Lat = "-71.4197", Lng = "71.7478" },
                new Geolocation() { Id = 7, Lat = "24.8918", Lng = "21.8984" },
                new Geolocation() { Id = 8, Lat = "-14.3990", Lng = "-120.7677" },
                new Geolocation() { Id = 9, Lat = "24.6463", Lng = "-168.8889" },
                new Geolocation() { Id = 10, Lat = "-38.2386", Lng = "57.2232" }
                );
            modelBuilder.Entity<Address>().HasData(
                new Address() { Id = 1, Street = "Kulas Light", Suite = "Apt. 556", City = "Gwenborough", Zipcode = "92998-3874", GeoId = 1},
                new Address() { Id = 2, Street = "Victor Plains", Suite = "Suite 879", City = "Wisokyburgh", Zipcode = "90566-7771", GeoId = 2 },
                new Address() { Id = 3, Street = "Douglas Extension", Suite = "Suite 847", City = "McKenziehaven", Zipcode = "59590-4157", GeoId = 3 },
                new Address() { Id = 4, Street = "Hoeger Mall", Suite = "Apt. 692", City = "South Elvis", Zipcode = "53919-4257", GeoId = 4 },
                new Address() { Id = 5, Street = "Skiles Walks", Suite = "Suite 351", City = "Roscoeview", Zipcode = "33263", GeoId = 5 },
                new Address() { Id = 6, Street = "Norberto Crossing", Suite = "Apt. 950", City = "South Christy", Zipcode = "23505-1337", GeoId = 6 },
                new Address() { Id = 7, Street = "Rex Trail", Suite = "Suite 280", City = "Howemouth", Zipcode = "58804-1099", GeoId = 7 },
                new Address() { Id = 8, Street = "Ellsworth Summit", Suite = "Suite 729", City = "Aliyaview", Zipcode = "45169", GeoId = 8 },
                new Address() { Id = 9, Street = "Dayna Park", Suite = "Suite 449", City = "Bartholomebury", Zipcode = "76495-3109", GeoId = 9 },
                new Address() { Id = 10, Street = "Kattie Turnpike", Suite = "Suite 198", City = "Lebsackbury", Zipcode = "31428-2261", GeoId = 10 }) ;
            modelBuilder.Entity<Company>().HasData(
                new Company() { Id = 1, Name = "Romaguera-Crona", Catchphrase = "Multi-layered client-server neural-net", Bs = "harness real-time e-markets" },
                new Company() { Id = 2, Name = "Deckow-Crist", Catchphrase = "Proactive didactic contingency", Bs = "synergize scalable supply-chains" },
                new Company() { Id = 3, Name = "Romaguera-Jacobson", Catchphrase = "Face to face bifurcated interface", Bs = "e-enable strategic applications" },
                new Company() { Id = 4, Name = "Robel-Corkery", Catchphrase = "Multi-tiered zero tolerance productivity", Bs = "transition cutting-edge web services" },
                new Company() { Id = 5, Name = "Keebler LLC", Catchphrase = "User-centric fault-tolerant solution", Bs = "revolutionize end-to-end systems" },
                new Company() { Id = 6, Name = "Considine-Lockman", Catchphrase = "Synchronised bottom-line interface", Bs = "e-enable innovative applications" },
                new Company() { Id = 7, Name = "Johns Group", Catchphrase = "Configurable multimedia task-force", Bs = "generate enterprise e-tailers" },
                new Company() { Id = 8, Name = "Abernathy Group", Catchphrase = "Implemented secondary concept", Bs = "e-enable extensible e-tailers" },
                new Company() { Id = 9, Name = "Yost and Sons", Catchphrase = "Switchable contextually-based project", Bs = "aggregate real-time technologies" },
                new Company() { Id = 10, Name = "Hoeger LLC", Catchphrase = "Centralized empowering task-force", Bs = "target end-to-end models" });
            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Name = "Leanne Graham", Username = "Bret", Email = "Sincere@april.biz", AddressId = 1, Phone = "1-770-736-8031 x56442", Website = "hildegard.org", CompanyId = 1},
                new User() { Id = 2, Name = "Ervin Howell", Username = "Antonette", Email = "Shanna@melissa.tv", AddressId = 2, Phone = "010-692-6593 x09125", Website = "anastasia.net", CompanyId = 2 },
                new User() { Id = 3, Name = "Clementine Bauch", Username = "Samantha", Email = "Nathan@yesenia.net", AddressId = 3, Phone = "1-463-123-4447", Website = "ramiro.info", CompanyId = 3 },
                new User() { Id = 4, Name = "Patricia Lebsack", Username = "Karianne", Email = "Julianne.OConner@kory.org", AddressId = 4, Phone = "493-170-9623 x156", Website = "kale.biz", CompanyId = 4 },
                new User() { Id = 5, Name = "Chelsey Dietrich", Username = "Kamren", Email = "Lucio_Hettinger@annie.ca", AddressId = 5, Phone = "(254)954-1289", Website = "demarco.info", CompanyId = 5 },
                new User() { Id = 6, Name = "Mrs. Dennis Schulist", Username = "Leopoldo_Corkery", Email = "Karley_Dach@jasper.info", AddressId = 6, Phone = "1-477-935-8478 x6430", Website = "ola.org", CompanyId = 6 },
                new User() { Id = 7, Name = "Kurtis Weissnat", Username = "Elwyn.Skiles", Email = "Telly.Hoeger@billy.biz", AddressId = 7, Phone = "210.067.6132", Website = "elvis.io", CompanyId = 7 },
                new User() { Id = 8, Name = "Nicholas Runolfsdottir V", Username = "Maxime_Nienow", Email = "Sherwood@rosamond.me", AddressId = 8, Phone = "586.493.6943 x140", Website = "jacynthe.com", CompanyId = 8 },
                new User() { Id = 9, Name = "Glenna Reichert", Username = "Delphine", Email = "Chaim_McDermott@dana.io", AddressId = 9, Phone = "(775)976-6794 x41206", Website = "conrad.com", CompanyId = 9 },
                new User() { Id = 10, Name = "Clementina DuBuque", Username = "Moriah.Stanton", Email = "Rey.Padberg@karina.biz", AddressId = 10, Phone = "024-648-3804", Website = "ambrose.net", CompanyId = 10 });
        }
    }
}
