
namespace WordFrequency
{
    public class Input
    {
        private string value;
        private int count;

        public Input(string w, int i)
        {
            this.value = w;
            this.count = i;
        }

        public string Value
        {
            get { return this.value; }
        }

        public int WordCount
        {
            get { return this.count; }
        }

        internal void AddOneCount()
        {
            this.count++;
        }
    }
}
