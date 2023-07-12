namespace Calastone_Technical_Test.Helpers;

public class FileHelper : IFileHelper
{
  public string ReadFile(string filePath)
  {
    using var reader = new StreamReader(filePath);
    return reader.ReadToEnd();
  }
}