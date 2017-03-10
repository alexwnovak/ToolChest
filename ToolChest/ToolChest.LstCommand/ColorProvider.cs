using System;
using System.Collections.Generic;

namespace ToolChest.LstCommand
{
   public static class ColorProvider
   {
      private static readonly Dictionary<string, ConsoleColor> _colorTable = CreateColorTable();

      private static Dictionary<string, ConsoleColor> CreateColorTable()
      {
         var colorTable = new Dictionary<string, ConsoleColor>
         {
            [".doc"] = ConsoleColor.Blue,
            [".docx"] = ConsoleColor.Blue,
            [".txt"] = ConsoleColor.Blue,
            [".md"] = ConsoleColor.Blue,
            [".bat"] = ConsoleColor.Green,
            [".com"] = ConsoleColor.Green,
            [".exe"] = ConsoleColor.Green,
            [".ps1"] = ConsoleColor.Green
         };

         return colorTable;
      }

      public static ConsoleColor GetColor( string extension )
      {
         extension = extension.ToLower();
         ConsoleColor color;

         if ( !_colorTable.TryGetValue( extension, out color ) )
         {
            return ConsoleColor.Gray;
         }

         return color;
      }
   }
}
