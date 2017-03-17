using System;
using Moq;
using Xunit;

namespace ToolChest.VuCommand.UnitTests
{
   public class PagerTests
   {
      [Fact]
      public void Display_HasFile_HidesCursor()
      {
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.Setup( ic => ic.ReadKey() ).Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( "File.txt" );

         // Assert

         screenControllerMock.VerifySet( sc => sc.IsCursorVisible = false, Times.Once() );
      }

      [Fact]
      public void Display_HasFile_RestoresCursor()
      {
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.Setup( ic => ic.ReadKey() ).Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( "File.txt" );

         // Assert

         screenControllerMock.VerifySet( sc => sc.IsCursorVisible = true, Times.Once() );
      }

      [Fact]
      public void Display_HasFile_ClearsScreen()
      {
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.Setup( ic => ic.ReadKey() ).Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( "File.txt" );

         // Assert

         screenControllerMock.Verify( sc => sc.Clear(), Times.Once() );
      }

      [Fact]
      public void Display_HasFile_DisplaysAScreenOfText()
      {
         const string fileName = "SomeFile.txt";
         const int screenHeight = 25;
         var lines = new string[screenHeight];
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();
         screenControllerMock.SetupGet( sc => sc.ScreenHeight ).Returns( screenHeight );

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.Setup( ic => ic.ReadKey() ).Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();
         fileReaderMock.Setup( fr => fr.ReadLines( fileName, screenHeight - 1 ) ).Returns( lines );

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( fileName );

         // Assert

         screenControllerMock.Verify( sc => sc.PrintLines( lines ), Times.Once() );
      }

      [Fact]
      public void Display_HasFile_WaitsForEscapeKeyBeforeExiting()
      {
         var aKey = new ConsoleKeyInfo( 'A', ConsoleKey.A, false, false, false );
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();
         var fileReaderMock = new Mock<IFileReader>();

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.SetupSequence( ic => ic.ReadKey() )
            .Returns( aKey )
            .Returns( escKey );

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( "DoesNotMatter" );

         // Assert

         inputControllerMock.Verify( ic => ic.ReadKey(), Times.Exactly( 2 ) );
      }

      [Fact]
      public void Display_HasFile_CursorIsSetToBottomLeftOnExit()
      {
         const int screenHeight = 25;
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();
         screenControllerMock.SetupGet( sc => sc.ScreenHeight ).Returns( screenHeight );

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.Setup( ic => ic.ReadKey() ).Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( "DoesNotMatter" );

         // Assert

         screenControllerMock.VerifySet( sc => sc.CursorLeft = 0, Times.Once() );
         screenControllerMock.VerifySet( sc => sc.CursorTop = screenHeight, Times.Once() );
      }

      [Fact]
      public void Display_HasFile_DrawsStatusBar()
      {
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.Setup( ic => ic.ReadKey() ).Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( "DoesNotMatter" );

         // Assert

         screenControllerMock.Verify( sc => sc.DrawStatusBar(), Times.Once() );
      }

      [Fact]
      public void Display_HasFile_HidesStatusBarOnExit()
      {
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.Setup( ic => ic.ReadKey() ).Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( "DoesNotMatter" );

         // Assert

         screenControllerMock.Verify( sc => sc.HideStatusBar(), Times.Once() );
      }

      [Fact]
      public void Display_HasFile_FileNameIsPrintedInStatusBar()
      {
         const int height = 25;
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );
         const string fileName = @"C:\Temp\BigFile.cs";
         string expectedText = $"Viewing: {fileName}";

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();
         screenControllerMock.SetupGet( sc => sc.ScreenHeight ).Returns( height );

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.Setup( ic => ic.ReadKey() ).Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( fileName );

         // Assert

         screenControllerMock.Verify( sc => sc.Print( expectedText, 0, height - 1 ), Times.Once() );
      }

      [Fact]
      public void Display_PressesDownArrow_ScrollsDownByOneRow()
      {
         const int height = 25;
         var downArrowKey = new ConsoleKeyInfo( (char) 80, ConsoleKey.DownArrow, false, false, false );
         var escKey = new ConsoleKeyInfo( (char) 27, ConsoleKey.Escape, false, false, false );
         const string fileName = @"C:\Temp\BigFile.cs";

         // Arrange

         var screenControllerMock = new Mock<IScreenController>();
         screenControllerMock.SetupGet( sc => sc.ScreenHeight ).Returns( height );

         var inputControllerMock = new Mock<IInputController>();
         inputControllerMock.SetupSequence( ic => ic.ReadKey() )
            .Returns( downArrowKey )
            .Returns( escKey );

         var fileReaderMock = new Mock<IFileReader>();

         // Act

         var pager = new Pager( screenControllerMock.Object, inputControllerMock.Object, fileReaderMock.Object );

         pager.Display( fileName );

         // Assert

         screenControllerMock.Verify( sc => sc.ScrollDown( 1 ), Times.Once() );
      }
   }
}
