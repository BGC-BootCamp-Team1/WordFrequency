namespace WordFrequency
{
    public class Input
    {
        public Input(string value, int count)
        {
            Value = value;
            WordCount = count;
        }

        public string Value { get; }
        public int WordCount { get; }
    }
}
