namespace ResturantReservation.Db.Repositories.Sql
{
    public class BaseSqlRepository
    {
        protected readonly RestaurantReservationDbContext _dbContext;
        public BaseSqlRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<bool> SaveChangesAsync()
        {
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
