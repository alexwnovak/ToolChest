using System.Runtime.InteropServices;

namespace ToolChest.VuCommand.Interop
{
   [StructLayout( LayoutKind.Explicit )]
   public struct CharInfo
   {
      [FieldOffset( 0 )]
      public char UnicodeChar;
      [FieldOffset( 0 )]
      public char AsciiChar;
      [FieldOffset( 2 )]
      public ushort Attributes;
   }
}
