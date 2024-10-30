using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SPLIT_PATTERN = @"\s+";

        public string GetResult(string inputStr)
        {
            var inputList = Regex.Split(inputStr, SPLIT_PATTERN).Select(s => new WordCountPair(s, 1)).ToList();

            var list = GetListMap(inputList)
                .Select(entry => new WordCountPair(entry.Key, entry.Value))
                .OrderByDescending(w => w.Count)
                .ToList();

            return string.Join("\n", list.Select(w => $"{w.Value} {w.Count}"));
        }

        private Dictionary<string, int> GetListMap(List<WordCountPair> inputList)
        {
            return inputList
                .GroupBy(input => input.Value)
                .ToDictionary(group => group.Key, group => group.Count());
        }
    }
}
