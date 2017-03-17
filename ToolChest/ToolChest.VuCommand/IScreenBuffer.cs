using System;
using ToolChest.VuCommand.Interop;

namespace ToolChest.VuCommand
{
   public interface IScreenBuffer
   {
      int Height
      {
         get;
      }

      void Render( Action<CharInfo[]> renderAction );
   }
}
