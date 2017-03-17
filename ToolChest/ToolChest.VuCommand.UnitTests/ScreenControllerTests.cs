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
   }
}
