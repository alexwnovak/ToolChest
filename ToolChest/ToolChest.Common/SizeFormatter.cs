namespace ToolChest.Common
{
   public static class SizeFormatter
   {
      private static string GetDecimal( long size, double divisor, string label )
      {
         string decimalString = (size / divisor).ToString( "0.0" );
         var parts = decimalString.Split( '.' );

         if ( parts[0].Length == 1 )
         {
            return $"{decimalString} {label}";
         }

         if ( parts[0].Length == 2 )
         {
            return $" {parts[0]} {label}";
         }

         return $"{parts[0]} {label}";
      }

      public static string Format( long size )
      {
         if ( size < 1000 )
         {
            return $"{size,3} B ";
         }
         if ( size < 1000000 )
         {
            return GetDecimal( size, 1000.0, "KB" );
         }
         if ( size < 1000000000 )
         {
            return GetDecimal( size, 1000000.0, "MB" );
         }
         if ( size < 1000000000000 )
         {
            return GetDecimal( size, 1000000000.0, "GB" );
         }

         return GetDecimal( size, 1000000000000.0, "TB" );
      }
   }
}