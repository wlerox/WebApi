﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserInfo.DataAccess;

namespace UserInfo.DataAccess.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20210912155959_createAdminSeedData")]
    partial class createAdminSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserInfo.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GeoId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeoId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Gwenborough",
                            GeoId = 1,
                            Street = "Kulas Light",
                            Suite = "Apt. 556",
                            Zipcode = "92998-3874"
                        },
                        new
                        {
                            Id = 2,
                            City = "Wisokyburgh",
                            GeoId = 2,
                            Street = "Victor Plains",
                            Suite = "Suite 879",
                            Zipcode = "90566-7771"
                        },
                        new
                        {
                            Id = 3,
                            City = "McKenziehaven",
                            GeoId = 3,
                            Street = "Douglas Extension",
                            Suite = "Suite 847",
                            Zipcode = "59590-4157"
                        },
                        new
                        {
                            Id = 4,
                            City = "South Elvis",
                            GeoId = 4,
                            Street = "Hoeger Mall",
                            Suite = "Apt. 692",
                            Zipcode = "53919-4257"
                        },
                        new
                        {
                            Id = 5,
                            City = "Roscoeview",
                            GeoId = 5,
                            Street = "Skiles Walks",
                            Suite = "Suite 351",
                            Zipcode = "33263"
                        },
                        new
                        {
                            Id = 6,
                            City = "South Christy",
                            GeoId = 6,
                            Street = "Norberto Crossing",
                            Suite = "Apt. 950",
                            Zipcode = "23505-1337"
                        },
                        new
                        {
                            Id = 7,
                            City = "Howemouth",
                            GeoId = 7,
                            Street = "Rex Trail",
                            Suite = "Suite 280",
                            Zipcode = "58804-1099"
                        },
                        new
                        {
                            Id = 8,
                            City = "Aliyaview",
                            GeoId = 8,
                            Street = "Ellsworth Summit",
                            Suite = "Suite 729",
                            Zipcode = "45169"
                        },
                        new
                        {
                            Id = 9,
                            City = "Bartholomebury",
                            GeoId = 9,
                            Street = "Dayna Park",
                            Suite = "Suite 449",
                            Zipcode = "76495-3109"
                        },
                        new
                        {
                            Id = 10,
                            City = "Lebsackbury",
                            GeoId = 10,
                            Street = "Kattie Turnpike",
                            Suite = "Suite 198",
                            Zipcode = "31428-2261"
                        });
                });

            modelBuilder.Entity("UserInfo.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Catchphrase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bs = "harness real-time e-markets",
                            Catchphrase = "Multi-layered client-server neural-net",
                            Name = "Romaguera-Crona"
                        },
                        new
                        {
                            Id = 2,
                            Bs = "synergize scalable supply-chains",
                            Catchphrase = "Proactive didactic contingency",
                            Name = "Deckow-Crist"
                        },
                        new
                        {
                            Id = 3,
                            Bs = "e-enable strategic applications",
                            Catchphrase = "Face to face bifurcated interface",
                            Name = "Romaguera-Jacobson"
                        },
                        new
                        {
                            Id = 4,
                            Bs = "transition cutting-edge web services",
                            Catchphrase = "Multi-tiered zero tolerance productivity",
                            Name = "Robel-Corkery"
                        },
                        new
                        {
                            Id = 5,
                            Bs = "revolutionize end-to-end systems",
                            Catchphrase = "User-centric fault-tolerant solution",
                            Name = "Keebler LLC"
                        },
                        new
                        {
                            Id = 6,
                            Bs = "e-enable innovative applications",
                            Catchphrase = "Synchronised bottom-line interface",
                            Name = "Considine-Lockman"
                        },
                        new
                        {
                            Id = 7,
                            Bs = "generate enterprise e-tailers",
                            Catchphrase = "Configurable multimedia task-force",
                            Name = "Johns Group"
                        },
                        new
                        {
                            Id = 8,
                            Bs = "e-enable extensible e-tailers",
                            Catchphrase = "Implemented secondary concept",
                            Name = "Abernathy Group"
                        },
                        new
                        {
                            Id = 9,
                            Bs = "aggregate real-time technologies",
                            Catchphrase = "Switchable contextually-based project",
                            Name = "Yost and Sons"
                        },
                        new
                        {
                            Id = 10,
                            Bs = "target end-to-end models",
                            Catchphrase = "Centralized empowering task-force",
                            Name = "Hoeger LLC"
                        });
                });

            modelBuilder.Entity("UserInfo.Entities.Geolocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lng")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Geolocations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Lat = "-37.3159",
                            Lng = "81.1496"
                        },
                        new
                        {
                            Id = 2,
                            Lat = "-43.9509",
                            Lng = "-34.4618"
                        },
                        new
                        {
                            Id = 3,
                            Lat = "-68.6102",
                            Lng = "-47.0653"
                        },
                        new
                        {
                            Id = 4,
                            Lat = "29.4572",
                            Lng = "-164.2990"
                        },
                        new
                        {
                            Id = 5,
                            Lat = "-31.8129",
                            Lng = "62.5342"
                        },
                        new
                        {
                            Id = 6,
                            Lat = "-71.4197",
                            Lng = "71.7478"
                        },
                        new
                        {
                            Id = 7,
                            Lat = "24.8918",
                            Lng = "21.8984"
                        },
                        new
                        {
                            Id = 8,
                            Lat = "-14.3990",
                            Lng = "-120.7677"
                        },
                        new
                        {
                            Id = 9,
                            Lat = "24.6463",
                            Lng = "-168.8889"
                        },
                        new
                        {
                            Id = 10,
                            Lat = "-38.2386",
                            Lng = "57.2232"
                        });
                });

            modelBuilder.Entity("UserInfo.Entities.Model.Administrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Administrators");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Password = "admin",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("UserInfo.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            CompanyId = 1,
                            Email = "Sincere@april.biz",
                            Name = "Leanne Graham",
                            Phone = "1-770-736-8031 x56442",
                            Username = "Bret",
                            Website = "hildegard.org"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            CompanyId = 2,
                            Email = "Shanna@melissa.tv",
                            Name = "Ervin Howell",
                            Phone = "010-692-6593 x09125",
                            Username = "Antonette",
                            Website = "anastasia.net"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            CompanyId = 3,
                            Email = "Nathan@yesenia.net",
                            Name = "Clementine Bauch",
                            Phone = "1-463-123-4447",
                            Username = "Samantha",
                            Website = "ramiro.info"
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 4,
                            CompanyId = 4,
                            Email = "Julianne.OConner@kory.org",
                            Name = "Patricia Lebsack",
                            Phone = "493-170-9623 x156",
                            Username = "Karianne",
                            Website = "kale.biz"
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 5,
                            CompanyId = 5,
                            Email = "Lucio_Hettinger@annie.ca",
                            Name = "Chelsey Dietrich",
                            Phone = "(254)954-1289",
                            Username = "Kamren",
                            Website = "demarco.info"
                        },
                        new
                        {
                            Id = 6,
                            AddressId = 6,
                            CompanyId = 6,
                            Email = "Karley_Dach@jasper.info",
                            Name = "Mrs. Dennis Schulist",
                            Phone = "1-477-935-8478 x6430",
                            Username = "Leopoldo_Corkery",
                            Website = "ola.org"
                        },
                        new
                        {
                            Id = 7,
                            AddressId = 7,
                            CompanyId = 7,
                            Email = "Telly.Hoeger@billy.biz",
                            Name = "Kurtis Weissnat",
                            Phone = "210.067.6132",
                            Username = "Elwyn.Skiles",
                            Website = "elvis.io"
                        },
                        new
                        {
                            Id = 8,
                            AddressId = 8,
                            CompanyId = 8,
                            Email = "Sherwood@rosamond.me",
                            Name = "Nicholas Runolfsdottir V",
                            Phone = "586.493.6943 x140",
                            Username = "Maxime_Nienow",
                            Website = "jacynthe.com"
                        },
                        new
                        {
                            Id = 9,
                            AddressId = 9,
                            CompanyId = 9,
                            Email = "Chaim_McDermott@dana.io",
                            Name = "Glenna Reichert",
                            Phone = "(775)976-6794 x41206",
                            Username = "Delphine",
                            Website = "conrad.com"
                        },
                        new
                        {
                            Id = 10,
                            AddressId = 10,
                            CompanyId = 10,
                            Email = "Rey.Padberg@karina.biz",
                            Name = "Clementina DuBuque",
                            Phone = "024-648-3804",
                            Username = "Moriah.Stanton",
                            Website = "ambrose.net"
                        });
                });

            modelBuilder.Entity("UserInfo.Entities.Address", b =>
                {
                    b.HasOne("UserInfo.Entities.Geolocation", "Geo")
                        .WithMany("Addresses")
                        .HasForeignKey("GeoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Geo");
                });

            modelBuilder.Entity("UserInfo.Entities.User", b =>
                {
                    b.HasOne("UserInfo.Entities.Address", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserInfo.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("UserInfo.Entities.Address", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("UserInfo.Entities.Company", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("UserInfo.Entities.Geolocation", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}