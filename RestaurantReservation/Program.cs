using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Sql;
using System.Net.Http.Headers;

var dbContext = new RestaurantReservationDbContext();
var dbContext2 = new RestaurantReservationDbContext();


/*
 * Create, delete and update operations on Restaurant
 */
//var resRepo = new SqlRestaurantRepository(dbContext);

//await resRepo.CreateAsync(new Restaurant
//{
//    Name = "Mono",
//    OpeningHours = "1-6,8-23",
//    PhoneNumber = "0598230123",
//    Address = "Nablus-XY"
//});
//await resRepo.SaveChangesAsync();

//await resRepo.UpdateAsync(new Restaurant
//{
//    RestaurantId = 6,
//    Name = "Lolo",
//    OpeningHours = "1-6,8-23",
//    PhoneNumber = "0598230123",
//    Address = "Jenin"
//});
//await resRepo.SaveChangesAsync();

//resRepo.DeleteAsync(6);
//await resRepo.SaveChangesAsync();



/*
 * ListManagers()
 */
//var empRepo = new SqlEmployeeRepository(dbContext);
//var emps = await empRepo.ListManagers();
//emps.ForEach(e => Console.WriteLine(e.FirstName+ " "+ e.LastName));



/*
 * GetReservationsByCustomer(CustomerId)
 */
//var reserRepo = new SqlReservationRepository(dbContext);
//var resevs = await reserRepo.GetReservationsByCustomer(1);

//if(resevs is not null)
//foreach (var item in resevs)
//{
//    Console.WriteLine($"{item.RestaurantId} {item.ReservationDate}");
//}



/*
 * ListOrderedMenuItems(ReservationId)
 */

//var menuItemRepo = new SqlMenuItemRepository(dbContext);
//var items = await menuItemRepo.ListOrderedMenuItems(1);

//if (items is not null)
//    foreach (var item in items)
//    {
//        Console.WriteLine(item.Description);
//    }



/*
 *ListOrdersAndMenuItems
 */
//var menuItemRepo = new SqlMenuItemRepository(dbContext);
//var res = await menuItemRepo.ListOrdersAndMenuItems(1);

//if (res is not null)
//    foreach (var order in res)
//    {
//        Console.WriteLine(order.Key);
//        foreach (var item in order)
//        {
//            Console.WriteLine($" {item.Description}");
//        }
//    }



/*
 * CalculateAverageOrderAmount(EmployeeId)
 */

//var orderRepo = new SqlOrderRepository(dbContext);
//var res = await orderRepo.CalculateAverageOrderAmount(1);
//Console.WriteLine(res);



/*
 * CustomerWithReservationDetailsView
 */
//var view = dbContext.CustomerWithReservationDetailsView.ToList();



/*
 *GetRestaurantTotalRevenue
 */
//dbContext.Restaurants.Select( r=> dbContext.CalculateTotalRevenue(1) ).ToList();



/*
 * CustomersWithPartyGreaterThan
 */
var cusRepo = new SqlCustomerRepository(dbContext);
var cus = await cusRepo.GetCustomersWithPartySizeGreaterThan(3);
{
    
}