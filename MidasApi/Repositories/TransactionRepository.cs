using Microsoft.EntityFrameworkCore;
using Midas.Models;
using MidasApi.Models;

namespace MidasApi.Repositories;

public class TransactionRepository
{
  protected readonly DataBaseContext _context;

  public TransactionRepository(DataBaseContext dbContext)
  {
    _context = dbContext;
  }

  public void Create(List<Transaction> transactions)
  {
    foreach (var item in transactions)
    {
      _context.Add(item);
    }

    _context.SaveChanges();
  }

  public List<Transaction> GetTransactionsByMonth(string yearAndMonth)
  {
    string[] listWithYearMonth = yearAndMonth.Split("/");
    var month = int.Parse(listWithYearMonth[0]);
    var year = int.Parse(listWithYearMonth[1]);

    var transactions = _context.Transactions.Where(t => t.Date.Month == month).Where(t => t.Date.Year == year);

    return transactions.ToList();
  }
}