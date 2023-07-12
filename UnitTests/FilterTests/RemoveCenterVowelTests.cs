using Calastone_Technical_Test.Repositories;

namespace UnitTests
{
  public class RemoveCenterVowelTests
  {
    private readonly string _filePath;
    private readonly FilterRepository _filterRepository;

    public RemoveCenterVowelTests()
    {
      _filePath = "./Assets/file.txt";
      _filterRepository = new FilterRepository();
    }

    [Theory]
    [InlineData("Alice", "")]
    public void Returns_a_single_word_with_no_middle_vowel(string input, string expectedOutput)
    {
      var actualWords = _filterRepository.FilterInput(_filePath);
      Assert.True(actualWords.Count == expectedOutput.Length);
    }
  }
}