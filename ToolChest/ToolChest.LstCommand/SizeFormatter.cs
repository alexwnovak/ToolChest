using System.Globalization;

namespace ToolChest.LstCommand
{
   public static class SizeFormatter
   {
      private static string GetDecimal( long size, double divisor, string label )
      {
         double decimalSize = size / divisor;

         if ( decimalSize < 10 )
         {
            return $"{decimalSize.ToString( CultureInfo.InvariantCulture ).Substring( 0, 3 )} {label}";
         }
         if ( decimalSize < 100 )
         {
            return $" {(int) decimalSize} {label}";
         }

         return $"{(int) decimalSize} {label}";
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