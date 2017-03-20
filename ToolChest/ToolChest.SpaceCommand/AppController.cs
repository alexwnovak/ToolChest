namespace ToolChest.SpaceCommand
{
   public class AppController
   {
      private readonly IDiskSpaceReader _diskSpaceReader;
      private readonly IOutputController _outputController;

      public AppController( IDiskSpaceReader diskSpaceReader, IOutputController outputController )
      {
         _diskSpaceReader = diskSpaceReader;
         _outputController = outputController;
      }

      public int Start( string[] arguments )
      {
         long diskSpace = _diskSpaceReader.GetFreeDiskSpace();

         _outputController.PrintFreeDiskSpace( diskSpace );

         return 0;
      }
   }
}
