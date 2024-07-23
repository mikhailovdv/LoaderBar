namespace LoaderBar;

public interface ILoader
{
    int CurrentTick { get; }
    
    char GetTickChar();
        
    void Reset();
}