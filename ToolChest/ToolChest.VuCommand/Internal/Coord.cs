using System.Runtime.InteropServices;

namespace ToolChest.VuCommand.Internal
{
   [StructLayout( LayoutKind.Sequential )]
   internal struct Coord
   {
      public short X;
      public short Y;
   }
}
