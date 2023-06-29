using FormattingText.Services;
using FormattingText.Interfaces;

namespace FormattingTextTests
{
    public class TextToPropertiesServiceTests
    {
        private ITextToPropertiesService GetService()
        {
            return new TextToPropertiesService();
        }

        private string GetTwoWordStringWithComma()
        {
            return "Test,TestY";
        }

        private string GetTwoWordStringWithSpace()
        {
            return "Test TestY";
        }
        [Fact]
        public void SendIn2WordsWithComma_ShouldReturnStringWithTwoProperties()
        {
            var service = GetService();
            var result = service.StringToProperty(GetTwoWordStringWithComma(),",","string");

            Assert.Equal(result.Length, 2);
        }
        [Fact]
        public void SendIn2WordsWithSpace_ShouldReturnStringWithTwoProperties()
        {
            var service = GetService();
            var result = service.StringToProperty(GetTwoWordStringWithSpace(), " ", "string");

            Assert.Equal(result.Length, 2);
        }
    }
}