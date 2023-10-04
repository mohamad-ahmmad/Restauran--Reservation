using Microsoft.EntityFrameworkCore;
using ResturantReservation.Db.Entities;
using ResturantReservation.Db.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantReservation.Db.Repositories.Sql
{
    public class SqlTableRepository : ITableRepository
    {
        private readonly RestaurantReservationDbContext _dbContext;
        public SqlTableRepository(RestaurantReservationDbContext dbContext) 
        {
            _dbContext = dbContext;
            
        }

        public async Task CreateAsync(Table obj)
        {
            await _dbContext.Tables.AddAsync(obj);
        }

        public void DeleteAsync(int id)
        {
            _dbContext.Tables.Entry(new Table { TableId = id }).State = EntityState.Deleted;
        }

        public void UpdateAsync(Table obj)
        {
            _dbContext.Tables.Entry(obj).State = EntityState.Modified;
        }
        public async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
