namespace MidasApi.Interfaces;

using MidasApi.Models;

public interface IBalanceService
{
  public List<Transaction> Create(IFormFile formFile);
  public string WriteFile(IFormFile formFile);
  public List<Transaction> ReadFile(string filePath);
}