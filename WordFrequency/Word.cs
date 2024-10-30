namespace WordFrequency
{
    public class Word
    {
        public Word(string value, int count)
        {
            Value = value;
            WordCount = count;
        }

        public string Value { get; }
        public int WordCount { get; }
    }
}
