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
	};

	public FilterRepository(IFileHelper fileHelper)
	{
		_fileHelper = fileHelper;
	}

  public string NoMiddleVowelFilter(string filePath)
  {
		var filteredFilters = _availableFilters
			.Where(filter => filter.GetType() == typeof(NoMiddleVowelFilter));

		return FilterInput(filteredFilters, filePath);
  }

  private string FilterInput(IEnumerable<IFilter> filters, string filePath)
	{
		var input = _fileHelper.ReadFile(filePath);

		foreach (var filter in filters)
      input = filter.Filter(input);

    return input;
	}
}