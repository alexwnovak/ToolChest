using System;

namespace ToolChest.VuCommand
{
   public class ScreenController : IScreenController
   {
      private readonly IScreenBuffer _screenBuffer;

      public int ScreenWidth => _screenBuffer.Width;
      public int ScreenHeight => _screenBuffer.Height;

      public bool IsCursorVisible
      {
         get
         {
            return _screenBuffer.IsCursorVisible;
         }
         set
         {
            _screenBuffer.IsCursorVisible = value;
         }
      }

      public ScreenController( IScreenBuffer screenBuffer )
      {
         _screenBuffer = screenBuffer;
      }

      public void Clear()
      {
         _screenBuffer.CursorLeft = 0;
         _screenBuffer.CursorTop = 0;

         _screenBuffer.Render( b =>
         {
            for ( int index = 0; index < b.Length; index++ )
            {
               b[index].AsciiChar = '\0';
               b[index].Attributes = 0 << 4 | 7;
            }
         } );
      }

      public void PrintLines( string[] lines )
      {
         _screenBuffer.Render( b =>
         {
            int offset = 0;

            foreach ( string line in lines )
            {
               for ( int index = 0; index < line.Length; index++ )
               {
                  b[offset + index].AsciiChar = line[index];
               }

               offset += _screenBuffer.Width;
            }
         } );
      }
   }
}
