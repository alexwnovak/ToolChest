using SystemWrapper;
using SystemWrapper.IO;

namespace ToolChest.LstCommand
{
   public class AppController
   {
      private readonly IDirectoryWrap _directory;
      private readonly IConsoleWrap _console;

      public AppController( IDirectoryWrap directory, IConsoleWrap console )
      {
         _directory = directory;
         _console = console;
      }

      public void Start()
      {
         var files = _directory.GetFiles( "." );

         foreach ( string file in files )
         {
            _console.WriteLine( file );
         }
      }
   }
}
