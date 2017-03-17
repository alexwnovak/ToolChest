using System;

namespace ToolChest.VuCommand
{
   public class OutputController : IOutputController
   {
      public void DisplaySyntax()
      {
         Console.ForegroundColor = ConsoleColor.Green;
         Console.Write( "Syntax: " );

         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine( "vu <file>" );

         Console.WriteLine();
      }
   }
}
