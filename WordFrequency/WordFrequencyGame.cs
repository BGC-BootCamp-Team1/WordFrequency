using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SPLIT_PATTERN = @"\s+";

        public string CalculateWordFrequency(string inputText)
        {
            List<Word> inputList = SplitInputStr(inputText);
            Dictionary<string, int> map = GetListMap(inputList);
            inputList = ConvertMapToList(map);
            SortInputList(inputList);

            return BuildResultString(inputList);

        }

        private static void SortInputList(List<Word> inputList)
        {
            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);
        }

        private static string BuildResultString(List<Word> inputList)
        {
            return string.Join("\n", inputList.Select(w => $"{w.Value} {w.WordCount}"));
        }

        private static List<Word> ConvertMapToList(Dictionary<string, int> map)
        {
            return map.Select(entry => new Word(entry.Key, entry.Value)).ToList();
        }

        private static List<Word> SplitInputStr(string inputStr)
        {
            return Regex.Split(inputStr, SPLIT_PATTERN)
            .Select(word => new Word(word, 1))
            .ToList();
        }

        private Dictionary<string, int> GetListMap(List<Word> inputList)
        {
            return inputList
            .GroupBy(input => input.Value)
            .ToDictionary(group => group.Key, group => group.Count());
        }
    }
}
