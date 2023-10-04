using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Interfaces;

namespace ResturantReservation.Db.Repositories.Sql
{
    public class SqlMenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        public SqlMenuItemRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(MenuItem obj)
        {
            await _dbContext.MenuItems.AddAsync(obj);
        }

        public void DeleteAsync(int id)
        {
            _dbContext.MenuItems.Entry(new MenuItem
            {
                ItemId = id,
            }).State = EntityState.Deleted;
        }

        public async Task<bool> SaveChangesAsync()
        {
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public void UpdateAsync(MenuItem obj)
        {
            _dbContext.MenuItems.Entry(obj).State = EntityState.Modified;
        }
    }
}
