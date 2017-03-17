using System;

namespace ToolChest.VuCommand
{
   public class InputController : IInputController
   {
      public ConsoleKeyInfo ReadKey() => Console.ReadKey( true );
   }
}
