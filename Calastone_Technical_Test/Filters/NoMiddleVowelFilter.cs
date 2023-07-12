using Calastone_Technical_Test.Logic;

namespace Calastone_Technical_Test.Filters;

public class NoMiddleVowelFilter : IFilter
{
  private readonly IEnumerable<char> _vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

  public IEnumerable<string> Filter(IEnumerable<string> words)
  {
    return words
      .Select(word => word)
      .Where(word => !CanFilter(word));
  }

  public bool CanFilter(string word)
  {
    int length = word.Length;
    int middleIndex = length / 2;

    if (length % 2 == 0)
      return IsVowel(word[middleIndex]) || IsVowel(word[middleIndex - 1]);
    else
      return IsVowel(word[middleIndex]);
  }

  private bool IsVowel(char c)
  {
    char lowerChar = char.ToLower(c);
    return _vowels.Any(vowel => lowerChar.Equals(vowel));
  }
}