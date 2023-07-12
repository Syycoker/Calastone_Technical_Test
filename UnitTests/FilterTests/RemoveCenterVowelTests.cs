using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Repositories;
using Moq;

namespace UnitTests
{
  public class RemoveCenterVowelTests
  {
    private readonly Mock<IFileHelper> _fileHelper;
    private readonly FilterRepository _filterRepository;

    public RemoveCenterVowelTests()
    {
      _fileHelper = new Mock<IFileHelper>();
      _filterRepository = new FilterRepository(_fileHelper.Object);
    }

    [Theory]
    [InlineData("Alice", "")]
    public void Returns_a_single_word_with_no_middle_vowel(string input, string expectedOutput)
    {
      _fileHelper.Setup(helper => helper.ReadFile(It.IsAny<string>()))
        .Returns(input);

      var filteredInput = _filterRepository.NoMiddleVowelFilter("anyFilePath");

      Assert.Equal(expectedOutput, filteredInput);
    }
  }
}