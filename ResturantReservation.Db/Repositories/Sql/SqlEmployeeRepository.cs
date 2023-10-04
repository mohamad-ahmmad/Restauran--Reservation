using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Interfaces;

namespace ResturantReservation.Db.Repositories.Sql
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        public SqlEmployeeRepository(RestaurantReservationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Employee obj)
        {
            await _dbContext.Employees.AddAsync(obj);
        }

        public void DeleteAsync(int id)
        {
            _dbContext.Employees.Entry(new Employee
            {
                EmployeeId = id
            }).State = EntityState.Deleted;
        }

        public async Task<bool> SaveChangesAsync()
        {
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public void UpdateAsync(Employee obj)
        {
            _dbContext.Employees.Entry(obj).State = EntityState.Modified;
        }
        public async Task<List<Employee>> ListManagers()
        {
            return await _dbContext.Employees
                .Where(e=>e.Position == "manager")
                .ToListAsync();
        }
    }
}
