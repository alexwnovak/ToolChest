using System;
using System.Text;
using SystemWrapper;

namespace ToolChest.LstCommand
{
   public class OutputController : IOutputController
   {
      private readonly IConsoleWrap _console;

      public OutputController( IConsoleWrap console )
      {
         _console = console;
      }

      public void WriteFormatted( string line )
      {
         var stringBuilder = new StringBuilder();

         for ( int index = 0; index < line.Length; index++ )
         {
            if ( line[index] == '{' && line[++index] == '{' )
            {
               char color = line[++index];

               if ( color == 'b' )
               {
                  _console.ForegroundColor = ConsoleColor.DarkBlue;
               }

               continue;
            }

            stringBuilder.Append( line[index] );
         }

         string output = stringBuilder.ToString();
         _console.Write( output );
      }
   }
}
