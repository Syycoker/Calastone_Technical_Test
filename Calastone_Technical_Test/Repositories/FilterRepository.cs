using Calastone_Technical_Test.Logic;

namespace Calastone_Technical_Test.Repositories;

public class FilterRepository
{
	private readonly List<IFilter> _availableFilters = new List<IFilter>
	{
	};

	public void FilterInput(string inputFilePath)
	{
		var file = ReadFile(inputFilePath);
	}

	private string ReadFile(string filePath)
	{
		using var reader = new StreamReader(filePath);
		return reader.ReadToEnd();
	}
}