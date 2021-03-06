﻿namespace ToolChest.VuCommand
{
   internal static class Program
   {
      private static void Main( string[] args )
      {
         var outputController = new OutputController();

         var screenBuffer = new ScreenBuffer();
         var screenController = new ScreenController( screenBuffer );

         var inputController = new InputController();
         var fileReader = new FileReader();

         var pager = new Pager( screenController, inputController, fileReader );

         var appController = new AppController( outputController, pager );

         appController.Start( args );
      }
   }
}
