using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Interfaces;

namespace ResturantReservation.Db.Repositories.Sql
{
    public class SqlReservationRepository : BaseSqlRepository, IReservationRepository
    {
        public SqlReservationRepository(RestaurantReservationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(Reservation obj)
        {
            await _dbContext.Reservations.AddAsync(obj);
        }

        public void DeleteAsync(int id)
        {
            _dbContext.Reservations.Entry(new Reservation
            {
                ReservationId = id
            }).State = EntityState.Deleted;
        }


        public void UpdateAsync(Reservation obj)
        {
            _dbContext.Reservations.Entry(obj).State = EntityState.Modified;
        }
        public async Task<IEnumerable<Reservation>?> GetReservationsByCustomer(int customerId)
        {
            var customer= await _dbContext.Customers
                .Include(x => x.Reservations)
                .Where(c => c.CustomerId == customerId)
                .FirstOrDefaultAsync();

            return customer?.Reservations;
        }
    }
}
