using SystemWrapper;

namespace ToolChest.LstCommand
{
   internal static class Program
   {
      private static void Main( string[] args )
      {
         var directoryWrap = new FileSystem();
         var consoleWrap = new ConsoleWrap();

         var appController = new AppController( directoryWrap, consoleWrap );
         appController.Start();
      }
   }
}
