using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Interfaces;

namespace ResturantReservation.Db.Repositories.Sql
{
    public class SqlOrderRepository : BaseSqlRepository, IOrderRepository
    {
        public SqlOrderRepository(RestaurantReservationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(Order obj)
        {
            await _dbContext.AddAsync(obj);
        }

        public void DeleteAsync(int id)
        {
            _dbContext.Orders.Entry(new Order
            {
                OrderId = id
            }).State = EntityState.Deleted;
        }

        public void UpdateAsync(Order obj)
        {
            _dbContext.Orders.Entry(obj).State = EntityState.Modified;
        }

        public async Task<decimal?> CalculateAverageOrderAmount(int employeeId)
        {
            var avgAmount = await 
                            _dbContext.Orders
                            .Where(o => o.EmployeeId == employeeId)
                            .AverageAsync(o => o.TotalAmount);

            return avgAmount;
        }
    }
}
