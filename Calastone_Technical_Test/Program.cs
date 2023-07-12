using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Repositories;

namespace Calastone_Technical_Test;

public static class Program
{
  public static void Main(string[] args)
  {
    var filterRepository = new FilterRepository(new FileHelper());
    filterRepository.NoMiddleVowelFilter("./Assets/file.txt");
  }
}