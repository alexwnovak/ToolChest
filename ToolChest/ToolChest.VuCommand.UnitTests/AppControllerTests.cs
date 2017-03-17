using Moq;
using Xunit;

namespace ToolChest.VuCommand.UnitTests
{
   public class AppControllerTests
   {
      [Fact]
      public void Start_ArgumentsAreEmptyArray_DisplaysSyntax()
      {
         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var environmentControllerMock = new Mock<IEnvironmentController>();

         // Act

         var appController = new AppController( outputControllerMock.Object, environmentControllerMock.Object, null );

         appController.Start( new string[0] );

         // Assert

         outputControllerMock.Verify( oc => oc.DisplaySyntax(), Times.Once() );
      }

      [Fact]
      public void Start_ArgumentsAreEmptyStringArray_ExitsWithCode1()
      {
         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var environmentControllerMock = new Mock<IEnvironmentController>();

         // Act

         var appController = new AppController( outputControllerMock.Object, environmentControllerMock.Object, null );

         appController.Start( new string[0] );

         // Assert

         environmentControllerMock.Verify( ec => ec.Exit( 1 ), Times.Once() );
      }

      [Fact]
      public void Start_HasArguments_PassesFirstArgumentToPager()
      {
         const string fileName = @"C:\Temp\SomeFile.txt";

         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var environmentControllerMock = new Mock<IEnvironmentController>();
         var pagerMock = new Mock<IPager>();

         // Act

         var appController = new AppController( outputControllerMock.Object, environmentControllerMock.Object, pagerMock.Object );

         appController.Start( new[] { fileName } );

         // Assert

         pagerMock.Verify( ec => ec.Display( fileName ), Times.Once() );
      }
   }
}
