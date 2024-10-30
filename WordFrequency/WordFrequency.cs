
namespace WordFrequency
{
    public class WordFrequency
    {
        public string Word { get; private set; }
        public int Frequency { get; private set; }

        public WordFrequency(string word, int frequency)
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
