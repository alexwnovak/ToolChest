using FluentAssertions;
using Xunit;

namespace ToolChest.SpaceCommand.UnitTests
{
   public class AppControllerTests
   {
      [Fact]
      public void Start_NoArgumentsRunsNormally_ExitsWithCode0()
      {
         var appController = new AppController();

         int exitCode = appController.Start( new string[0] );

         exitCode.Should().Be( 0 );
      }
   }
}
