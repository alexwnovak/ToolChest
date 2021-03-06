﻿using System;
using ToolChest.VuCommand.Interop;

namespace ToolChest.VuCommand
{
   public class ScreenBuffer : IScreenBuffer
   {
      private readonly IntPtr _consoleHandle;
      private static Coord _bufferSize;
      private Rect _screenRect;
      
      public CharInfo[] Buffer
      {
         get;
         set;
      }

      public int Width
      {
         get;
      }

      public int Height
      {
         get;
      }

      public int CursorLeft
      {
         get
         {
            return Console.CursorLeft;
         }
         set
         {
            Console.CursorLeft = value;
         }
      }

      public int CursorTop
      {
         get
         {
            return Console.CursorTop;
         }
         set
         {
            Console.CursorTop = value;
         }
      }

      public bool IsCursorVisible
      {
         get
         {
            return Console.CursorVisible;
         }
         set
         {
            Console.CursorVisible = value;
         }
      }

      public ScreenBuffer()
      {
         _consoleHandle = Win32.GetStdHandle( Win32.StdOutputHandle );

         Width = Console.WindowWidth;
         Height = Console.WindowHeight;
         Buffer = new CharInfo[Width * Height];

         _bufferSize = new Coord( (short) Width, (short) Height );
         _screenRect = new Rect( 0, 0, (short) (Width - 1), (short) (Height - 1) );
      }

      public void Render( Action<CharInfo[]> renderAction )
      {
         renderAction( Buffer );

         Win32.WriteConsoleOutput( _consoleHandle, Buffer, _bufferSize, new Coord( 0, 0 ), ref _screenRect );
      }
   }
}
