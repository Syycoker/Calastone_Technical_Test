using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Repositories;
using Moq;

namespace UnitTests.FilterTests;

public class MiddleVowelTests
{
  private readonly Mock<IFileHelper> _fileHelper;
  private readonly FilterRepository _filterRepository;

  public MiddleVowelTests()
  {
    _fileHelper = new Mock<IFileHelper>();
    _filterRepository = new FilterRepository(_fileHelper.Object);
  }

  [Theory]
  [InlineData("clean", "")]
  [InlineData("what", "")]
  [InlineData("currently", "")]
  [InlineData("rather", "rather")]
  public void Returns_words_with_no_middle_vowel(string input, string expectedOutput)
  {
    _fileHelper.Setup(helper => helper.ReadFile(It.IsAny<string>()))
      .Returns(input);

    var filteredInput = _filterRepository.NoMiddleVowelFilter("anyFilePath");

    Assert.Equal(expectedOutput, filteredInput);
  }
}