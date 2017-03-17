using System;
using System.Linq;
using FluentAssertions;
using Moq;
using Xunit;
using ToolChest.VuCommand.Interop;

namespace ToolChest.VuCommand.UnitTests
{
   public class ScreenControllerTests
   {
      private static CharInfo[] Apply( Action<CharInfo[]> a, CharInfo[] buffer )
      {
         a( buffer );
         return buffer;
      }

      [Fact]
      public void Clear_HappyPath_MovesCursorLocationToTopLeft()
      {
         // Arrange

         var screenBufferMock = new Mock<IScreenBuffer>();

         // Act

         var screenController = new ScreenController( screenBufferMock.Object );

         screenController.Clear();

         // Assert

         screenBufferMock.VerifySet( sb => sb.CursorLeft = 0, Times.Once() );
         screenBufferMock.VerifySet( sb => sb.CursorTop = 0, Times.Once() );
      }

      [Fact]
      public void Clear_HappyPath_RendersToScreenBuffer()
      {
         // Arrange

         var screenBufferMock = new Mock<IScreenBuffer>();

         // Act

         var screenController = new ScreenController( screenBufferMock.Object );

         screenController.Clear();

         // Assert

         var buffer = new CharInfo[1];

         screenBufferMock.Verify( sb => sb.Render(
            It.Is<Action<CharInfo[]>>(
               a => Apply( a, buffer )
                  .All( ci => ci.AsciiChar == '\0' && ci.Attributes == 7 ) ) ),
            Times.Once() );
      }

      [Fact]
      public void PrintLines_HasTwoLines_LinesArePrinted()
      {
         var lines = new[] { "A", "BB" };
         CharInfo[] actualBuffer = new CharInfo[5];

         // Arrange

         var screenBufferMock = new Mock<IScreenBuffer>();
         screenBufferMock.SetupGet( sb => sb.Width ).Returns( 2 );
         screenBufferMock.Setup( sb => sb.Render( It.IsAny<Action<CharInfo[]>>() ) )
                         .Callback<Action<CharInfo[]>>( a => a( actualBuffer ) );

         // Act

         var screenController = new ScreenController( screenBufferMock.Object );

         screenController.PrintLines( lines );

         // Assert

         actualBuffer[0].AsciiChar.Should().Be( 'A' );
         actualBuffer[1].AsciiChar.Should().Be( '\0' );
         actualBuffer[2].AsciiChar.Should().Be( 'B' );
         actualBuffer[3].AsciiChar.Should().Be( 'B' );
         actualBuffer[4].AsciiChar.Should().Be( '\0' );
      }

      [Fact]
      public void DrawStatusBar_HappyPath_FillsLineAtBottom()
      {
         CharInfo[] actualBuffer = new CharInfo[4];

         // Arrange

         var screenBufferMock = new Mock<IScreenBuffer>();
         screenBufferMock.SetupGet( sb => sb.Width ).Returns( 2 );
         screenBufferMock.SetupGet( sb => sb.Height ).Returns( 2 );
         screenBufferMock.Setup( sb => sb.Render( It.IsAny<Action<CharInfo[]>>() ) )
                         .Callback<Action<CharInfo[]>>( a => a( actualBuffer ) );

         // Act

         var screenController = new ScreenController( screenBufferMock.Object );

         screenController.DrawStatusBar();

         // Assert

         const int attribute = 1 << 4 | 15;

         actualBuffer[2].AsciiChar.Should().Be( '\0' );
         actualBuffer[2].Attributes.Should().Be( attribute );

         actualBuffer[3].AsciiChar.Should().Be( '\0' );
         actualBuffer[3].Attributes.Should().Be( attribute );
      }

      [Fact]
      public void HideStatusBar_HappyPath_RestoresAttributeAndErasesCharactersAtBottom()
      {
         CharInfo[] actualBuffer = new CharInfo[4];
         actualBuffer[2].AsciiChar = 'X';
         actualBuffer[3].AsciiChar = 'X';

         // Arrange

         var screenBufferMock = new Mock<IScreenBuffer>();
         screenBufferMock.SetupGet( sb => sb.Width ).Returns( 2 );
         screenBufferMock.SetupGet( sb => sb.Height ).Returns( 2 );
         screenBufferMock.Setup( sb => sb.Render( It.IsAny<Action<CharInfo[]>>() ) )
                         .Callback<Action<CharInfo[]>>( a => a( actualBuffer ) );

         // Act

         var screenController = new ScreenController( screenBufferMock.Object );

         screenController.HideStatusBar();

         // Assert

         const int attribute = 0 << 4 | 7;

         actualBuffer[2].AsciiChar.Should().Be( '\0' );
         actualBuffer[2].Attributes.Should().Be( attribute );

         actualBuffer[3].AsciiChar.Should().Be( '\0' );
         actualBuffer[3].Attributes.Should().Be( attribute );
      }

      [Fact]
      public void Print_HasString_PrintsInTheGivenLocation()
      {
         CharInfo[] actualBuffer = new CharInfo[6];
         const string text = "AB";

         // Arrange

         var screenBufferMock = new Mock<IScreenBuffer>();
         screenBufferMock.SetupGet( sb => sb.Width ).Returns( 3 );
         screenBufferMock.SetupGet( sb => sb.Height ).Returns( 2 );
         screenBufferMock.Setup( sb => sb.Render( It.IsAny<Action<CharInfo[]>>() ) )
                         .Callback<Action<CharInfo[]>>( a => a( actualBuffer ) );

         // Act

         var screenController = new ScreenController( screenBufferMock.Object );

         screenController.Print( text, 1, 1 );

         // Assert

         actualBuffer[4].AsciiChar.Should().Be( text[0] );
         actualBuffer[5].AsciiChar.Should().Be( text[1] );
      }
   }
}
