using Calastone_Technical_Test.Logic;

namespace Calastone_Technical_Test.Filters;

public class NoWordsWithLetterTFilter : IFilter
{
  public IEnumerable<string> Filter(IEnumerable<string> words)
  {
    return words
    .Select(word => word)
    .Where(word => !CanFilter(word));
  }

  public bool CanFilter(string word)
    => word
    .ToLower()
    .Any(letter => letter.Equals('t'));
}