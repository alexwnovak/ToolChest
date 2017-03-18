using System;
using System.IO;

namespace ToolChest.VuCommand.UnitTests.Helpers
{
   internal static class FileHelper
   {
      internal static void UseTempFile( string contents, Action<string> callback )
      {
         string tempPath = Path.GetTempFileName();
         File.WriteAllText( tempPath, contents );

         callback( tempPath );

         File.Delete( tempPath );
      }
   }
}
