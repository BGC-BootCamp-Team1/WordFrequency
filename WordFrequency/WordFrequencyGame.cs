using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            //split the input string with 1 to n pieces of spaces
            string[] arr = Regex.Split(inputStr, @"\s+");

            List<Input> inputList = new List<Input>();
            foreach (var s in arr)
            {
                var existingInput = inputList.Find(input => input.Value == s);
                if (existingInput != null)
                {
                    existingInput.AddOneCount();
                }
                else
                {
                    Input input = new(s, 1);
                    inputList.Add(input);
                }
            }

            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            List<string> strList = new List<string>();

            //stringJoiner joiner = new stringJoiner("\n");
            foreach (Input w in inputList)
            {
                string s = w.Value + " " + w.WordCount;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());
        }

    }
}
