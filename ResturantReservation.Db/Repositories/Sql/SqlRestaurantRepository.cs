using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Interfaces;

namespace ResturantReservation.Db.Repositories.Sql
{
    public class SqlRestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        public SqlRestaurantRepository(RestaurantReservationDbContext context)
        {
            _dbContext = context;
        }

        public async Task CreateAsync(Restaurant obj)
        {
            await _dbContext.Restaurants.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteAsync(int id)
        {
            _dbContext.Restaurants.Entry(new Restaurant
            {
                RestaurantId = id
            }).State = EntityState.Deleted;

        }

        public async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        public void UpdateAsync(Restaurant obj)
        {
            _dbContext.Restaurants.Entry(obj).State = EntityState.Modified;
        }

    }
}
