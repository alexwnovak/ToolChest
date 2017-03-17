namespace ToolChest.VuCommand
{
   public class Pager : IPager
   {
      private readonly IScreenController _screenController;
      private readonly IFileReader _fileReader;

      public Pager( IScreenController screenController, IFileReader fileReader )
      {
         _screenController = screenController;
         _fileReader = fileReader;
      }

      public void Display( string fileName )
      {
         _screenController.Clear();

         var lines = _fileReader.ReadLines( fileName, _screenController.ScreenHeight );

         _screenController.PrintLines( lines );
      }
   }
}
