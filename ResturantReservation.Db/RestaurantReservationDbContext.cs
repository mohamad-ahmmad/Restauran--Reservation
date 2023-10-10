using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Views;

namespace ResturantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CustomerWithReservationDetails> CustomerWithReservationDetailsView {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-79JQ2L1; Initial Catalog=RestaurantReservationCore; Integrated Security = SSPI;TrustServerCertificate=true")
            .LogTo(Console.WriteLine,
                    new[] { DbLoggerCategory.Database.Command.Name },
                    LogLevel.Information)
            .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<CustomerWithReservationDetails>()
                .HasNoKey()
                .ToView("CustomerWithReservationDetailsView");                                                    

            modelBuilder.Entity<Reservation>()
                .HasKey(e => e.ReservationId);
            modelBuilder.Entity<Reservation>()
                .HasOne("Table")
                .WithMany("Reservation")
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Table>()
                .HasKey(t => t.TableId);

            modelBuilder.Entity<Restaurant>()
                .HasKey(r => r.RestaurantId);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<MenuItem>()
                .HasKey(mi => mi.ItemId);
            modelBuilder.Entity<MenuItem>()
                .Property(p => p.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderItem>()
                .HasKey(o => o.OrderItemId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Order)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(19, 4);


            Seeding(modelBuilder);
        }
        protected virtual void Seeding(ModelBuilder mb)
        {
            mb.Entity<Restaurant>()
                .HasData
                (
                    new Restaurant
                    {
                        RestaurantId = 1,
                        Name = "Sun",
                        OpeningHours = "Mon-Tues,3-4",
                        PhoneNumber = "+972-596-980-765",
                        Address = "Nablus-xy",
                    },
                    new Restaurant
                    {
                        RestaurantId = 2,
                        Name = "Flower",
                        OpeningHours = "1-4,3-4",
                        PhoneNumber = "+972-591-980-765",
                        Address = "Nablus-xy",
                    },
                    new Restaurant
                    {
                        RestaurantId = 3,
                        Name = "KFC",
                        OpeningHours = "2-4,3-14",
                        PhoneNumber = "+972-596-920-765",
                        Address = "Nablus-xy",
                    },
                    new Restaurant
                    {
                        RestaurantId = 4,
                        Name = "Asus",
                        OpeningHours = "2-4,9-20",
                        PhoneNumber = "+972-596-988-765",
                        Address = "California-xy",
                    },
                    new Restaurant
                    {
                        RestaurantId = 5,
                        Name = "Shabab",
                        OpeningHours = "1-5,3-4",
                        PhoneNumber = "+972-596-980-765",
                        Address = "Nablus-xy",
                    }
                );

            mb.Entity<Employee>()
            .HasData
            (
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "moh",
                    LastName = "ahmad",
                    Position = "cashier",
                    RestaurantId = 1,
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "salah",
                    LastName = "tan",
                    Position = "chief",
                    RestaurantId = 1,
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "moh",
                    LastName = "issa",
                    Position = "cashier",
                    RestaurantId = 2,
                },
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "ahmad",
                    LastName = "nazzal",
                    Position = "chief",
                    RestaurantId = 2,
                },
                new Employee
                {
                    EmployeeId = 5,
                    FirstName = "james",
                    LastName = "mer'e",
                    Position = "owner",
                    RestaurantId = null,
                }
            );

            mb.Entity<Table>()
                .HasData
                (
                    new Table
                    {
                        TableId = 1,
                        Capacity = 4,
                        RestaurantId = 1,
                    },
                    new Table
                    {
                        TableId = 2,
                        Capacity = 5,
                        RestaurantId = 1,
                    },
                    new Table
                    {
                        TableId = 3,
                        Capacity = 4,
                        RestaurantId = 2,
                    },
                    new Table
                    {
                        TableId = 4,
                        Capacity = 6,
                        RestaurantId = 2,
                    },
                    new Table
                    {
                        TableId = 5,
                        Capacity = 3,
                        RestaurantId = 1,
                    }
                );

            mb.Entity<Customer>()
                .HasData
                (
                    new Customer
                    {
                        CustomerId = 1,
                        Email = "boot@gmail.com",
                        FirstName = "steven",
                        LastName = "loyyd",
                        PhoneNumber = "0234367290",
                    },
                    new Customer
                    {
                        CustomerId = 2,
                        Email = "shot@gmail.com",
                        FirstName = "jake",
                        LastName = "daniel",
                        PhoneNumber = "0234567890",
                    },
                    new Customer
                    {
                        CustomerId = 3,
                        Email = "dot@gmail.com",
                        FirstName = "kani",
                        LastName = "adam",
                        PhoneNumber = "0234567891",
                    },
                    new Customer
                    {
                        CustomerId = 4,
                        Email = "hot@gmail.com",
                        FirstName = "zoh",
                        LastName = "noah",
                        PhoneNumber = "1234367891",
                    },
                    new Customer
                    {
                        CustomerId = 5,
                        Email = "kot@gmail.com",
                        FirstName = "soh",
                        LastName = "saleh",
                        PhoneNumber = "1434467492",
                    }
                );

            mb.Entity<Reservation>()
                .HasData
                (
                    new Reservation
                    {
                        ReservationId = 1,
                        RestaurantId = 1,
                        CustomerId = 1,
                        TableId = 1,
                        PartySize = 3,
                        ReservationDate = DateTime.Now,
                    },
                    new Reservation
                    {
                        ReservationId = 2,
                        RestaurantId = 1,
                        CustomerId = 2,
                        TableId = 2,
                        PartySize = 4,
                        ReservationDate = DateTime.Now.AddDays(3),
                    },
                    new Reservation
                    {
                        ReservationId = 3,
                        RestaurantId = 2,
                        CustomerId = 3,
                        TableId = 4,
                        PartySize = 4,
                        ReservationDate = DateTime.Now,
                    },
                    new Reservation
                    {
                        ReservationId = 4,
                        RestaurantId = 2,
                        CustomerId = 5,
                        TableId = 5,
                        PartySize = 4,
                        ReservationDate = DateTime.Now.AddDays(-20),
                    },
                    new Reservation
                    {
                        ReservationId = 5,
                        RestaurantId = 1,
                        CustomerId = 1,
                        TableId = 1,
                        PartySize = 3,
                        ReservationDate = DateTime.Now.AddMonths(-2),
                    }
                );

            mb.Entity<Order>()
            .HasData
            (
                new Order
                {
                    OrderId = 1,
                    ReservationId= 1,
                    OrderDate = DateTime.Now,
                    EmployeeId = 1,
                    TotalAmount = 10.3M,
                },
                new Order
                {
                    OrderId = 2,
                    ReservationId = 3,
                    OrderDate = DateTime.Now.AddDays(-10),
                    EmployeeId = 3,
                    TotalAmount = 30.3M,
                },
                new Order
                {
                    OrderId = 3,
                    ReservationId = 2,
                    OrderDate = DateTime.Now.AddDays(-20),
                    EmployeeId = 2,
                    TotalAmount = 30.3M,
                },
                new Order
                {
                    OrderId = 4,
                    ReservationId = 4,
                    OrderDate = DateTime.Now,
                    EmployeeId = 3,
                    TotalAmount = 70.3M,
                }
            );

            mb.Entity<OrderItem>()
                .HasData
                (
                    new OrderItem
                    {
                        OrderItemId = 1,
                        MenuItemId = 1,
                        OrderId = 1,
                        Quantity = 2,
                    },
                    new OrderItem
                    {
                        OrderItemId = 2,
                        MenuItemId = 2,
                        OrderId = 2,
                        Quantity = 1,
                    },
                    new OrderItem
                    {
                        OrderItemId = 3,
                        MenuItemId = 4,
                        OrderId = 4,
                        Quantity = 3,
                    },
                    new OrderItem
                    {
                        OrderItemId = 4,
                        MenuItemId = 5,
                        OrderId = 4,
                        Quantity = 3,
                    },
                    new OrderItem
                    {
                        OrderItemId = 5,
                        MenuItemId = 2,
                        OrderId = 3,
                        Quantity = 2,
                    }
                );

            mb.Entity<MenuItem>()
            .HasData
            (
                new MenuItem
                {
                    ItemId = 1,
                    Description = "lemonade",
                    Price = 10.2M,
                    RestaurantId = 1,
                },
                new MenuItem
                {
                    ItemId = 2,
                    Description = "chicken",
                    Price = 22.2M,
                    RestaurantId = 1,
                },
                new MenuItem
                {
                    ItemId = 3,
                    Description = "water",
                    Price = 5.2M,
                    RestaurantId = 1,
                },
                new MenuItem
                {
                    ItemId = 4,
                    Description = "lemonade",
                    Price = 10.2M,
                    RestaurantId = 2,
                },
                new MenuItem
                {
                    ItemId = 5,
                    Description = "steak",
                    Price = 50.2M,
                    RestaurantId = 2,
                }
            );


        }
    }
}