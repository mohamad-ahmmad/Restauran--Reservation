namespace ResturantReservation.Db.Repositories.Sql
{
    public interface ISqlRepo
    {
        RestaurantReservationDbContext GetDbContext();
    }
}
