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
    }
}
