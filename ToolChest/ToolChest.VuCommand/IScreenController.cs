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

      int CursorLeft
      {
         get;
         set;
      }

      int CursorTop
      {
         get;
         set;
      }

      void Clear();

      void PrintLines( string[] lines );

      void DrawStatusBar();
      void HideStatusBar();
      void Print( string text, int column, int row );

      void ScrollDown( int rows );
      void ScrollUp( int rows );
   }
}
