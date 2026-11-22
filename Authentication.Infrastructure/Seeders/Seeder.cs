using Microsoft.EntityFrameworkCore;
using TM.Common.Utils;

namespace Authentication.Infrastructure.Repositories
{
    public abstract class Seeder<TDbContext, TEntity, TKey> 
        where TDbContext : DbContext
        where TEntity : class
    {
        private readonly IEnumerable<TEntity> data;
        private readonly TDbContext dbContext;
        private readonly Func<TEntity, TKey> keySelector;

        private IEnumerable<TEntity> GetUnmatchData()
        {
            IQueryable<TEntity> existings = dbContext.Set<TEntity>();
            return Linq.TakeUnmatchData(data, existings, keySelector).ToList();
        }

        /// <summary>
        /// Initializes a new seeder with the entities to seed, database context, and key selector.
        /// <list type="bullet">
        ///     <item>
        ///     <description>data: The rows / records to seed.</description>
        ///     </item>
        ///     <item>
        ///         <description>dbContext: The database context used to persist the entities.</description>
        ///     </item>
        ///     <item>
        ///         <description>keySelector: The function that identifies the key of an entity.</description>
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="data">The rows / records to seed.</param>
        /// <param name="dbContext">The database context used to persist the entities.</param>
        /// <param name="keySelector">The function that identifies the key of an entity.</param>
        protected Seeder(IEnumerable<TEntity> data, TDbContext dbContext, Func<TEntity, TKey> keySelector)
        {
            Guard.AgainstNull(data, "Seeder data is Empty");
            Guard.AgainstNull(dbContext, "Seeder Database Context is Empty");
            Guard.AgainstNull(keySelector, "Seeder Key Selector is Empty");

            this.data = data;
            this.dbContext = dbContext;
            this.keySelector = keySelector;
        }

        public void Seed()
        {
            var unmatchData = GetUnmatchData();
            if (!unmatchData.Any()) return;

            dbContext.AddRange(unmatchData);
        }

        public async Task SeedAsync()
        {
            var unmatchData = GetUnmatchData();
            if (!unmatchData.Any()) return;

            await dbContext.AddRangeAsync(unmatchData);
        }
    }
}
