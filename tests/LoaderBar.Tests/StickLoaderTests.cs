namespace LoaderBar.Tests;

public class StickLoaderTests
{
    private readonly StickLoader _loader = new();
    
    [Fact]
    public void GetTickChar_ShouldReturnCorrectChar()
    {
        // Arrange
        var expected = _loader.LoaderCharacters[0];
        
        // Act
        var actual = _loader.GetTickChar();
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void GetTickChar_ShouldReturnCorrectCharAfterMultipleCalls()
    {
        // Arrange
        var expected = _loader.LoaderCharacters[^1];
        
        // Act
        for (var i = 0; i < _loader.LoaderCharacters.Length - 1; i++) {
            _loader.GetTickChar();
        }
        var actual = _loader.GetTickChar();
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void GetTickChar_ShouldReturnCorrectAfterRoundtripLoaderCharactersArray()
    {
        // Arrange
        var expected = _loader.LoaderCharacters[0];
        
        // Act
        for (var i = 0; i < _loader.LoaderCharacters.Length; i++) {
            _loader.GetTickChar();
        }
        var actual = _loader.GetTickChar();
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Reset_ShouldReturnCorrectAfterReset()
    {
        // Arrange
        var expected = _loader.LoaderCharacters[0];
        
        // Act
        for (var i = 0; i < new Random().Next(minValue: 1, maxValue: int.MaxValue); i++) {
            _loader.GetTickChar();
        }
        _loader.Reset();
        var actual = _loader.GetTickChar();
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Reset_ShouldReturnCorrectAfterMultipleResets()
    {
        // Arrange
        var expected = _loader.LoaderCharacters[0];
        
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
    }
}