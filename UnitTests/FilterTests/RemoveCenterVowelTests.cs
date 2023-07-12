using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Repositories;
using Moq;

namespace UnitTests
{
  public class RemoveCenterVowelTests
  {
    private readonly string _filePath;
    private readonly FilterRepository _filterRepository;
    private readonly Mock<IFileHelper> _fileHelper;

    public RemoveCenterVowelTests()
    {
      _filePath = "./Assets/file.txt";
      _filterRepository = new FilterRepository();
      _fileHelper = new Mock<IFileHelper>();
    }

    [Theory]
    [InlineData("Alice", "")]
    public void Returns_a_single_word_with_no_middle_vowel(string input, string expectedOutput)
    {
      _fileHelper.Setup(helper => helper.ReadFile(It.IsAny<string>()))
        .Returns(input);

      var filteredInput = _filterRepository.FilterInput(_filePath);

      Assert.Equal(expectedOutput, filteredInput);
    }
  }
}