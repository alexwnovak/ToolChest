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

      public FileDescriptor( string fullPath, long size )
      {
         FullPath = fullPath;
         Size = size;
      }
   }
}
