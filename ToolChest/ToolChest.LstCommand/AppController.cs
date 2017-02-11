﻿using System.IO;
using SystemWrapper;

namespace ToolChest.LstCommand
{
   public class AppController
   {
      private readonly IFileSystem _fileSystem;
      private readonly IConsoleWrap _console;

      public AppController( IFileSystem fileSystem, IConsoleWrap console )
      {
         _fileSystem = fileSystem;
         _console = console;
      }

      public void Start()
      {
         var fileDescriptors = _fileSystem.GetFiles( "." );

         foreach ( var fileDescriptor in fileDescriptors )
         {
            string trimmedFile = Path.GetFileName( fileDescriptor.FullPath );
            string sizeString = SizeFormatter.Format( fileDescriptor.Size );

            string wholeLine = $"{sizeString}  {trimmedFile}";

            _console.WriteLine( wholeLine );
         }
      }
   }
}
