using Calastone_Technical_Test.Helpers;
using Calastone_Technical_Test.Repositories;
using Moq;

namespace UnitTests.FilterTests;

public class AllFiltersTests
{
  private readonly Mock<IFileHelper> _fileHelper;
  private readonly FilterRepository _filterRepository;

  public AllFiltersTests()
  {
    _fileHelper = new Mock<IFileHelper>();
    _filterRepository = new FilterRepository(_fileHelper.Object);
  }

  [Theory]
  [InlineData("tired of sitting by her sister on the bank", "")]
  [InlineData("and of having nothing to do", "and")]
  [InlineData("for killing somebody, one she fell", "killing somebody, one she")]
  [InlineData("Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice\r\nshe had peeped into the book her sister was reading, but it had no pictures or conversations in it, 'and what is the\r\nuse of a book,' thought Alice 'without pictures or conversation?'So she was considering in her own mind (as well\r\nas she could, for the hot day made her feel very sleepy and stupid), whether the pleasure of making a daisy chain\r\nwould be worth the trouble of getting up and picking the daisies, when suddenly a White Rabbit with pink eyes\r\nran close by her.There was nothing so very remarkable in that; nor did Alice cross think it so very much out of the\r\nway to hear the Rabbit say to itself, 'Oh dear! Oh dear! I shall be late!' (when she thought it over afterwards, it\r\noccurred to her that she ought to have wondered at this, but at the time it all seemed quite natural); but when\r\nthe Rabbit actually took a watchout of its waistcoat pocket, and looked at it, and then hurried on, Alice started\r\nto her feet, for it flashed across her mind that she had never before seen a rabbit with either a waistcoat pocket,\r\nor a watch to take out of it, and burning with curiosity, she ran across the field after it, and fortunately was just in\r\ntime to see it pop down a large rabbit hole under the hedge.In another moment down went Alice after it, never\r\nmed once considering how in the world self she was to get out again.The rabbit hole went straight on like a tunnel\r\nfor some way, and then dipped suddenly down, so suddenly that Alice had not a moment to think about stopping\r\nherself before she found herself falling down a very deep well.Either the well was very deep, or she fell very slowly,\r\nfor she had plenty of time as she went down to look about her and to wonder what was going to happen next.\r\nFirst, she tried to look down and make out what she was coming to, but it was too dark to see anything; then she\r\nlooked at the sides of the well, and noticed that they were filled with cupboards and book shelves; here and there\r\nshe saw maps and pictures hung upon pegs. She took down a jar from one of the shelves as she passed; it was\r\nlabelled `ORANGE MARMALADE', but to her great disappointment it was empty: she did not like to drop the jar\r\nfor fear of killing somebody, so managed to put it into one of the cupboards as she fell past it.", "beginning bank, and once she considering own well\r\nas she and chain\r\nwould and picking eyes\r\nran remarkable (when she she all and and hurried on, flashed she never and burning she and large under never\r\nmed once considering world she and dipped down, she herself falling she slowly,\r\nfor she she and wonder happen she and she she\r\nlooked sides well, and filled and shelves; and and pegs. She one shelves she passed; MARMALADE', she jar\r\nfor killing somebody, one she")]
  public void Returns_words_that_pass_all_filters(string input, string expectedOutput)
  {
    _fileHelper.Setup(helper => helper.ReadFile(It.IsAny<string>()))
      .Returns(input);

    var filteredInput = _filterRepository.AllFilters("anyFilePath");

    Assert.Equal(expectedOutput, filteredInput);
  }
}