using System;
using System.Collections.Generic;
using System.IO;

namespace ToolChest.VuCommand
{
   public class FileReader : IFileReader, IDisposable
   {
      private FileStream _fileStream;
      private StreamReader _streamReader;

      public void Open( string fileName )
      {
         _fileStream = new FileStream( fileName, FileMode.Open, FileAccess.Read );
         _streamReader = new StreamReader( _fileStream );
      }

      public string[] ReadLines( string fileName, int count )
      {
         var lines = new List<string>();

         for ( int index = 0; index < count; index++ )
         {
            string line = _streamReader.ReadLine();

            if ( _streamReader.EndOfStream )
            {
               break;
            }

            lines.Add( line );
         }

         return lines.ToArray();
      }

      public string ReadNextLine() => _streamReader.ReadLine();

      public void Dispose()
      {
         Dispose( true );
         GC.SuppressFinalize( this );
      }

      protected virtual void Dispose( bool disposing )
      {
         if ( disposing )
         {
            _streamReader?.Dispose();
            _fileStream?.Dispose();
         }
      }
   }
}
