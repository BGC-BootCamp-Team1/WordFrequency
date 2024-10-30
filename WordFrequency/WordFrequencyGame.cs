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
            string[] arr = Regex.Split(inputStr, SPLIT_PATTERN);

            List<WordCountPair> inputList = new List<WordCountPair>();
            
            inputList.AddRange(arr.Select(s => new WordCountPair(s, 1)));

            Dictionary<string, List<WordCountPair>> map = GetListMap(inputList);

            List<WordCountPair> list = new List<WordCountPair>();

            list.AddRange(map.Select(entry => new WordCountPair(entry.Key, entry.Value.Count)));

            list.Sort((w1, w2) => w2.Count - w1.Count);

            List<string> strList = new List<string>();

            strList.AddRange(list.Select(w => $"{w.Value} {w.Count}"));

            return string.Join("\n", strList.ToArray());
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
