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

      int CursorLeft
      {
         get;
         set;
      }

      int CursorTop
      {
         get;
         set;
      }

      bool IsCursorVisible
      {
         get;
         set;
      }

      void Render( Action<CharInfo[]> renderAction );
   }
}
