namespace ToolChest.VuCommand
{
   internal static class Program
   {
      private static void Main( string[] args )
      {
         var outputController = new OutputController();
         var pager = new Pager();

         var appController = new AppController( outputController, pager );

         appController.Start( args );
      }
   }
}
