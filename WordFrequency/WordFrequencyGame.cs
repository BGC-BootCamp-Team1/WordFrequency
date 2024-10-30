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
                .Select(group => new WordCount(group.Key, group.Count()))
                .ToList();

            wordFrequencyList.Sort((w1, w2) => w2.Count - w1.Count);

            return string.Join("\n", wordFrequencyList);
        }

    }
}
