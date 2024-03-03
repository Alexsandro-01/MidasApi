namespace MidasApi.Services;

public class BalanceService
{
  public bool WriteFile(IFormFile formFile)
  {
    if (formFile.Length > 0)
    {
      var filePath = Path.Combine("Assets", formFile.FileName);

      using Stream stream = new FileStream(filePath, FileMode.Create);
      formFile.CopyTo(stream);

      return true;
    }

    return false;
  }
}