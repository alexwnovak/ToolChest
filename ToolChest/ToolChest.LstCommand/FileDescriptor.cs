namespace ToolChest.LstCommand
{
   public struct FileDescriptor
   {
      public string FullPath
      {
         get;
      }

      public long Size
      {
         get;
      }

      public bool IsDirectory
      {
         get;
      }

      public FileDescriptor( string fullPath, long size, bool isDirectory )
      {
         FullPath = fullPath;
         Size = size;
         IsDirectory = isDirectory;
      }
   }
}
