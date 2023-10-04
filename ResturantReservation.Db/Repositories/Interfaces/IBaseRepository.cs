namespace ResturantReservation.Db.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T obj);
        void UpdateAsync(T obj);
        void DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
