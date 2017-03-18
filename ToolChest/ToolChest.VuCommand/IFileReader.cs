namespace ToolChest.VuCommand
{
   public interface IFileReader
   {
      void Open( string fileName );
      string[] ReadLines( int count );
      string ReadNextLine();
      string ReadPreviousLine();
   }
}
