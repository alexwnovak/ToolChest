using System;
using System.Runtime.InteropServices;

namespace ToolChest.SpaceCommand
{
   public class DiskSpaceReader : IDiskSpaceReader
   {
      [DllImport( "kernel32.dll", SetLastError = true, CharSet = CharSet.Auto )]
      private static extern bool GetDiskFreeSpaceEx( string lpDirectoryName,
         out ulong lpFreeBytesAvailable,
         out ulong lpTotalNumberOfBytes,
         out ulong lpTotalNumberOfFreeBytes );

      public long GetFreeDiskSpace()
      {
         ulong _, freeSpace;

         GetDiskFreeSpaceEx( Environment.CurrentDirectory, out _, out _, out freeSpace );

         return (long) freeSpace;
      }
   }
}
