using System;
using System.Collections.Generic;

namespace ToolChest.LstCommand
{
   public static class ColorProvider
   {
      private static readonly Dictionary<string, ConsoleColor> _colorTable = CreateColorTable();

      private static Dictionary<string, ConsoleColor> CreateColorTable()
      {
         var colorTable = new Dictionary<string, ConsoleColor>();

         colorTable[".doc"] = ConsoleColor.Blue;
         colorTable[".docx"] = ConsoleColor.Blue;
         colorTable[".txt"] = ConsoleColor.Blue;
         colorTable[".md"] = ConsoleColor.Blue;

         colorTable[".bat"] = ConsoleColor.Green;
         colorTable[".com"] = ConsoleColor.Green;
         colorTable[".exe"] = ConsoleColor.Green;
         colorTable[".ps1"] = ConsoleColor.Green;

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
