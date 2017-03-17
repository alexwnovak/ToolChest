using System;
using ToolChest.VuCommand.Interop;

namespace ToolChest.VuCommand
{
   public interface IScreenBuffer
   {
      int Width
      {
         get;
      }

      int Height
      {
         get;
      }

      void Render( Action<CharInfo[]> renderAction );
   }
}
