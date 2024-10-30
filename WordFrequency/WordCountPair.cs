namespace WordFrequency
{
    public class WordCountPair
    {
        private string _value;
        private int _count;

        public WordCountPair(string value, int count)
        {
            this._value = value;
            this._count = count;
        }

        public string Value
        {
            get { return this._value; }
        }

        public int WordCount
        {
            get { return this._count; }
        }
    }
}
