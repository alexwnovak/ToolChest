using FluentAssertions;
using Xunit;

namespace ToolChest.LstCommand.UnitTests
{
   public class SizeFormatterTests
   {
      [Fact]
      public void Format_SizeIs5Bytes_Returns5B()
      {
         string sizeString = SizeFormatter.Format( 5 );

         sizeString.Should().Be( "  5 B " );
      }

      [Fact]
      public void Format_SizeIs400Bytes_Returns400BWithCorrectTrailingSpace()
      {
         string sizeString = SizeFormatter.Format( 400 );

         sizeString.Should().Be( "400 B " );
      }

      [Fact]
      public void Format_SizeIs12Kilobytes_Returns12K()
      {
         string sizeString = SizeFormatter.Format( 12100 );

         sizeString.Should().Be( " 12 KB" );
      }

      [Fact]
      public void Format_SizeIs12Megabytes_Returns12MB()
      {
         string sizeString = SizeFormatter.Format( 12100300 );

         sizeString.Should().Be( " 12 MB" );
      }

      [Fact]
      public void Format_SizeIs12Gigabytes_Returns12GB()
      {
         string sizeString = SizeFormatter.Format( 12100300123L );

         sizeString.Should().Be( " 12 GB" );
      }

      [Fact]
      public void Format_SizeIs12Terabytes_Returns12TB()
      {
         string sizeString = SizeFormatter.Format( 12100300123888L );

         sizeString.Should().Be( " 12 TB" );
      }
   }
}
