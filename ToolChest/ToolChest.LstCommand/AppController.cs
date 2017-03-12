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

         string fullPath = Path.GetFullPath( path );
         _console.WriteLine( fullPath );

         _console.ForegroundColor = ConsoleColor.DarkGray;
         _console.WriteLine( new string( '-', fullPath.Length ) );

         _console.ForegroundColor = ConsoleColor.Gray;

         var fileDescriptors = _fileSystem.GetFiles( path );
         long totalSize = 0;

         foreach ( var fileDescriptor in fileDescriptors )
         {
            var oldColor = _console.ForegroundColor;

            if ( fileDescriptor.IsDirectory )
            {
               string trimmedFile = Path.GetFileName( fileDescriptor.FullPath );

               _console.ForegroundColor = ColorProvider.FolderColor;
               _console.Write( "Folder" );

               _console.ForegroundColor = ConsoleColor.DarkGray;
               _console.Write( " | " );

               _console.ForegroundColor = fileDescriptor.IsHidden ? ColorProvider.HiddenColor : ColorProvider.FolderColor;
               _console.WriteLine( trimmedFile + "/" );
            }
            else
            {
               string trimmedFile = Path.GetFileName( fileDescriptor.FullPath );

               totalSize += fileDescriptor.Size;
               string sizeString = SizeFormatter.Format( fileDescriptor.Size );

               ConsoleColor extensionColor;

               if ( fileDescriptor.IsHidden )
               {
                  extensionColor = ColorProvider.HiddenColor;
               }
               else
               {
                  string extension = Path.GetExtension( trimmedFile );
                  extensionColor = ColorProvider.GetColor( extension );
               }

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
         _console.WriteLine( "-------+-----------" );

         _console.ForegroundColor = ConsoleColor.Gray;
         _console.Write( totalSizeString );

         _console.ForegroundColor = ConsoleColor.DarkGray;
         _console.Write( " | " );

         _console.ForegroundColor = ConsoleColor.Gray;
         _console.WriteLine( "Total size" );
      }
   }
}
