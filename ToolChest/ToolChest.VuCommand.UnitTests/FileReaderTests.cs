using FluentAssertions;
using Xunit;
using ToolChest.VuCommand.UnitTests.Helpers;

namespace ToolChest.VuCommand.UnitTests
{
   public class FileReaderTests
   {
      [Fact]
      public void ReadLines_FileHasTwoLines_BothLinesAreRead()
      {
         FileHelper.UseTempFile( "one\r\ntwo", f =>
         {
            using ( var fileReader = new FileReader() )
            {
               fileReader.Open( f );
               var lines = fileReader.ReadLines( 2 );

               lines[0].Should().Be( "one" );
               lines[1].Should().Be( "two" );
            }
         } );
      }

      [Fact]
      public void ReadLines_TriesToReadMoreLinesThanAreAvailable_ReadsWhatsThere()
      {
         FileHelper.UseTempFile( "one\r\ntwo\r\nthree", f =>
         {
            using ( var fileReader = new FileReader() )
            {
               fileReader.Open( f );
               var lines = fileReader.ReadLines( 2 );

               lines[0].Should().Be( "one" );
               lines[1].Should().Be( "two" );
            }
         } );
      }
   }
}
