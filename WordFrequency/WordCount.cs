namespace WordFrequency;
public class WordCount
{
    public string Word { get; }
    public int Count { get; }

    public WordCount(string word, int count)
    {
        Word = word;
        Count = count;
    }
}

