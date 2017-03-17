namespace ToolChest.VuCommand.Internal
{
   internal struct Rect
   {
      public short X1;
      public short Y1;
      public short X2;
      public short Y2;

      public Rect( short x1, short y1, short x2, short y2 )
      {
         X1 = x1;
         Y1 = y1;
         X2 = x2;
         Y2 = y2;
      }
   }
}
