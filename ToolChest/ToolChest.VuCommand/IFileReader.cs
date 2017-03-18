namespace ToolChest.VuCommand
{
   public interface IFileReader
   {
      void Open( string fileName );
      string[] ReadLines( string fileName, int count );
      string ReadNextLine();
   }
}
