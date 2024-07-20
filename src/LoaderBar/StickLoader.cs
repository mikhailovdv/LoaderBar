namespace LoaderBar;

public class StickLoader : ILoader
{
    private const byte IndexOffset = 1;
    private readonly char[] _loaderCharacters
        = ['|', '/', '-', '\\'];
    private int _currentIndex;

    public char GetTickChar()
    {
        var character = _loaderCharacters[_currentIndex];
        SetNextIndex(CalculateNextIndex());
        return character;
    }
    
    public void Reset()
        => SetNextIndex(default);
    
    
    private int CalculateNextIndex()
        => IncrementIndex() % _loaderCharacters.Length;
        
    private void SetNextIndex(int newIndex)
        => _currentIndex = newIndex;

    private int IncrementIndex()
        => _currentIndex + IndexOffset;
}