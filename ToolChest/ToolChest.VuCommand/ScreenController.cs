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

      public int CursorLeft
      {
         get
         {
            return _screenBuffer.CursorLeft;
         }
         set
         {
            _screenBuffer.CursorLeft = value;
         }
      }

      public int CursorTop
      {
         get
         {
            return _screenBuffer.CursorTop;
         }
         set
         {
            _screenBuffer.CursorTop = value;
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

      public void DrawStatusBar()
      {
         const ushort attribute = 1 << 4 | 15;

         _screenBuffer.Render( b =>
         {
            int offset = (ScreenHeight - 1) * ScreenWidth;

            for ( int index = 0; index < ScreenWidth; index++ )
            {
               b[offset + index].Attributes = attribute;
            }
         } );
      }

      public void HideStatusBar()
      {
         const ushort attribute = 0 << 4 | 7;

         _screenBuffer.Render( b =>
         {
            int offset = (ScreenHeight - 1) * ScreenWidth;

            for ( int index = 0; index < ScreenWidth; index++ )
            {
               b[offset + index].AsciiChar = '\0';
               b[offset + index].Attributes = attribute;
            }
         } );
      }

      public void Print( string text, int column, int row )
      {
         _screenBuffer.Render( b =>
         {
            int offset = row * ScreenWidth + column;

            for ( int index = 0; index < text.Length; index++ )
            {
               b[offset + index].AsciiChar = text[index];
            }
         } );
      }

      public void ScrollDown( int rows )
      {
         _screenBuffer.Render( b =>
         {
            int sourceIndex = ScreenWidth;
            int length = ScreenWidth * ScreenHeight - ScreenWidth * 2;

            Array.Copy( b, sourceIndex, b, 0, length );

            for ( int index = 0; index < ScreenWidth; index++ )
            {
               b[length + index].AsciiChar = '\0';
               b[length + index].Attributes = 7;
            }
         } );
      }
   }
}
