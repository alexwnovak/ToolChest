using Moq;
using Xunit;

namespace ToolChest.VuCommand.UnitTests
{
   public class AppControllerTests
   {
      [Fact]
      public void Start_ArgumentsAreNull_DisplaysSyntax()
      {
         // Arrange

         var outputControllerMock = new Mock<IOutputController>();

         // Act

         var appController = new AppController( outputControllerMock.Object );

         appController.Start( null );

         // Assert

         outputControllerMock.Verify( oc => oc.DisplaySyntax(), Times.Once() );
      }

      [Fact]
      public void Start_ArgumentsAreEmptyString_DisplaysSyntax()
      {
         // Arrange

         var outputControllerMock = new Mock<IOutputController>();

         // Act

         var appController = new AppController( outputControllerMock.Object );

         appController.Start( new string[0] );

         // Assert

         outputControllerMock.Verify( oc => oc.DisplaySyntax(), Times.Once() );
      }
   }
}
