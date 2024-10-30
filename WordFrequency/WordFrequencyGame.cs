using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            //split the input string with 1 to n pieces of spaces
            string[] splitWordsList = Regex.Split(inputStr, @"\s+");

            List<WordFrequency> wordFrequencyList = new List<WordFrequency>();
            foreach (var word in splitWordsList)
            {
                var existingInput = wordFrequencyList.Find(input => input.Word == word);
                if (existingInput != null)
                {
                    existingInput.IncrementFrequency();
                }
                else
                {
                    wordFrequencyList.Add(new(word));
                }
            }

            wordFrequencyList.Sort((w1, w2) => w2.Frequency - w1.Frequency);

            return string.Join("\n", wordFrequencyList);
        }

    }
}
