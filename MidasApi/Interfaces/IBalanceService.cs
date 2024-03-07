namespace MidasApi.Interfaces;

using MidasApi.DTO;
using MidasApi.Models;

public interface IBalanceService
{
  public void Create(IFormFile formFile);
  public string WriteFile(IFormFile formFile);
  public TransactionsDto ReadFile(string filePath);
}