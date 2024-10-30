using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<WordCountPair> inputList = SplitWithSpaces(inputStr);
            List<WordCountPair> wordCounts = CountInputWords(inputList);
            return GenerateOutputString(wordCounts);
        }

        private static List<WordCountPair> SplitWithSpaces(string inputStr)
        {
            return Regex.Split(inputStr, @"\s+")
                .Select( s => new WordCountPair(s, 1))
                .ToList();
        }

        private static string GenerateOutputString(List<WordCountPair> outputList)
        {
            return string.Join("\n", outputList.Select(w => w.getWord() + " " + w.getCount()).ToArray());
        }

        private static List<WordCountPair> CountInputWords(List<WordCountPair> inputList)
        {
            List<WordCountPair> inputWordCounts = inputList
                .GroupBy(input => input.getWord())
                .Select(group => new WordCountPair(group.Key,group.Count()))
                .ToList();
            inputWordCounts.Sort((w1, w2) => w2.getCount() - w1.getCount());
            return inputWordCounts;
        }
    }
}
