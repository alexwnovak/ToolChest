namespace ToolChest.SpaceCommand
{
   internal static class Program
   {
      private static int Main( string[] args )
      {
         var appController = new AppController( null );

         return appController.Start( args );
      }
   }
}
