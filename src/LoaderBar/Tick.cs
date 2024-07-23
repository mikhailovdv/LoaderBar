namespace LoaderBar;

internal class Tick
{
    private readonly int _maxAllowedIndex;
    private readonly int _previousIndex;
    private readonly int _currentIndex;
    internal int Index => _currentIndex;
    internal int TotalTicks { get; }

    internal Tick(
        int maxAllowedIndex,
        int previousIndex,
        int currentIndex,
        int totalTicks)
    {
        _maxAllowedIndex = maxAllowedIndex;
        _previousIndex = previousIndex;
        _currentIndex = currentIndex;
        TotalTicks = totalTicks;
    }
    
    internal Tick Next()
        => new(
            maxAllowedIndex: _maxAllowedIndex,
            previousIndex: _currentIndex,
            currentIndex: (_currentIndex + 1) % _maxAllowedIndex,
            totalTicks: TotalTicks + 1);
}