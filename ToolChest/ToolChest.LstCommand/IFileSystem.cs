namespace ToolChest.LstCommand
{
   public interface IFileSystem
   {
      FileDescriptor[] GetFiles( string path );
   }
}
