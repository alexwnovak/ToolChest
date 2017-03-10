using System;
using System.IO;
using SystemWrapper;

namespace ToolChest.LstCommand
{
   public class AppController
   {
      private readonly IFileSystem _fileSystem;
      private readonly IConsoleWrap _console;

      public AppController( IFileSystem fileSystem, IConsoleWrap console )
      {
         _fileSystem = fileSystem;
         _console = console;
      }

      public void Start( string[] arguments )
      {
         string path = ".";

         if ( arguments?.Length > 0 )
         {
            path = arguments[0];
         }

         var fileDescriptors = _fileSystem.GetFiles( path );
         long totalSize = 0;

         foreach ( var fileDescriptor in fileDescriptors )
         {
            string wholeLine;
            var oldColor = _console.ForegroundColor;

            if ( fileDescriptor.IsDirectory )
            {
               string trimmedFile = Path.GetFileName( fileDescriptor.FullPath );

               _console.ForegroundColor = ConsoleColor.DarkYellow;
               _console.Write( "Folder" );

               _console.ForegroundColor = ConsoleColor.DarkGray;
               _console.Write( " | " );

               _console.ForegroundColor = ConsoleColor.DarkYellow;
               _console.WriteLine( trimmedFile + "/" );
            }
            else
            {
               string trimmedFile = Path.GetFileName( fileDescriptor.FullPath );

               totalSize += fileDescriptor.Size;
               string sizeString = SizeFormatter.Format( fileDescriptor.Size );

               string extension = Path.GetExtension( trimmedFile );
               var extensionColor = ColorProvider.GetColor( extension );

               _console.ForegroundColor = extensionColor;
               _console.Write( sizeString );

               _console.ForegroundColor = ConsoleColor.DarkGray;
               _console.Write( " | " );

               _console.ForegroundColor = extensionColor; 
               _console.WriteLine( trimmedFile );
            }

            _console.ForegroundColor = oldColor;
         }

         string totalSizeString = SizeFormatter.Format( totalSize );

         _console.ForegroundColor = ConsoleColor.DarkGray;
         _console.WriteLine( "=======+===========" );

         _console.ForegroundColor = ConsoleColor.Gray;
         _console.Write( totalSizeString );
         
         _console.ForegroundColor = ConsoleColor.DarkGray;
         _console.Write( " | " );

         _console.ForegroundColor = ConsoleColor.Gray;
         _console.WriteLine( "Total size" );
         //| Total size" );
      }
   }
}
