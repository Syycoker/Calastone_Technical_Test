using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Repositories;
using Moq;

namespace UnitTests.FilterTests;

public class RemoveLessThanThreeLetterWordsTests
{
  private readonly Mock<IFileHelper> _fileHelper;
  private readonly FilterRepository _filterRepository;

  public RemoveLessThanThreeLetterWordsTests()
  {
    _fileHelper = new Mock<IFileHelper>();
    _filterRepository = new FilterRepository(_fileHelper.Object);
  }

  [Theory]
  [InlineData("three", "three")]
  [InlineData("two", "two")]
  [InlineData("on", "")]
  [InlineData("The light was not turned on or was it not", "The light was not turned was not")]
  public void Returns_words_with_no_middle_vowel(string input, string expectedOutput)
  {
    _fileHelper.Setup(helper => helper.ReadFile(It.IsAny<string>()))
      .Returns(input);

    var filteredInput = _filterRepository.NoLessThanThreeLetterWordsFilter("anyFilePath");

    Assert.Equal(expectedOutput, filteredInput);
  }
}