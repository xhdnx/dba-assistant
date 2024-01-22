using Microsoft.EntityFrameworkCore;
using SQLDBAAssistant.Models.SQLiteModels;

namespace SQLDBAAssistant.Context
{
    public interface IStoreRepository
    {
        Query? GetQueryByTitle(string title);
        DbSet<Query> GetAllQueryName();
    }
}
