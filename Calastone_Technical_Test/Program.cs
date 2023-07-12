using Calastone_Technical_Test.Repositories;

namespace Calastone_Technical_Test;

public static class Program
{
  public static void Main(string[] args)
  {
    var filterRepository = new FilterRepository();
    filterRepository.FilterInput("./Assets/file.txt");
  }
}