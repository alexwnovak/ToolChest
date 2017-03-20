using System;
using ToolChest.Common;

namespace ToolChest.SpaceCommand
{
   public class OutputController : IOutputController
   {
      public void PrintFreeDiskSpace( long freeDiskSpace )
      {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.Write( "Free space: " );

         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine( SizeFormatter.Format( freeDiskSpace ) );

         Console.WriteLine();
      }
   }
}
