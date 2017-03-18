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

      [Fact]
      public void ReadNextLine_HasNextLine_ReadsLine()
      {
         FileHelper.UseTempFile( "one\r\ntwo", f =>
         {
            using ( var fileReader = new FileReader() )
            {
               fileReader.Open( f );

               string line = fileReader.ReadNextLine();
               line.Should().Be( "one" );

               string line2 = fileReader.ReadNextLine();
               line2.Should().Be( "two" );
            }
         } );
      }

      [Fact]
      public void ReadPreviousLine_HasPreviousLine_ReadsLine()
      {
         FileHelper.UseTempFile( "one\r\ntwo", f =>
         {
            using ( var fileReader = new FileReader() )
            {
               fileReader.Open( f );
               fileReader.ReadLines( 2 );

               string line = fileReader.ReadPreviousLine();
               line.Should().Be( "one" );
            }
         } );
      }

      [Fact]
      public void ReadPreviousLine_HasReadPreviouslyAlready_ReadsLine()
      {
         FileHelper.UseTempFile( "one\r\ntwo\r\nthree", f =>
         {
            using ( var fileReader = new FileReader() )
            {
               fileReader.Open( f );
               fileReader.ReadLines( 3 );

               string line = fileReader.ReadPreviousLine();
               line.Should().Be( "two" );

               string line2 = fileReader.ReadPreviousLine();
               line2.Should().Be( "one" );
            }
         } );
      }
   }
}
