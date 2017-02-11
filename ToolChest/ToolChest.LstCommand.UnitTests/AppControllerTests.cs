using System.IO;
using Xunit;
using Moq;
using SystemWrapper;
using ToolChest.LstCommand.UnitTests.Helpers;

namespace ToolChest.LstCommand.UnitTests
{
   public class AppControllerTests
   {
      [Fact]
      public void Start_CurrentDirectoryHasOneFile_PrintsNameAndSizeWithCorrectSpacing()
      {
         var fileDescriptor = new FileDescriptor( @"C:\Temp\File.txt", 560 );
         var paths = ArrayHelper.Create( fileDescriptor );

         const string wholeLine = "560 B   File.txt";

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.GetFiles( "." ) ).Returns( paths );
         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var appController = new AppController( fileSystemMock.Object, consoleMock.Object );

         appController.Start();

         // Assert

         consoleMock.Verify( c => c.WriteLine( wholeLine ), Times.Once );
      }
   }
}
