using System;
using System.Runtime.InteropServices;

namespace ToolChest.VuCommand.Internal
{
   internal static class Win32
   {
      [DllImport( "kernel32.dll" )]
      internal static extern IntPtr GetStdHandle( uint nStdHandle );

      internal const uint StdOutputHandle = 0xfffffff5;
   }
}
