using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(assemblyName: "LoaderBar.Tests")]
namespace LoaderBar;

public class StickLoader : ILoader
{
    private const byte IndexOffset = 1;
    private int _currentIndex;
    
    internal static readonly char[] LoaderCharacters
        = ['|', '/', '-', '\\'];

    public int CurrentTick { get; private set; }

    public char GetTickChar()
    {
        var character = LoaderCharacters[_currentIndex];
        SetNextIndex(CalculateNextIndex());
        IncrementTick();
        return character;
    }

    public void Reset()
    {
        SetNextIndex(default);
        CurrentTick = default;
    }


    private int CalculateNextIndex()
        => (_currentIndex + IndexOffset) % LoaderCharacters.Length;
        
    private void SetNextIndex(int newIndex)
        => _currentIndex = newIndex;
    
    private void IncrementTick()
        => CurrentTick++;
}