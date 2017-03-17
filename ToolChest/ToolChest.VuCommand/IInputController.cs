using System;

namespace ToolChest.VuCommand
{
   public interface IInputController
   {
      ConsoleKeyInfo ReadKey();
   }
}
