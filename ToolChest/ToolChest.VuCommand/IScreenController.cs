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

      bool IsCursorVisible
      {
         get;
         set;
      }

      void Clear();

      void PrintLines( string[] lines );
   }
}
