using System.IO;
using FluentAssertions;
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

         // Act

         var appController = new AppController( outputControllerMock.Object, null );

         appController.Start( new string[0] );

         // Assert

         outputControllerMock.Verify( oc => oc.DisplaySyntax(), Times.Once() );
      }

      [Fact]
      public void Start_ArgumentsAreEmptyStringArray_ExitsWithCode1()
      {
         // Arrange

         var outputControllerMock = new Mock<IOutputController>();

         // Act

         var appController = new AppController( outputControllerMock.Object, null );

         int exitCode = appController.Start( new string[0] );

         // Assert

         exitCode.Should().Be( 1 );
      }

      [Fact]
      public void Start_HasArguments_PassesFirstArgumentToPager()
      {
         const string fileName = @"C:\Temp\SomeFile.txt";

         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var pagerMock = new Mock<IPager>();

         // Act

         var appController = new AppController( outputControllerMock.Object, pagerMock.Object );

         appController.Start( new[] { fileName } );

         // Assert

         pagerMock.Verify( p => p.Display( fileName ), Times.Once() );
      }

      [Fact]
      public void Start_HasArguments_ExitWithCode0()
      {
         const string fileName = @"C:\Temp\SomeFile.txt";

         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var pagerMock = new Mock<IPager>();

         // Act

         var appController = new AppController( outputControllerMock.Object, pagerMock.Object );

         int exitCode = appController.Start( new[] { fileName } );

         // Assert

         exitCode.Should().Be( 0 );
      }

      [Fact]
      public void Start_GivenFileDoesNotExist_DisplaysError()
      {
         const string fileName = @"C:\Temp\SomeFile.txt";

         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var pagerMock = new Mock<IPager>();
         pagerMock.Setup( p => p.Display( fileName ) ).Throws<FileNotFoundException>();

         // Act

         var appController = new AppController( outputControllerMock.Object, pagerMock.Object );

         appController.Start( new[] { fileName } );

         // Assert

         outputControllerMock.Verify( oc => oc.DisplayFileError( fileName ), Times.Once() );
      }

      [Fact]
      public void Start_GivenFileDoesNotExist_ReturnsExitCode1()
      {
         const string fileName = @"C:\Temp\SomeFile.txt";

         // Arrange

         var outputControllerMock = new Mock<IOutputController>();
         var pagerMock = new Mock<IPager>();
         pagerMock.Setup( p => p.Display( fileName ) ).Throws<FileNotFoundException>();

         // Act

         var appController = new AppController( outputControllerMock.Object, pagerMock.Object );

         int exitCode = appController.Start( new[] { fileName } );

         // Assert

         exitCode.Should().Be( 1 );
      }
   }
}
