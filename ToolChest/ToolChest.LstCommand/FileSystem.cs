using System.IO;
using System.Linq;

namespace ToolChest.LstCommand
{
   public class FileSystem : IFileSystem
   {
      public FileDescriptor[] GetFiles( string path )
      {
         return ( from f in Directory.GetFiles( path )
                  let fi = new FileInfo( f )
                  select new FileDescriptor( fi.FullName, fi.Length ) ).ToArray();
      }
   }
}
