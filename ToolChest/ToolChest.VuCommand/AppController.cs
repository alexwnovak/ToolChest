namespace ToolChest.VuCommand
{
   public class AppController
   {
      private readonly IOutputController _outputController;
      private readonly IEnvironmentController _environmentController;

      public AppController( IOutputController outputController, IEnvironmentController environmentController )
      {
         _outputController = outputController;
         _environmentController = environmentController;
      }

      public void Start( string[] args )
      {
         _outputController.DisplaySyntax();

         _environmentController.Exit( 1 );
      }
   }
}
