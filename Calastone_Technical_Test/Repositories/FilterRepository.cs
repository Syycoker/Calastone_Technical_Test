using Calastone_Technical_Test.Filters;
using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Logic;

namespace Calastone_Technical_Test.Repositories;

public class FilterRepository
{
	private readonly IFileHelper _fileHelper;
	private readonly List<IFilter> _availableFilters = new List<IFilter>
	{
		new NoMiddleVowelFilter(),
		new NoLessThanThreeLettersFilter(),
    new NoWordsWithLetterTFilter()
	};

	public FilterRepository(IFileHelper fileHelper)
	{
		_fileHelper = fileHelper;
	}

	public string AllFilters(string filePath)
	=> FilterInput(_availableFilters, filePath);

  public string NoMiddleVowelFilter(string filePath)
  => FilterInput(GetFilter<NoMiddleVowelFilter>(), filePath);

  public string NoLessThanThreeLetterWordsFilter(string filePath)
	=> FilterInput(GetFilter<NoLessThanThreeLettersFilter>(), filePath);

  public string NoWordsWithLetterTFilter(string filePath)
  => FilterInput(GetFilter<NoWordsWithLetterTFilter>(), filePath);

  private string FilterInput(IEnumerable<IFilter> filters, string filePath)
	{
		const string delimiter = " ";
		var input = _fileHelper.ReadFile(filePath);

		var splitInput = input.Split(delimiter);

		foreach (var filter in filters)
      splitInput = filter.Filter(splitInput).ToArray();

    return string.Join(delimiter, splitInput);
	}

  private IEnumerable<IFilter> GetFilter<T>() where T : IFilter
    => _availableFilters
    .Where(filter => filter.GetType() == typeof(T));
}