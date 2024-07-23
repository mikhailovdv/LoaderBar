namespace LoaderBar.Tests;

public class StickLoaderTests
{
    private readonly StickLoader _loader = new();
    
    [Fact]
    public void GetTickChar_ShouldReturnCorrectChar()
    {
        // Arrange
        var expected = StickLoader.LoaderCharacters[0];
        const int ticksCount = 1;
        
        // Act
        char actual = default;
        for (var i = 0; i < ticksCount; i++) {
            actual = _loader.GetTickChar();
        }
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(ticksCount, _loader.CurrentTick);
    }
    
    [Fact]
    public void GetTickChar_ShouldReturnCorrectCharAfterMultipleCalls()
    {
        // Arrange
        var expected = StickLoader.LoaderCharacters[^1];
        var ticksCount = StickLoader.LoaderCharacters.Length;
        
        // Act
        char actual = default;
        for (var i = 0; i < ticksCount; i++) {
            actual = _loader.GetTickChar();
        }
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(StickLoader.LoaderCharacters.Length, _loader.CurrentTick);
    }
    
    [Fact]
    public void GetTickChar_ShouldReturnCorrectAfterRoundtripLoaderCharactersArray()
    {
        // Arrange
        var expected = StickLoader.LoaderCharacters[0];
        var ticksCount = StickLoader.LoaderCharacters.Length + 1;
        
        // Act
        char actual = default;
        for (var i = 0; i < ticksCount; i++) {
            actual = _loader.GetTickChar();
        }
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(ticksCount, _loader.CurrentTick);
    }
    
    [Fact]
    public void Reset_ShouldReturnCorrectAfterReset()
    {
        // Arrange
        var expected = StickLoader.LoaderCharacters[0];
        const int ticksCount = 1;
        
        // Act
        for (var i = 0; i < new Random().Next(minValue: 1, maxValue: int.MaxValue); i++) {
            _loader.GetTickChar();
        }
        _loader.Reset();
        var actual = _loader.GetTickChar();
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(ticksCount, _loader.CurrentTick);
    }
    
    [Fact]
    public void Reset_ShouldReturnCorrectAfterMultipleResets()
    {
        // Arrange
        var expected = StickLoader.LoaderCharacters[0];
        const int ticksCount = 1;
        
        // Act
        for (var i = 0; i < new Random().Next(minValue: 1, maxValue: int.MaxValue); i++) {
            _loader.GetTickChar();
        }
        for (var i = 0; i < new Random().Next(minValue: 1, maxValue: int.MaxValue); i++) {
            _loader.Reset();
        }
        var actual = _loader.GetTickChar();
        
        // Assert
        Assert.Equal(expected, actual);
        Assert.Equal(ticksCount, _loader.CurrentTick);
    }
}