using SystemWrapper;
using SystemWrapper.IO;

namespace ToolChest.LstCommand
{
   internal static class Program
   {
      private static void Main( string[] args )
      {
         var directoryWrap = new DirectoryWrap();
         var consoleWrap = new ConsoleWrap();

         var appController = new AppController( directoryWrap, consoleWrap );
         appController.Start();
      }
   }
}
