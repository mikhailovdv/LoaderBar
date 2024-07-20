namespace LoaderBar;

public interface ILoader
{
    char[] LoaderCharacters { get; }
    
    char GetTickChar();
        
    void Reset();
}