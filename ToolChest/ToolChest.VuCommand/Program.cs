namespace ToolChest.VuCommand
{
   internal static class Program
   {
      private static void Main( string[] args )
      {
         var outputController = new OutputController();

         var screenBuffer = new ScreenBuffer();
         var screenController = new ScreenController( screenBuffer );
         var pager = new Pager( screenController, null );

         var appController = new AppController( outputController, pager );

         appController.Start( args );
      }
   }
}
