using OFXParser.Entities;

namespace MidasApi.Services;
using MidasApi.Models;
using MidasApi.Interfaces;


public class BalanceService : IBalanceService
{
  public List<Transaction> Create(IFormFile formFile)
  {
    string filePath = WriteFile(formFile);

    return ReadFile(filePath);
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

  public List<Transaction> ReadFile(string filePath)
  {
    Extract ofxDoc = OFXParser.Parser.GenerateExtract(filePath);

    if (ofxDoc == null)
    {
      throw new FileNotFoundException($"File \"{filePath}\" not found");
    }

      var transactions = from operation in ofxDoc.Transactions
                         select new Transaction(
                          operation.Type,
                          operation.TransactionValue,
                          operation.Date,
                          operation.Description,
                          operation.Id
                         );

      return transactions.ToList();    
  }
}