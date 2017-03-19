using FluentAssertions;
using Moq;
using Xunit;

namespace ToolChest.SpaceCommand.UnitTests
{
   public class AppControllerTests
   {
      [Fact]
      public void Start_NoArgumentsRunsNormally_ExitsWithCode0()
      {
         // Arrange

         var diskSpaceReaderMock = new Mock<IDiskSpaceReader>();
         var outputControllerMock = new Mock<IOutputController>();

         // Act

         var appController = new AppController( diskSpaceReaderMock.Object, outputControllerMock.Object );

         int exitCode = appController.Start( new string[0] );

         // Assert

         exitCode.Should().Be( 0 );
      }

      [Fact]
      public void Start_NoArguments_DisplaysFreeDiskSpace()
      {
         const long diskSpace = 123456789;

         // Arrange

         var diskSpaceReaderMock = new Mock<IDiskSpaceReader>();
         diskSpaceReaderMock.Setup( dsr => dsr.GetFreeDiskSpace() ).Returns( diskSpace );

         var outputControllerMock = new Mock<IOutputController>();

         // Act

         var appController = new AppController( diskSpaceReaderMock.Object, outputControllerMock.Object );

         appController.Start( new string[0] );

         // Assert

         outputControllerMock.Verify( oc => oc.PrintFreeDiskSpace( diskSpace ), Times.Once() );
      }
   }
}
