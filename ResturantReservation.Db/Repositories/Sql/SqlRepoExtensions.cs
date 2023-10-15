namespace ResturantReservation.Db.Repositories.Sql
{
    public static class SqlRepoExtensions
    {
        [Obsolete]
        public static async Task CreateAsync<T>(this ISqlRepo repo, T obj)
        {
            if (repo is null || obj is null)
            {
                throw new ArgumentNullException();
            }

            var context = repo.GetDbContext();
            await context.AddAsync(obj);
        }

    }
}
