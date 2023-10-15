﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResturantReservation.Db;

#nullable disable

namespace ResturantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    [Migration("20231015160902_proc_CustomersWithPartySizeGreaterThan")]
    partial class proc_CustomersWithPartySizeGreaterThan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResturantReservation.Db.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "boot@gmail.com",
                            FirstName = "steven",
                            LastName = "loyyd",
                            PhoneNumber = "0234367290"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "shot@gmail.com",
                            FirstName = "jake",
                            LastName = "daniel",
                            PhoneNumber = "0234567890"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "dot@gmail.com",
                            FirstName = "kani",
                            LastName = "adam",
                            PhoneNumber = "0234567891"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "hot@gmail.com",
                            FirstName = "zoh",
                            LastName = "noah",
                            PhoneNumber = "1234367891"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "kot@gmail.com",
                            FirstName = "soh",
                            LastName = "saleh",
                            PhoneNumber = "1434467492"
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "moh",
                            LastName = "ahmad",
                            Position = "cashier",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "salah",
                            LastName = "tan",
                            Position = "chief",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "moh",
                            LastName = "issa",
                            Position = "cashier",
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "ahmad",
                            LastName = "nazzal",
                            Position = "chief",
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "james",
                            LastName = "mer'e",
                            Position = "owner"
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.MenuItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            Description = "lemonade",
                            Price = 10.2m,
                            RestaurantId = 1
                        },
                        new
                        {
                            ItemId = 2,
                            Description = "chicken",
                            Price = 22.2m,
                            RestaurantId = 1
                        },
                        new
                        {
                            ItemId = 3,
                            Description = "water",
                            Price = 5.2m,
                            RestaurantId = 1
                        },
                        new
                        {
                            ItemId = 4,
                            Description = "lemonade",
                            Price = 10.2m,
                            RestaurantId = 2
                        },
                        new
                        {
                            ItemId = 5,
                            Description = "steak",
                            Price = 50.2m,
                            RestaurantId = 2
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2023, 10, 15, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9933),
                            ReservationId = 1,
                            TotalAmount = 10.3m
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2023, 10, 5, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9938),
                            ReservationId = 3,
                            TotalAmount = 30.3m
                        },
                        new
                        {
                            OrderId = 3,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2023, 9, 25, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9940),
                            ReservationId = 2,
                            TotalAmount = 30.3m
                        },
                        new
                        {
                            OrderId = 4,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2023, 10, 15, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9941),
                            ReservationId = 4,
                            TotalAmount = 70.3m
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 2,
                            MenuItemId = 2,
                            OrderId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 3,
                            MenuItemId = 4,
                            OrderId = 4,
                            Quantity = 3
                        },
                        new
                        {
                            OrderItemId = 4,
                            MenuItemId = 5,
                            OrderId = 4,
                            Quantity = 3
                        },
                        new
                        {
                            OrderItemId = 5,
                            MenuItemId = 2,
                            OrderId = 3,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            PartySize = 3,
                            ReservationDate = new DateTime(2023, 10, 15, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9857),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            PartySize = 4,
                            ReservationDate = new DateTime(2023, 10, 18, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9895),
                            RestaurantId = 1,
                            TableId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 3,
                            PartySize = 4,
                            ReservationDate = new DateTime(2023, 10, 15, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9897),
                            RestaurantId = 2,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 5,
                            PartySize = 4,
                            ReservationDate = new DateTime(2023, 9, 25, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9899),
                            RestaurantId = 2,
                            TableId = 5
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 1,
                            PartySize = 3,
                            ReservationDate = new DateTime(2023, 8, 15, 19, 9, 2, 84, DateTimeKind.Local).AddTicks(9922),
                            RestaurantId = 1,
                            TableId = 1
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "Nablus-xy",
                            Name = "Sun",
                            OpeningHours = "Mon-Tues,3-4",
                            PhoneNumber = "+972-596-980-765"
                        },
                        new
                        {
                            RestaurantId = 2,
                            Address = "Nablus-xy",
                            Name = "Flower",
                            OpeningHours = "1-4,3-4",
                            PhoneNumber = "+972-591-980-765"
                        },
                        new
                        {
                            RestaurantId = 3,
                            Address = "Nablus-xy",
                            Name = "KFC",
                            OpeningHours = "2-4,3-14",
                            PhoneNumber = "+972-596-920-765"
                        },
                        new
                        {
                            RestaurantId = 4,
                            Address = "California-xy",
                            Name = "Asus",
                            OpeningHours = "2-4,9-20",
                            PhoneNumber = "+972-596-988-765"
                        },
                        new
                        {
                            RestaurantId = 5,
                            Address = "Nablus-xy",
                            Name = "Shabab",
                            OpeningHours = "1-5,3-4",
                            PhoneNumber = "+972-596-980-765"
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 5,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 4,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 6,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 3,
                            RestaurantId = 1
                        });
                });

            modelBuilder.Entity("ResturantReservation.Db.Views.CustomerWithReservationDetails", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RestaurantAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("CustomerWithReservationDetailsView", (string)null);
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Employee", b =>
                {
                    b.HasOne("ResturantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.MenuItem", b =>
                {
                    b.HasOne("ResturantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Order", b =>
                {
                    b.HasOne("ResturantReservation.Db.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantReservation.Db.Entities.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.OrderItem", b =>
                {
                    b.HasOne("ResturantReservation.Db.Entities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantReservation.Db.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Reservation", b =>
                {
                    b.HasOne("ResturantReservation.Db.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Reservation")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturantReservation.Db.Entities.Table", "Table")
                        .WithMany("Reservation")
                        .HasForeignKey("TableId")
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Table", b =>
                {
                    b.HasOne("ResturantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservation");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("ResturantReservation.Db.Entities.Table", b =>
                {
                    b.Navigation("Reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
