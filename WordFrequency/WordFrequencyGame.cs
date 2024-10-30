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
            List<string> strList = new List<string>();

            //stringJoiner joiner = new stringJoiner("\n");
            foreach (Input w in inputList)
            {
                string s = w.Value + " " + w.WordCount;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());
        }

        private static List<Input> ConvertMapToList(Dictionary<string, int> map)
        {
            List<Input> inputList;
            List<Input> list = new List<Input>();
            foreach (var entry in map)
            {
                Input input = new Input(entry.Key, entry.Value);
                list.Add(input);
            }

            inputList = list;
            return inputList;
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
