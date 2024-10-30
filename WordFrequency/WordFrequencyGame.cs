using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            //split the input string with 1 to n pieces of spaces
            string[] splitWordsList = Regex.Split(inputStr, @"\s+");

            List<WordFrequency> inputList = new List<WordFrequency>();
            foreach (var s in splitWordsList)
            {
                var existingInput = inputList.Find(input => input.Word == s);
                if (existingInput != null)
                {
                    existingInput.IncrementFrequency();
                }
                else
                {
                    WordFrequency input = new(s, 1);
                    inputList.Add(input);
                }
            }

            inputList.Sort((w1, w2) => w2.Frequency - w1.Frequency);

            List<string> strList = new List<string>();

            //stringJoiner joiner = new stringJoiner("\n");
            foreach (WordFrequency w in inputList)
            {
                string s = w.Word + " " + w.Frequency;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());
        }

    }
}
