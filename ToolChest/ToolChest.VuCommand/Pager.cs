namespace ToolChest.VuCommand
{
   public class Pager : IPager
   {
      private readonly IScreenController _screenController;

      public Pager( IScreenController screenController )
      {
         _screenController = screenController;
      }

      public void Display( string fileName )
      {
         _screenController.Clear();
      }
   }
}
