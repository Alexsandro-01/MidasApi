namespace MidasApi.DTO;

using MidasApi.Models;
public class TransactionsDto
{
  public decimal TotalCredit { get; set; }
  public decimal TotalDebit { get; set; }
  public decimal Balance { get; set; }
  public Bank Bank {get; set;}
  public List<Transaction> Transactions { get; set; }
}