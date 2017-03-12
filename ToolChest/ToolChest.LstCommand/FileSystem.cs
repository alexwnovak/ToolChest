using System.IO;
using System.Linq;

namespace ToolChest.LstCommand
{
   public class FileSystem : IFileSystem
   {
      public FileDescriptor[] GetFiles( string path )
      {
         var files = from f in Directory.GetFiles( path )
                     let fi = new FileInfo( f )
                     select new FileDescriptor( fi.FullName, fi.Length, false, fi.Attributes.HasFlag( FileAttributes.Hidden ) );

         var directories = from d in Directory.GetDirectories( path )
                           let di = new DirectoryInfo( d )
                           select new FileDescriptor( di.Name, 0, true, di.Attributes.HasFlag( FileAttributes.Hidden ) );

         return directories.Concat( files ).ToArray();
      }
   }
}
