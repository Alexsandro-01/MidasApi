using MidasApi.Models;
using MidasApi.Repositories;

namespace MidasApi.Services;

public class BankService
{
  protected readonly BankRepository _repository;

  public BankService(BankRepository bankRepository)
  {
    _repository = bankRepository;
  }

  public Bank Create(Bank bank)
  {
    var newBank = _repository.Create(bank);
    return newBank;
  }

  public Bank Update(Bank bank)
  {
    _repository.Update(bank);
    return bank;
  }

  public Bank? GetBankByName(string bankName)
  {
    var bank = _repository.GetBankByName(bankName);

    return bank;
  }
}