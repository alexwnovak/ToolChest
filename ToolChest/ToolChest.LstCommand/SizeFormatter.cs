namespace ToolChest.LstCommand
{
   public static class SizeFormatter
   {
      public static string Format( long size )
      {
         if ( size < 1000 )
         {
            return $"{size,3} B ";
         }
         if ( size < 1000000 )
         {
            return $"{size / 1000,3} KB";
         }
         if ( size < 1000000000 )
         {
            return $"{size / 1000000,3} MB";
         }
         if ( size < 1000000000000 )
         {
            return $"{size / 1000000000,3} GB";
         }

         return $"{size / 1000000000000,3} TB";
      }
   }
}