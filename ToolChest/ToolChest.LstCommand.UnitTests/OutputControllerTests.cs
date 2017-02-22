using SystemWrapper;
using Moq;
using Xunit;

namespace ToolChest.LstCommand.UnitTests
{
   public class OutputControllerTests
   {
      [Fact]
      public void WriteFormatted_PassesUnformattedText_WritesTheText()
      {
         const string line = "Text with no formatting";

         // Arrange

         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var outputController = new OutputController( consoleMock.Object );

         outputController.WriteFormatted( line );

         // Assert

         consoleMock.Verify( c => c.Write( line ), Times.Once() );
      }
   }
}
