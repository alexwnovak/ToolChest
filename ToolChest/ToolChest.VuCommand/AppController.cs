using System.IO;

namespace ToolChest.VuCommand
{
   public class AppController
   {
      private readonly IOutputController _outputController;
      private readonly IPager _pager;

      public AppController( IOutputController outputController, IPager pager )
      {
         _outputController = outputController;
         _pager = pager;
      }

      public int Start( string[] args )
      {
         if ( args.Length == 0 )
         {
            _outputController.DisplaySyntax();
            return 1;
         }

         try
         {
            _pager.Display( args[0] );
         }
         catch ( FileNotFoundException )
         {
            _outputController.DisplayFileError( args[0] );
            return 1;
         }

         return 0;
      }
   }
}
