using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SPLIT_PATTERN = @"\s+";

        public string GetResult(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, SPLIT_PATTERN);

            var inputList = arr.Select(s => new WordCountPair(s, 1)).ToList();

            var list = GetListMap(inputList)
                .Select(entry => new WordCountPair(entry.Key, entry.Value.Count))
                .OrderByDescending(w => w.Count)
                .ToList();

            return string.Join("\n", list.Select(w => $"{w.Value} {w.Count}"));
        }

        private Dictionary<string, List<WordCountPair>> GetListMap(List<WordCountPair> inputList)
        {
            Dictionary<string, List<WordCountPair>> map = new Dictionary<string, List<WordCountPair>>();
            return inputList
                .GroupBy(input => input.Value)
                .ToDictionary(group => group.Key, group => group.ToList());
        }
    }
}
