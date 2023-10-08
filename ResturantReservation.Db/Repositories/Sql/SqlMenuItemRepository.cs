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

        public async Task<IEnumerable<IGrouping<int, MenuItem>>?> ListOrdersAndMenuItems(int reservationId)
        {
            var res =  await
                       (from r in _dbContext.Reservations
                       where r.ReservationId == reservationId
                       join o in _dbContext.Orders
                       on r.ReservationId equals o.ReservationId
                       join oi in _dbContext.OrderItems
                       on o.OrderId equals oi.OrderId
                       join mi in _dbContext.MenuItems
                       on oi.MenuItemId equals mi.ItemId
                       group mi by o.OrderId)
                       .ToListAsync();

            return res;
        }

        public async Task<IEnumerable<MenuItem>?> ListOrderedMenuItems(int reservationId)
        {
            var orderedMenuItems = await _dbContext.Reservations
                .Where(r => r.ReservationId == reservationId)
                .SelectMany(r => r.Orders)
                .SelectMany(o => o.OrderItems)
                .Select(oi => oi.MenuItem)
                .ToListAsync();

            return orderedMenuItems;
        }
    }
}
