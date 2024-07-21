using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "LoaderBar.Tests")]
namespace LoaderBar;

public class StickLoader : ILoader
{
    private const byte IndexOffset = 1;
    private int _currentIndex;
    
    internal static readonly char[] LoaderCharacters
        = ['|', '/', '-', '\\'];

    public char GetTickChar()
    {
        var character = LoaderCharacters[_currentIndex];
        SetNextIndex(CalculateNextIndex());
        return character;
    }
    
    public void Reset()
        => SetNextIndex(default);
    
    
    private int CalculateNextIndex()
        => IncrementIndex() % LoaderCharacters.Length;
        
    private void SetNextIndex(int newIndex)
        => _currentIndex = newIndex;

    private int IncrementIndex()
        => _currentIndex + IndexOffset;
}