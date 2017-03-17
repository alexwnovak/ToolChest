using System.Runtime.InteropServices;

namespace ToolChest.VuCommand.Internal
{
   [StructLayout( LayoutKind.Sequential )]
   internal struct Coord
   {
      public short X;
      public short Y;

      public Coord( short x, short y )
      {
         X = x;
         Y = y;
      }
   }
}
