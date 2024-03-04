namespace MidasApi;

using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using MidasApi.Interfaces;

[ApiController]
[Route("[controller]")]
public class BalanceController : ControllerBase
{
  private readonly IBalanceService _service;

  public BalanceController(IBalanceService balanceService)
  {
    _service = balanceService;
  }
  
  [HttpPost]
  public IActionResult CreateBalance(IFormFile formFile)
  {
    var balance = _service.Create(formFile);

    return Created("Balance",balance);
  }
}