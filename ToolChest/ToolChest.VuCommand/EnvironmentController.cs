using System;

namespace ToolChest.VuCommand
{
   public class EnvironmentController : IEnvironmentController
   {
      public void Exit( int exitCode ) => Environment.Exit( exitCode );
   }
}
