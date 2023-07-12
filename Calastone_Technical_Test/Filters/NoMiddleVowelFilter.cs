using Calastone_Technical_Test.Logic;

namespace Calastone_Technical_Test.Filters;

public class NoMiddleVowelFilter : IFilter
{
  private readonly IEnumerable<char> _vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

  public string Filter(IEnumerable<string> words)
  {
    throw new NotImplementedException();
  }
}