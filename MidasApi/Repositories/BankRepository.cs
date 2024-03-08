using Midas.Models;
using MidasApi.Models;

namespace MidasApi.Repositories;

public class BankRepository
{
  protected readonly DataBaseContext _context;

  public BankRepository(DataBaseContext dataBaseContext)
  {
    _context = dataBaseContext;
  }

  public Bank Create(Bank bank)
  {
    _context.Add(bank);
    _context.SaveChanges();

    return bank;
  }

  public Bank Update(Bank bank)
  {
    _context.Update(bank);
    _context.SaveChanges();

    return bank;
  }

  public Bank? GetBankByName(string bankName)
  {
    var bank = _context.Banks.Where(b => b.BankName == bankName);

    return bank.FirstOrDefault();
  }
}