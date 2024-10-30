using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<WordCountPair> wordCounts = CountInputWords(inputStr);
            return GenerateOutputString(wordCounts);
        }

        private static List<WordCountPair> CountInputWords(string inputStr)
        {
            return Regex.Split(inputStr, @"\s+")
                .GroupBy(word => word)
                .Select(group => new WordCountPair(group.Key, group.Count()))
                .OrderByDescending(w => w.getCount())
                .ToList();
        }

        private static string GenerateOutputString(List<WordCountPair> outputList)
        {
            return string.Join("\n", outputList.Select(w => w.getWord() + " " + w.getCount()).ToArray());
        }
    }
}
