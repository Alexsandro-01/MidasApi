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
  [Column(TypeName = "varchar(200)")]
  public string Description {get; set;}
  [Column(TypeName = "varchar(200)")]
  public string TransactionId {get; set;}
  [ForeignKey("BankId")]
  public int BankId {get; set;}
  public Bank Bank {get; set;}
}