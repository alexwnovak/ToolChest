namespace ToolChest.VuCommand
{
   public interface IFileReader
   {
      string[] ReadLines( string fileName, int count );
   }
}
