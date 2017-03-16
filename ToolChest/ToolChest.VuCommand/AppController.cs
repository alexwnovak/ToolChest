namespace ToolChest.VuCommand
{
   public class AppController
   {
      private readonly IOutputController _outputController;

      public AppController( IOutputController outputController )
      {
         _outputController = outputController;
      }

      public void Start( string[] args )
      {
         _outputController.DisplaySyntax();
      }
   }
}
