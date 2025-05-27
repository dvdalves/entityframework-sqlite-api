using CrudAPI_Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI_Sqlite.Data;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Person> People { get; set; }
}