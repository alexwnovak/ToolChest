using Xunit;
using Moq;
using SystemWrapper;
using SystemWrapper.IO;
using ToolChest.LstCommand.UnitTests.Helpers;

namespace ToolChest.LstCommand.UnitTests
{
   public class AppControllerTests
   {
      [Fact]
      public void Start_CurrentDirectoryHasOneFile_PrintsOneFile()
      {
         var paths = ArrayHelper.Create( "File.txt" );

         // Arrange
         
         var directoryMock = new Mock<IDirectoryWrap>();
         directoryMock.Setup( d => d.GetFiles( "." ) ).Returns( paths );
         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var appController = new AppController( directoryMock.Object, consoleMock.Object );

         appController.Start();

         // Assert

         consoleMock.Verify( c => c.WriteLine( paths[0] ), Times.Once );
      }
   }
}
