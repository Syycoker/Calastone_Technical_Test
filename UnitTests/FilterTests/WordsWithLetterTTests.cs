using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Repositories;
using Moq;

namespace UnitTests.FilterTests;

public class WordsWithLetterTTests
{
  private readonly Mock<IFileHelper> _fileHelper;
  private readonly FilterRepository _filterRepository;

  public WordsWithLetterTTests()
  {
    _fileHelper = new Mock<IFileHelper>();
    _filterRepository = new FilterRepository(_fileHelper.Object);
  }

  [Theory]
  [InlineData("three", "")]
  [InlineData("no word", "no word")]
  [InlineData("no word with letter t", "no word")]
  [InlineData("so managed to put it into one of the cupboards as she fell past it.", "so managed one of cupboards as she fell")]
  public void Returns_words_with_less_than_three_letters(string input, string expectedOutput)
  {
    _fileHelper.Setup(helper => helper.ReadFile(It.IsAny<string>()))
      .Returns(input);

    var filteredInput = _filterRepository.NoWordsWithLetterTFilter("anyFilePath");

    Assert.Equal(expectedOutput, filteredInput);
  }
}