namespace ToolChest.LstCommand
{
   public interface IOutputController
   {
      void WriteFormatted( string line );
      void WriteHeader( string path );
   }
}
