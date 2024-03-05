using Microsoft.EntityFrameworkCore;
using MidasApi.Models;

namespace Midas.Models;

public class DataBaseContext : DbContext
{
  public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {
  }

  public DataBaseContext()
  {
    this.Database.EnsureCreated();
  }

  public DbSet<Transaction> Transactions {get; set;}

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") + "Database=midasdb;";

    optionsBuilder.UseNpgsql(connectionString);
  }
}

