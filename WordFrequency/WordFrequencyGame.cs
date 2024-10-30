using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            string[] splitWordsList = Regex.Split(inputStr, @"\s+");

            var wordFrequencyList = splitWordsList
                .GroupBy(word => word)
                .Select(group => new WordFrequency(group.Key, group.Count()))
                .ToList();

            wordFrequencyList.Sort((w1, w2) => w2.Frequency - w1.Frequency);

            return string.Join("\n", wordFrequencyList);
        }

    }
}
