using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleTo(assemblyName: "LoaderBar.Tests")]
namespace LoaderBar;

public class StickLoader : ILoader
{
    internal static readonly char[] LoaderCharacters
        = ['|', '/', '-', '\\'];
    private Tick _tick
        = new(maxAllowedIndex: LoaderCharacters.Length,
             previousIndex: 0,
             currentIndex: 0,
             totalTicks: 0);

    public int CurrentTick => _tick.TotalTicks;

    public char GetTickChar()
        => LoaderCharacters[Interlocked.Exchange(ref _tick, _tick.Next()).Index];

    public void Reset()
    {
        _tick = new Tick(maxAllowedIndex: LoaderCharacters.Length,
            previousIndex: 0,
            currentIndex: 0,
            totalTicks: 0);
    }
}