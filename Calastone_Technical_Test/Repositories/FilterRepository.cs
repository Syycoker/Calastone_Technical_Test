using Calastone_Technical_Test.Logic;

namespace Calastone_Technical_Test.Repositories;

public class FilterRepository
{
	private readonly string _filePath;
	private readonly List<IFilter> _availableFilters = new List<IFilter>
	{
	};

	public FilterRepository(string filePath)
	{
		_filePath = filePath;
	}

	private string ReadFile(string filePath)
	{
		using var reader = new StreamReader(filePath);
		return reader.ReadToEnd();
	}
}