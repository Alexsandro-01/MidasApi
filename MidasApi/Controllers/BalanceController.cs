using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace MidasApi;

[ApiController]
[Route("[controller]")]
public class BalanceController : ControllerBase
{
  [HttpPost]
  public IActionResult InsertBalance(IFormFile formFile)
  {
    

    return Ok();
  }
}