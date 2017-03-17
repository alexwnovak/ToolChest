using System.Collections.Generic;
using System.IO;

namespace ToolChest.VuCommand
{
   public class FileReader : IFileReader
   {
      public string[] ReadLines( string fileName, int count )
      {
         var lines = new List<string>();

         using ( var fileStream = new FileStream( fileName, FileMode.Open, FileAccess.Read ) )
         {
            using ( var streamReader = new StreamReader( fileStream ) )
            {
               for ( int index = 0; index < count; index++ )
               {
                  string line = streamReader.ReadLine();

                  lines.Add( line );
               }
            }
         }

         return lines.ToArray();
      }
   }
}
