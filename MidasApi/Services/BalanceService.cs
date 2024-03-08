using OFXParser.Entities;

namespace MidasApi.Services;
using MidasApi.Models;
using MidasApi.Interfaces;
using MidasApi.Repositories;
using MidasApi.DTO;

public class BalanceService : IBalanceService
{
  protected readonly TransactionRepository _repository;
  protected readonly BankService _bankService;

  public BalanceService(
    TransactionRepository transactionRepository,
    BankService bankService  
  )
  {
    _repository = transactionRepository;
    _bankService = bankService;
  }

  public void Create(IFormFile formFile)
  {
    string filePath = WriteFile(formFile);

    TransactionsDto transactionsDto = ReadFile(filePath);

    // cria relacionamento entre as models do Bank
    // e da Transaction.
    transactionsDto.Bank.Transactions = transactionsDto.Transactions;

    var existsBank = _bankService.GetBankByName(transactionsDto.Bank.BankName);

    if (existsBank is null)
    {
      _bankService.Create(transactionsDto.Bank);
      return;
    }

    // Adiciona as transactions para relacionamento
    // com o bank do BD
    existsBank.Transactions = transactionsDto.Transactions;

    _bankService.Update(existsBank);
  }

  public string WriteFile(IFormFile formFile)
  {
    if (formFile.Length > 0)
    {
      var filePath = Path.Combine("Assets", formFile.FileName);

      using Stream stream = new FileStream(filePath, FileMode.Create);
      formFile.CopyTo(stream);

      return filePath;
    }

    throw new ArgumentException("File size is 0");
  }

  public TransactionsDto ReadFile(string filePath)
  {
    Extract ofxDoc = OFXParser.Parser.GenerateExtract(filePath);

    if (ofxDoc == null)
    {
      throw new FileNotFoundException($"File \"{filePath}\" not found");
    }

    Bank bank = new() {
      AccountCode = ofxDoc.BankAccount.AccountCode,
      AgencyCode = ofxDoc.BankAccount.AgencyCode,
      BankCode = ofxDoc.BankAccount.Bank.Code,
      BankName = ofxDoc.Header.BankName
    };

    var transactions = from operation in ofxDoc.Transactions
                        select new Transaction() {
                        Type = operation.Type,
                        Value = operation.TransactionValue,
                        Date = operation.Date.ToUniversalTime(),
                        Description = operation.Description,
                        TransactionId = operation.Id
                        };

    return new TransactionsDto() {
      Bank = bank,
      Transactions = transactions.ToList()
    };    
  }
}