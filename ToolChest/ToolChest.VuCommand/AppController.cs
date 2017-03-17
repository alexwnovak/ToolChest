namespace ToolChest.VuCommand
{
   public class AppController
   {
      private readonly IOutputController _outputController;
      private readonly IEnvironmentController _environmentController;
      private readonly IPager _pager;

      public AppController( IOutputController outputController, IEnvironmentController environmentController, IPager pager )
      {
         _outputController = outputController;
         _environmentController = environmentController;
         _pager = pager;
      }

      public void Start( string[] args )
      {
         if ( args.Length == 0 )
         {
            _outputController.DisplaySyntax();

            _environmentController.Exit( 1 );

            return;
         }

         _pager.Display( args[0] );
      }
   }
}
