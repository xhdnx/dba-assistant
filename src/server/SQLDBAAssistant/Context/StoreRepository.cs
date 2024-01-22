using Microsoft.EntityFrameworkCore;
using SQLDBAAssistant.Models.SQLiteModels;

namespace SQLDBAAssistant.Context
{
    public class StoreRepository : IStoreRepository
    {
        protected MasterContext _context;
        public StoreRepository(MasterContext context)
        {
            _context = context;
        }
        public Query? GetQueryByTitle(string title)
        {
            return _context.Queries.FirstOrDefault(q => q.Title == title);
        }

        public DbSet<Query> GetAllQueryName()
        {
            return _context.Queries;
        }
    }
}
