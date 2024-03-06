namespace MidasApi.Interfaces;

using MidasApi.Models;

public interface IBalanceService
{
  public void Create(IFormFile formFile);
  public string WriteFile(IFormFile formFile);
  public List<Transaction> ReadFile(string filePath);
}