namespace Calastone_Technical_Test.Logic;

public interface IFilter
{
  public IEnumerable<string> Filter(IEnumerable<string> words);
  public bool CanFilter(string word);
}