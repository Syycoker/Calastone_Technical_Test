namespace Calastone_Technical_Test.Logic;

public interface IFilter
{
  public string Filter(IEnumerable<string> words);
}