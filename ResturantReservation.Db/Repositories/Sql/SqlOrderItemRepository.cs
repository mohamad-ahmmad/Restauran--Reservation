using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Interfaces;

namespace ResturantReservation.Db.Repositories.Sql
{
    internal class SqlOrderItemRepository : BaseSqlRepository, IOrderItemRepository
    {
        public SqlOrderItemRepository(RestaurantReservationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(OrderItem obj)
        {
            await _dbContext.AddAsync(obj);
        }

        public void DeleteAsync(int id)
        {
            _dbContext.OrderItems.Entry(new OrderItem
            {
                OrderItemId = id,
            }).State = EntityState.Deleted;
        }

        public void UpdateAsync(OrderItem obj)
        {
            _dbContext.OrderItems.Entry(obj)
                .State = EntityState.Modified;
        }
    }
}
