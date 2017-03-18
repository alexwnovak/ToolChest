using System;
using System.Collections.Generic;
using System.IO;

namespace ToolChest.VuCommand
{
   public class FileReader : IFileReader, IDisposable
   {
      private FileStream _fileStream;
      private StreamReader _streamReader;

      private readonly List<string> _lines = new List<string>();
      private bool _readingForward;
      private int _lineNumber;

      public void Open( string fileName )
      {
         _fileStream = new FileStream( fileName, FileMode.Open, FileAccess.Read );
         _streamReader = new StreamReader( _fileStream );
      }

      public string[] ReadLines( int count )
      {
         _readingForward = true;
         var lines = new List<string>();

         for ( int index = 0; index < count; index++ )
         {
            string line = _streamReader.ReadLine();

            if ( line != null )
            {
               _lines.Add( line );
               lines.Add( line );
               _lineNumber++;
            }

            if ( _streamReader.EndOfStream )
            {
               break;
            }
         }

         return lines.ToArray();
      }

      public string ReadNextLine()
      {
         string line = _streamReader.ReadLine();

         _lines.Add( line );
         _lineNumber++;

         return line;
      }

      public string ReadPreviousLine()
      {
         if ( _readingForward )
         {
            _readingForward = false;
            _lineNumber--;
         }

         return _lines[--_lineNumber];
      }

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
