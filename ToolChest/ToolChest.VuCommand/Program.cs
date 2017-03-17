namespace ToolChest.VuCommand
{
   internal static class Program
   {
      private static void Main( string[] args )
      {
         var outputController = new OutputController();

         var screenController = new ScreenController();
         var pager = new Pager( screenController );

         var appController = new AppController( outputController, pager );

         appController.Start( args );
      }
   }
}
