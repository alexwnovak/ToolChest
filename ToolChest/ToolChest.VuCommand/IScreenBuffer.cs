using System;
using ToolChest.VuCommand.Interop;

namespace ToolChest.VuCommand
{
   public interface IScreenBuffer
   {
      void Render( Action<CharInfo[]> renderAction );
   }
}
