using System;

namespace ToolChest.VuCommand
{
   public class Pager : IPager
   {
      private readonly IScreenController _screenController;
      private readonly IInputController _inputController;
      private readonly IFileReader _fileReader;

      public Pager( IScreenController screenController, IInputController inputController, IFileReader fileReader )
      {
         _screenController = screenController;
         _inputController = inputController;
         _fileReader = fileReader;
      }

      public void Display( string fileName )
      {
         _screenController.IsCursorVisible = false;
         _screenController.Clear();

         _fileReader.Open( fileName );
         var lines = _fileReader.ReadLines( _screenController.ScreenHeight - 1 );

         _screenController.PrintLines( lines );
         _screenController.DrawStatusBar();
         _screenController.Print( $"Viewing: {fileName}", 0, _screenController.ScreenHeight - 1 );

         while ( true )
         {
            var key = _inputController.ReadKey();

            if ( key.Key == ConsoleKey.Escape )
            {
               break;
            }
            if ( key.Key == ConsoleKey.DownArrow )
            {
               string nextLine = _fileReader.ReadNextLine();

               if ( nextLine != null )
               {
                  _screenController.ScrollDown( 1 );
                  _screenController.Print( nextLine, 0, _screenController.ScreenHeight - 2 );
               }
            }
            else if ( key.Key == ConsoleKey.UpArrow )
            {
               _screenController.ScrollUp( 1 );

               string previousLine = _fileReader.ReadPreviousLine();
               _screenController.Print( previousLine, 0, 0 );
            }
         }

         _screenController.HideStatusBar();

         _screenController.IsCursorVisible = true;
         _screenController.CursorLeft = 0;
         _screenController.CursorTop = _screenController.ScreenHeight;
      }
   }
}
