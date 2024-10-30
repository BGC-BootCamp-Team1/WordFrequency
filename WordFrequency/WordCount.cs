
namespace WordFrequency
{
    public class WordCount
    {
        public string Word { get; private set; }
        public int Count { get; private set; }

        public WordCount(string word, int count)
        {
            this.Word = word;
            this.Count = count;
        }

        public override string ToString()
        {
            return this.Word + " " + this.Count; ;
        }
    }
}
