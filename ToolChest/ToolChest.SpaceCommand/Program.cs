namespace ToolChest.SpaceCommand
{
   internal static class Program
   {
      private static int Main( string[] args )
      {
         var appController = new AppController( new DiskSpaceReader(), new OutputController() );

         return appController.Start( args );
      }
   }
}
