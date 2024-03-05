using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidasApi.Models;
public class Transaction
{
  [Key]
  public int Id {get; set;}
  [Column(TypeName = "varchar(50)")]
  public string Type {get; set;}
  public double Value {get; set;}
  public DateTime Date {get; set;}
  [Column(TypeName = "varchar(100)")]
  public string Description {get; set;}
  [Column(TypeName = "varchar(100)")]
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

  public Transaction() {}
}