using SystemWrapper;

namespace ToolChest.LstCommand
{
   public class OutputController : IOutputController
   {
      private readonly IConsoleWrap _console;

      public OutputController( IConsoleWrap console )
      {
         _console = console;
      }

      public void WriteFormatted( string line )
      {
         _console.Write( line );
      }
   }
}
