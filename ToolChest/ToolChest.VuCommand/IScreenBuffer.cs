using System;
using ToolChest.VuCommand.Internal;

namespace ToolChest.VuCommand
{
   public interface IScreenBuffer
   {
      void Render( Action<CharInfo[]> renderAction );
   }
}
