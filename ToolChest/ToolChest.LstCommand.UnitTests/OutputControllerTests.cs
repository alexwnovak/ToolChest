using System;
using System.IO;
using SystemWrapper;
using Moq;
using Xunit;

namespace ToolChest.LstCommand.UnitTests
{
   public class OutputControllerTests
   {
      [Fact]
      public void WriteFormatted_PassesUnformattedText_WritesTheText()
      {
         const string line = "Text with no formatting";

         // Arrange

         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var outputController = new OutputController( consoleMock.Object );

         outputController.WriteFormatted( line );

         // Assert

         consoleMock.Verify( c => c.Write( line ), Times.Once() );
      }

      [Theory]
      [InlineData( "{{0", ConsoleColor.Black )]
      [InlineData( "{{1", ConsoleColor.DarkBlue )]
      [InlineData( "{{2", ConsoleColor.DarkGreen )]
      [InlineData( "{{3", ConsoleColor.DarkCyan )]
      [InlineData( "{{4", ConsoleColor.DarkRed )]
      [InlineData( "{{5", ConsoleColor.DarkMagenta )]
      [InlineData( "{{6", ConsoleColor.DarkYellow )]
      [InlineData( "{{7", ConsoleColor.Gray )]
      [InlineData( "{{8", ConsoleColor.DarkGray )]
      [InlineData( "{{9", ConsoleColor.Blue )]
      [InlineData( "{{A", ConsoleColor.Green )]
      [InlineData( "{{a", ConsoleColor.Green )]
      [InlineData( "{{B", ConsoleColor.Cyan )]
      [InlineData( "{{b", ConsoleColor.Cyan )]
      [InlineData( "{{C", ConsoleColor.Red )]
      [InlineData( "{{c", ConsoleColor.Red )]
      [InlineData( "{{D", ConsoleColor.Magenta )]
      [InlineData( "{{d", ConsoleColor.Magenta )]
      [InlineData( "{{E", ConsoleColor.Yellow )]
      [InlineData( "{{e", ConsoleColor.Yellow )]
      [InlineData( "{{F", ConsoleColor.White )]
      [InlineData( "{{f", ConsoleColor.White )]
      public void WriteFormatted_HasColorFormatting_TextIsPrintedWithColor( string prefix, ConsoleColor expectedColor )
      {
         const string text = "Text with no formatting";

         // Arrange

         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var outputController = new OutputController( consoleMock.Object );

         outputController.WriteFormatted( $"{prefix}{text}" );

         // Assert

         consoleMock.VerifySet( c => c.ForegroundColor = expectedColor, Times.Once() );
         consoleMock.Verify( c => c.Write( text ), Times.Once() );
      }

      [Fact]
      public void WriteHeader_HasValidPath_WritesPathAndSeparator()
      {
         const string path = @"C:\Temp";

         // Arrange

         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var outputController = new OutputController( consoleMock.Object );

         outputController.WriteHeader( path );

         // Assert

         consoleMock.Verify( c => c.WriteLine( path ), Times.Once() );
         consoleMock.Verify( c => c.WriteLine( It.Is<string>( s => s.Length == path.Length ) ) );
      }

      [Fact]
      public void Write_HasFile_PrintsFileNameWithoutPath()
      {
         const string fileName = "File.txt";
         string path = Path.Combine( @"C:\Temp", fileName );

         // Arrange

         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var fileDescriptor = new FileDescriptor( path, 123, false, false );

         var outputController = new OutputController( consoleMock.Object );

         outputController.Write( fileDescriptor );

         // Assert

         consoleMock.Verify( c => c.WriteLine( fileName ), Times.Once() );
      }

      [Fact]
      public void Write_HasFile_PrintsSize()
      {
         const string fileName = "File.txt";
         string path = Path.Combine( @"C:\Temp", fileName );

         // Arrange

         var consoleMock = new Mock<IConsoleWrap>();

         // Act

         var fileDescriptor = new FileDescriptor( path, 123, false, false );

         var outputController = new OutputController( consoleMock.Object );

         outputController.Write( fileDescriptor );

         // Assert

         consoleMock.Verify( c => c.WriteLine( fileName ), Times.Once() );
      }
   }
}
