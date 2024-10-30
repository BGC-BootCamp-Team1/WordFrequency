using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SPLIT_PATTERN = @"\s+";

        public string GetResult(string inputStr)
        {
            List<Input> inputList = SplitInputStr(inputStr);

            //get the map for the next step of sizing the same word
            Dictionary<string, int> map = GetListMap(inputList);
            inputList = ConvertMapToList(map);

            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            return BuildResultString(inputList);

        }

        private static string BuildResultString(List<Input> inputList)
        {
            return string.Join("\n", inputList.Select(w => $"{w.Value} {w.WordCount}"));
        }

        private static List<Input> ConvertMapToList(Dictionary<string, int> map)
        {
            return map.Select(entry => new Input(entry.Key, entry.Value)).ToList();
        }

        private static List<Input> SplitInputStr(string inputStr)
        {
            //split the input string with 1 to n pieces of spaces
            return Regex.Split(inputStr, SPLIT_PATTERN)
            .Select(word => new Input(word, 1))
            .ToList();
        }

        private Dictionary<string, int> GetListMap(List<Input> inputList)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Value))
                {
                    map[input.Value] = 1;
                }
                else
                {
                    map[input.Value]++;
                }
            }

            return map;
        }
    }
}
