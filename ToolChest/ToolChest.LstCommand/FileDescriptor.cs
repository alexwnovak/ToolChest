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

      public bool IsHidden
      {
         get;
      }

      public FileDescriptor( string fullPath, long size, bool isDirectory, bool isHidden )
      {
         FullPath = fullPath;
         Size = size;
         IsDirectory = isDirectory;
         IsHidden = isHidden;
      }
   }
}
