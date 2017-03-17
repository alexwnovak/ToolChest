namespace ToolChest.VuCommand
{
   internal static class Program
   {
      private static void Main( string[] args )
      {
         var outputController = new OutputController();
         var environmentController = new EnvironmentController();
         var pager = new Pager();

         var appController = new AppController( outputController, environmentController, pager );

         appController.Start( args );
      }
   }
}
