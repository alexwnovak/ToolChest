namespace ToolChest.VuCommand
{
   public class ScreenController : IScreenController
   {
      private readonly IScreenBuffer _screenBuffer;

      public ScreenController( IScreenBuffer screenBuffer )
      {
         _screenBuffer = screenBuffer;
      }

      public void Clear()
      {
         _screenBuffer.Render( b =>
         {
            for ( int index = 0; index < b.Length; index++ )
            {
               b[index].AsciiChar = '\0';
               b[index].Attributes = 0 << 4 | 7;
            }
         } );
      }
   }
}
