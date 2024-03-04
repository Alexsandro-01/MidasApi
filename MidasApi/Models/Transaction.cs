namespace MidasApi.Models;
public class Transaction
{
  public string Type {get; set;}
  public double Value {get; set;}
  public DateTime Date {get; set;}
  public string Description {get; set;}
  public string TransactionId {get; set;}

  public Transaction(
    string type,
    double value,
    DateTime date,
    string description,
    string transactionId
  )
  {
    Type = type;
    Value = value / 100;
    Date = date;
    Description = description;
    TransactionId = transactionId;
  }
}