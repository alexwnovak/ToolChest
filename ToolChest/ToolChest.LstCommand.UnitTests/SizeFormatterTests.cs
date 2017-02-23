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

      [Fact]
      public void Format_SizeIs1500Bytes_ReturnsDecimal()
      {
         string sizeString = SizeFormatter.Format( 1500 );

         sizeString.Should().Be( "1.5 KB" );
      }

      [Fact]
      public void Format_SizeIs1600Kilobytes_ReturnsDecimal()
      {
         string sizeString = SizeFormatter.Format( 1600000 );

         sizeString.Should().Be( "1.6 MB" );
      }

      [Fact]
      public void Format_SizeIs2600Megabytes_ReturnsDecimal()
      {
         string sizeString = SizeFormatter.Format( 2600000000 );

         sizeString.Should().Be( "2.6 GB" );
      }

      [Fact]
      public void Format_SizeIs5200Gigabytes_ReturnsDecimal()
      {
         string sizeString = SizeFormatter.Format( 5200000000000L );

         sizeString.Should().Be( "5.2 TB" );
      }

      [Fact]
      public void Format_SizeIs19986KB_ReturnsNoDecimalPortion()
      {
         string sizeString = SizeFormatter.Format( 9986 );

         sizeString.Should().Be( "9.9 KB" );
      }

      [Fact]
      public void Format_SizeIs19986MB_ReturnsNoDecimalPortion()
      {
         string sizeString = SizeFormatter.Format( 9986000 );

         sizeString.Should().Be( "9.9 MB" );
      }

      [Fact]
      public void Format_SizeIs19986GB_ReturnsNoDecimalPortion()
      {
         string sizeString = SizeFormatter.Format( 9986000000 );

         sizeString.Should().Be( "9.9 GB" );
      }

      [Fact]
      public void Format_SizeIs19986TB_ReturnsNoDecimalPortion()
      {
         string sizeString = SizeFormatter.Format( 9986000000000L );

         sizeString.Should().Be( "9.9 TB" );
      }
   }
}
