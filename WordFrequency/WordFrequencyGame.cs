using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            const string SPLIT_PATTERN = @"\s+";
            string[] splitWordsList = Regex.Split(inputStr, SPLIT_PATTERN);

            var wordFrequencyList = splitWordsList
                .GroupBy(word => word)
                .Select(group => new WordFrequency(group.Key, group.Count()))
                .ToList();

            wordFrequencyList.Sort((w1, w2) => w2.Frequency - w1.Frequency);

            return string.Join("\n", wordFrequencyList);
        }

    }
}
