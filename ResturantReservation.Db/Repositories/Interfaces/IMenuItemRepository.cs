using ResturantReservation.Db.Entities;

namespace ResturantReservation.Db.Repositories.Interfaces
{
    public interface IMenuItemRepository : IBaseRepository<MenuItem>
    {
        public Task<IEnumerable<IGrouping<int, MenuItem>>?> ListOrdersAndMenuItems(int reservationId);
        public Task<IEnumerable<MenuItem>?> ListOrderedMenuItems(int reservationId);
    }
}
