using CrudAPI_Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI_Sqlite.Data
{
    public class Context : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}