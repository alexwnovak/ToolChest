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
               int decimalValue = HexHelper.HexToInt( line[++index] );

               _console.ForegroundColor = (ConsoleColor) decimalValue;

               continue;
            }

            stringBuilder.Append( line[index] );
         }

         string output = stringBuilder.ToString();
         _console.Write( output );
      }

      public void WriteHeader( string path )
      {
         var oldColor = _console.ForegroundColor;

         _console.WriteLine( path );

         _console.ForegroundColor = ConsoleColor.DarkGray;
         _console.WriteLine( new string( '-', path.Length ) );

         _console.ForegroundColor = oldColor;
      }
   }
}
