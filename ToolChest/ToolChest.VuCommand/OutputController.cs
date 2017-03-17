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

      public void DisplayFileError( string filePath )
      {
         Console.ForegroundColor = ConsoleColor.Red;
         Console.Write( "Error: " );

         Console.ForegroundColor = ConsoleColor.Gray;
         Console.WriteLine( $"Unable to open {filePath}" );

         Console.WriteLine();
      }
   }
}
