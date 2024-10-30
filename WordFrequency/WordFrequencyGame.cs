using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            if (Regex.Split(inputStr, @"\s+").Length == 1)
            {
                return inputStr + " 1";
            }
            else
            {
                List<Input> inputList = SplitWithSpaces(inputStr);
                Dictionary<string, List<Input>> map = GetListMap(inputList);
                inputList = Resort(map);
                return GenerateOutputString(inputList);
            }
        }

        private static List<Input> Resort(Dictionary<string, List<Input>> map)
        {
            List<Input> list = new List<Input>();
            foreach (var entry in map)
            {
                Input input = new Input(entry.Key, entry.Value.Count);
                list.Add(input);
            }

            list.Sort((w1, w2) => w2.WordCount - w1.WordCount);
            return list;
        }

        private static List<Input> SplitWithSpaces(string inputStr)
        {
            string[] arr = Regex.Split(inputStr, @"\s+");

            List<Input> inputList = new List<Input>();
            foreach (var s in arr)
            {
                Input input = new Input(s, 1);
                inputList.Add(input);
            }

            return inputList;
        }

        private static string GenerateOutputString(List<Input> inputList)
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

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            Dictionary<string, List<Input>> map = new Dictionary<string, List<Input>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Value))
                {
                    List<Input> arr = new List<Input>();
                    arr.Add(input);
                    map.Add(input.Value, arr);
                }
                else
                {
                    map[input.Value].Add(input);
                }
            }

            return map;
        }
    }
}
