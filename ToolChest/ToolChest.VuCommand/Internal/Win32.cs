using System;
using System.Runtime.InteropServices;

namespace ToolChest.VuCommand.Internal
{
   internal static class Win32
   {
      [DllImport( "kernel32.dll", EntryPoint = "WriteConsoleOutputW", CharSet = CharSet.Unicode, SetLastError = true )]
      internal static extern bool WriteConsoleOutput( IntPtr hConsoleOutput,
      [MarshalAs( UnmanagedType.LPArray ), In] CharInfo[] lpBuffer,
         Coord dwBufferSize,
         Coord dwBufferCoord,
         ref Rect lpWriteRegion );

      [DllImport( "kernel32.dll" )]
      internal static extern IntPtr GetStdHandle( uint nStdHandle );

      internal const uint StdOutputHandle = 0xfffffff5;
   }
}
