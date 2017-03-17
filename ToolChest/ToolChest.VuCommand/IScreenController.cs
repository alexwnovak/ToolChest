namespace ToolChest.VuCommand
{
   public interface IScreenController
   {
      int ScreenHeight
      {
         get;
      }

      void Clear();

      void PrintLines( string[] lines );
   }
}
