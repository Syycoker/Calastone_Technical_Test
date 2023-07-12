using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Logic;

namespace Calastone_Technical_Test.Repositories;

public class FilterRepository
{
	private readonly IFileHelper _fileHelper;
	private readonly List<IFilter> _availableFilters = new List<IFilter>
	{
		
	};

	public FilterRepository(IFileHelper fileHelper)
	{
		_fileHelper = fileHelper;
	}

	public string FilterInput(string filePath)
	{
		var input = _fileHelper.ReadFile(filePath);

		foreach (var filter in _availableFilters)
      input = filter.Filter(input);

    return input;
	}
}