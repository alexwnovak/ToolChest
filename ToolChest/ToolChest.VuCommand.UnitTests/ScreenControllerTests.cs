using System;
using System.Linq;
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
   }
}
