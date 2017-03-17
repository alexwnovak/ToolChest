using Moq;
using Xunit;

namespace ToolChest.VuCommand.UnitTests
{
   public class PagerTests
   {
      [Fact]
      public void Display_HasFile_ClearsScreen()
      {
         // Arrange

         var screenControllerMock = new Mock<IScreenController>();
         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, fileReaderMock.Object );

         pager.Display( "File.txt" );

         // Assert

         screenControllerMock.Verify( sc => sc.Clear(), Times.Once() );
      }

      [Fact]
      public void Display_HasFile_DisplaysAScreenOfText()
      {
         const string fileName = "SomeFile.txt";
         const int screenHeight = 25;
         var lines = new string[screenHeight];

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();
         screenControllerMock.SetupGet( sc => sc.ScreenHeight ).Returns( screenHeight );
         
         var fileReaderMock = new Mock<IFileReader>();
         fileReaderMock.Setup( fr => fr.ReadLines( fileName, screenHeight - 1 ) ).Returns( lines );

         // Act

         var pager = new Pager( screenControllerMock.Object, fileReaderMock.Object );

         pager.Display( fileName );

         // Assert

         screenControllerMock.Verify( sc => sc.PrintLines( lines ), Times.Once() );
      }
   }
}
