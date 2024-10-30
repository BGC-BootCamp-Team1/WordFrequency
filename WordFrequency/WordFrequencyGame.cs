using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<WordCountPair> inputList = SplitWithSpaces(inputStr);
            Dictionary<string, List<WordCountPair>> map = GetListMap(inputList);
            inputList = Resort(map);
            return GenerateOutputString(inputList);
        }

        private static List<WordCountPair> Resort(Dictionary<string, List<WordCountPair>> map)
        {
            List<WordCountPair> list = map.Select( entry => new WordCountPair(entry.Key, entry.Value.Count)).ToList();
            list.Sort((w1, w2) => w2.getCount() - w1.getCount());
            return list;
        }

        private static List<WordCountPair> SplitWithSpaces(string inputStr)
        {
            return Regex.Split(inputStr, @"\s+")
                .Select( s => new WordCountPair(s, 1))
                .ToList();
        }

        private static string GenerateOutputString(List<WordCountPair> inputList)
        {
            return string.Join("\n", inputList.Select(w => w.getWord() + " " + w.getCount()).ToArray());
        }

        private Dictionary<string, List<WordCountPair>> GetListMap(List<WordCountPair> inputList)
        {
            return inputList
                .GroupBy(input => input.getWord())
                .ToDictionary( group => group.Key, group => group.ToList());
        }
    }
}
