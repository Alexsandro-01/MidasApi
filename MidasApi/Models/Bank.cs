using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MidasApi.Models;

public class Bank
{
  [Key]
  public int Id {get; set;}
  [Column(TypeName="varchar(50)")]
  public string AccountCode {get; set;}
  [Column(TypeName = "varchar(10)")]
  public string? AgencyCode {get; set;}
  public int BankCode {get; set;}
  [Column(TypeName = "varchar(100)")]
  public string BankName {get; set;}
  public ICollection<Transaction> Transactions {get; set;}
}