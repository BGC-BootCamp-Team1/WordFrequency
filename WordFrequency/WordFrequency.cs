
namespace WordFrequency
{
    public class WordFrequency
    {
        private string word;
        private int frequency;

        public WordFrequency(string w, int i)
        {
            this.word = w;
            this.frequency = i;
        }

        public string Word
        {
            get { return this.word; }
        }

        public int Frequency
        {
            get { return this.frequency; }
        }

        internal void IncrementFrequency()
        {
            this.frequency++;
        }
    }
}
