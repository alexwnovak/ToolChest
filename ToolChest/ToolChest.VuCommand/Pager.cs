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

         var lines = _fileReader.ReadLines( fileName, _screenController.ScreenHeight - 1 );

         _screenController.PrintLines( lines );
         _screenController.DrawStatusBar();

         while ( true )
         {
            var key = _inputController.ReadKey();

            if ( key.Key == ConsoleKey.Escape )
            {
               break;
            }
         }

         _screenController.IsCursorVisible = true;
         _screenController.CursorLeft = 0;
         _screenController.CursorTop = _screenController.ScreenHeight;
      }
   }
}
