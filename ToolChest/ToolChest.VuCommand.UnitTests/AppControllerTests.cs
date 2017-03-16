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
         var environmentControllerMock = new Mock<IEnvironmentController>();

         // Act

         var appController = new AppController( outputControllerMock.Object, environmentControllerMock.Object );

         appController.Start( null );

         // Assert

         outputControllerMock.Verify( oc => oc.DisplaySyntax(), Times.Once() );
      }

      [Fact]
      public void Start_ArgumentsAreEmptyString_DisplaysSyntax()
      {
         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var environmentControllerMock = new Mock<IEnvironmentController>();

         // Act

         var appController = new AppController( outputControllerMock.Object, environmentControllerMock.Object );

         appController.Start( new string[0] );

         // Assert

         outputControllerMock.Verify( oc => oc.DisplaySyntax(), Times.Once() );
      }

      [Fact]
      public void Start_ArgumentsAreNull_ExitsWithCode1()
      {
         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var environmentControllerMock = new Mock<IEnvironmentController>();

         // Act

         var appController = new AppController( outputControllerMock.Object, environmentControllerMock.Object );

         appController.Start( null );

         // Assert

         environmentControllerMock.Verify( ec => ec.Exit( 1 ), Times.Once() );
      }


      [Fact]
      public void Start_ArgumentsAreEmptyString_ExitsWithCode1()
      {
         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var environmentControllerMock = new Mock<IEnvironmentController>();

         // Act

         var appController = new AppController( outputControllerMock.Object, environmentControllerMock.Object );

         appController.Start( new string[0] );

         // Assert

         environmentControllerMock.Verify( ec => ec.Exit( 1 ), Times.Once() );
      }

   }
}
