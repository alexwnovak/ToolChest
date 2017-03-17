namespace ToolChest.VuCommand
{
   public interface IOutputController
   {
      void DisplaySyntax();
      void DisplayFileError( string filePath );
   }
}
