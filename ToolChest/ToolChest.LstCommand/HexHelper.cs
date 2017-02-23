namespace ToolChest.LstCommand
{
   internal static class HexHelper
   {
      public static int HexToInt( char h )
      {
         if ( (h >= '0') && (h <= '9') )
         {
            return (h - '0');
         }
         if ( (h >= 'a') && (h <= 'f') )
         {
            return ((h - 'a') + 10);
         }
         if ( (h >= 'A') && (h <= 'F') )
         {
            return ((h - 'A') + 10);
         }
         return -1;
      }
   }
}
