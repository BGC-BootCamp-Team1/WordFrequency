
namespace WordFrequency
{
    public class WordFrequency
    {
        public string Word { get; private set; }
        public int Frequency { get; private set; }

        public WordFrequency(string word)
        {
            this.Word = word;
            this.Frequency = 1;
        }

        internal void IncrementFrequency()
        {
            this.Frequency++;
        }

        public override string ToString()
        {
            return this.Word + " " + this.Frequency; ;
        }
    }
}
