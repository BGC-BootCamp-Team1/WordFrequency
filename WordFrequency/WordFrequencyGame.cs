using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        public string GetResult(string inputStr)
        {
            //split the input string with 1 to n pieces of spaces
            string[] arr = Regex.Split(inputStr, @"\s+");

            List<WordCountPair> inputList = new List<WordCountPair>();
            foreach (var s in arr)
            {
                WordCountPair input = new WordCountPair(s, 1);
                inputList.Add(input);
            }

            //get the map for the next step of sizing the same word
            Dictionary<string, List<WordCountPair>> map = GetListMap(inputList);

            List<WordCountPair> list = new List<WordCountPair>();
            foreach (var entry in map)
            {
                WordCountPair input = new WordCountPair(entry.Key, entry.Value.Count);
                list.Add(input);
            }

            inputList = list;

            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            List<string> strList = new List<string>();

            //stringJoiner joiner = new stringJoiner("\n");
            foreach (WordCountPair w in inputList)
            {
                string s = w.Value + " " + w.WordCount;
                strList.Add(s);
            }

            return string.Join("\n", strList.ToArray());
        }

        private Dictionary<string, List<WordCountPair>> GetListMap(List<WordCountPair> inputList)
        {
            Dictionary<string, List<WordCountPair>> map = new Dictionary<string, List<WordCountPair>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Value))
                {
                    List<WordCountPair> arr = new List<WordCountPair>();
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
