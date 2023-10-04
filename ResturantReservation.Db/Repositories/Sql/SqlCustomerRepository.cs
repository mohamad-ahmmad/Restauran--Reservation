using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Interfaces;

namespace ResturantReservation.Db.Repositories.Sql
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        public SqlCustomerRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Customer obj)
        {
            await _dbContext.Customers.AddAsync(obj);
        }

        public void DeleteAsync(int id)
        {
            _dbContext.Customers.Entry(new Customer
            {
                CustomerId = id,
            }).State = EntityState.Deleted;
        }

        public void UpdateAsync(Customer obj)
        {
            _dbContext.Customers.Entry(obj).State = EntityState.Modified;
        }

        public async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
