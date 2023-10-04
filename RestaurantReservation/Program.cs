


using ResturantReservation.Db;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Sql;
using System.Threading.Channels;

var dbContext = new RestaurantReservationDbContext();

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
  
