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

            if ( fileDescriptor.IsDirectory )
            {
               string trimmedFile = Path.GetFileName( fileDescriptor.FullPath );
               wholeLine = $"        {trimmedFile}/";
            }
            else
            {
               string trimmedFile = Path.GetFileName( fileDescriptor.FullPath );

               totalSize += fileDescriptor.Size;
               string sizeString = SizeFormatter.Format( fileDescriptor.Size );

               wholeLine = $"{sizeString}  {trimmedFile}";
            }

            _console.WriteLine( wholeLine );
         }

         string totalSizeString = SizeFormatter.Format( totalSize );
         _console.WriteLine( $"{totalSizeString}  Total size" );
      }
   }
}
