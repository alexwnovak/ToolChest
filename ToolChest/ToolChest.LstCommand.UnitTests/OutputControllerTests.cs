using System;
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
      [InlineData( "{{_", ConsoleColor.Black )]
      [InlineData( "{{b", ConsoleColor.DarkBlue )]
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
   }
}
