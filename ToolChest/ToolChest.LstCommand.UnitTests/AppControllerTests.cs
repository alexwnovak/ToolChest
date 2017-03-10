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
      public void Start_HasNoArguments_GetsFilesFromTheCurrentPath()
      {
         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var appController = new AppController( fileSystemMock.Object, consoleMock.Object );

         appController.Start( null );

         // Assert

         fileSystemMock.Verify( fs => fs.GetFiles( "." ), Times.Once );
      }

      [Fact]
      public void Start_HasPathArgument_GetsFilesFromThePath()
      {
         const string path = @"C:\SomePath";
         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var appController = new AppController( fileSystemMock.Object, consoleMock.Object );

         appController.Start( ArrayHelper.Create( path ) );

         // Assert

         fileSystemMock.Verify( fs => fs.GetFiles( path ), Times.Once );
      }

      //[Fact]
      //public void Start_CurrentDirectoryHasOneFile_PrintsNameAndSizeWithCorrectSpacing()
      //{
      //   var fileDescriptor = new FileDescriptor( @"C:\Temp\File.txt", 560, false );
      //   var paths = ArrayHelper.Create( fileDescriptor );

      //   const string wholeLine = "560 B  │ File.txt";

      //   // Arrange

      //   var fileSystemMock = new Mock<IFileSystem>();
      //   fileSystemMock.Setup( fs => fs.GetFiles( "." ) ).Returns( paths );
      //   var consoleMock = new Mock<IConsoleWrap>();

      //   // Act

      //   var appController = new AppController( fileSystemMock.Object, consoleMock.Object );

      //   appController.Start( null );

      //   // Assert

      //   consoleMock.Verify( c => c.WriteLine( wholeLine ), Times.Once );
      //}

      //[Fact]
      //public void Start_FindsTwoFiles_PrintsTheTotalSize()
      //{
      //   var fileDescriptor = new FileDescriptor( @"C:\Temp\File.txt", 1000, false );
      //   var fileDescriptor2 = new FileDescriptor( @"C:\Temp\File.txt", 2234, false );
      //   var paths = ArrayHelper.Create( fileDescriptor, fileDescriptor2 );

      //   const string wholeLine = "3.2 KB  Total size";

      //   // Arrange

      //   var fileSystemMock = new Mock<IFileSystem>();
      //   fileSystemMock.Setup( fs => fs.GetFiles( "." ) ).Returns( paths );
      //   var consoleMock = new Mock<IConsoleWrap>();

      //   // Act

      //   var appController = new AppController( fileSystemMock.Object, consoleMock.Object );

      //   appController.Start( null );

      //   // Assert

      //   consoleMock.Verify( c => c.WriteLine( wholeLine ), Times.Once );
      //}

      [Fact]
      public void Start_FindsADirectory_PrintsTheNameWithASlash()
      {
         var fileDescriptor = new FileDescriptor( @"C:\Temp\TestDirectory", 0, true );
         var paths = ArrayHelper.Create( fileDescriptor );

         const string wholeLine = "        TestDirectory/";

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.GetFiles( "." ) ).Returns( paths );
         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var appController = new AppController( fileSystemMock.Object, consoleMock.Object );

         appController.Start( null );

         // Assert

         consoleMock.Verify( c => c.WriteLine( wholeLine ), Times.Once );
      }
   }
}
