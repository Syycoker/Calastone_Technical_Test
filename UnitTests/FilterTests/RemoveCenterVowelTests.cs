using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Repositories;
using Moq;

namespace UnitTests.FilterTests;

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
  [InlineData("clean", "")]
  [InlineData("currently", "")]
  [InlineData("rather", "rather")]
  [InlineData("Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice", "beginning to very tired of sitting by sister on the bank, and of having nothing to once or")]
  public void Returns_words_with_no_middle_vowel(string input, string expectedOutput)
  {
    _fileHelper.Setup(helper => helper.ReadFile(It.IsAny<string>()))
      .Returns(input);

    var filteredInput = _filterRepository.NoMiddleVowelFilter("anyFilePath");

    Assert.Equal(expectedOutput, filteredInput);
  }
}