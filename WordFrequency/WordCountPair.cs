namespace WordFrequency
{
    public class WordCountPair(string word, int count)
    {
        private readonly string Word = word;
        private readonly int Count = count;

        public string getWord()
        {
            return Word; 
        }

        public int getCount()
        {
            return Count;
        }
    }
}
