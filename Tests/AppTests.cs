using Xunit;

namespace MauiApp1.Tests;

public class AppTests
{
    [Fact]
    public void App_ShouldInitialize()
    {
        // Arrange & Act
        var app = new App();
        
        // Assert
        Assert.NotNull(app);
        Assert.NotNull(app.MainPage);
    }
    
    [Fact]
    public void MainPage_ShouldHaveCorrectTitle()
    {
        // Arrange
        var mainPage = new MainPage();
        
        // Act & Assert
        Assert.NotNull(mainPage);
        // Add more specific tests based on your MainPage implementation
    }
    
    [Theory]
    [InlineData("Hello")]
    [InlineData("World")]
    [InlineData("MAUI")]
    public void SampleParameterizedTest(string input)
    {
        // Arrange & Act
        var result = input.ToUpper();
        
        // Assert
        Assert.Equal(input.ToUpper(), result);
    }
}