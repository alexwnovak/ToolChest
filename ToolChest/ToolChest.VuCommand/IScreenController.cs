namespace ToolChest.VuCommand
{
   public interface IScreenController
   {
      int ScreenWidth
      {
         get;
      }

      int ScreenHeight
      {
         get;
      }

      void Clear();

      void PrintLines( string[] lines );
   }
}
