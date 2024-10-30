using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            List<Input> inputList = SplitWithSpaces(inputStr);
            Dictionary<string, List<Input>> map = GetListMap(inputList);
            inputList = Resort(map);
            return GenerateOutputString(inputList);
        }

        private static List<Input> Resort(Dictionary<string, List<Input>> map)
        {
            List<Input> list = map.Select( entry => new Input(entry.Key, entry.Value.Count))
                .ToList();
            list.Sort((w1, w2) => w2.WordCount - w1.WordCount);
            return list;
        }

        private static List<Input> SplitWithSpaces(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, @"\s+");
            return arr.Select( s => new Input(s, 1)).ToList();
        }

        private static string GenerateOutputString(List<Input> inputList)
        {
            return string.Join("\n", inputList.Select(w => w.Value + " " + w.WordCount).ToArray());
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            return inputList
                .GroupBy(input => input.Value)
                .ToDictionary( group => group.Key, group => group.ToList());
        }
    }
}
