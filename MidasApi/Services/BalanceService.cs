using OFXParser.Entities;

namespace MidasApi.Services;
using MidasApi.Models;
using MidasApi.Interfaces;
using MidasApi.Repositories;
using MidasApi.DTO;

public class BalanceService : IBalanceService
{
  protected readonly TransactionRepository _repository;

  public BalanceService(TransactionRepository transactionRepository)
  {
    _repository = transactionRepository;
  }

  public void Create(IFormFile formFile)
  {
    string filePath = WriteFile(formFile);

    TransactionsDto transactionsDto = ReadFile(filePath);

    _repository.Create(transactionsDto.Transactions);
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