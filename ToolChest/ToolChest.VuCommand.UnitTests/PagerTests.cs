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

         // Act

         var pager = new Pager( screenControllerMock.Object );

         pager.Display( "File.txt" );

         // Assert

         screenControllerMock.Verify( sc => sc.Clear(), Times.Once() );
      }
   }
}
