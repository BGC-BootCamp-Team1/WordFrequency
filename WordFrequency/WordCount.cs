
namespace WordFrequency
{
    public class WordCount
    {
        public string Word { get; private set; }
        public int Frequency { get; private set; }

        public WordCount(string word, int frequency)
        {
            this.Word = word;
            this.Frequency = frequency;
        }

        public override string ToString()
        {
            return this.Word + " " + this.Frequency; ;
        }
    }
}
