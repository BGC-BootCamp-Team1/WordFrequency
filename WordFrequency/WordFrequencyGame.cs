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
            var wordList = Regex.Split(inputText, SPLIT_PATTERN);
            var wordFrequencyList = wordList
                .GroupBy(word => word)
                .Select(group => new Word(group.Key,group.Count()))
                .ToList();

            SortInputList(wordFrequencyList);

            return BuildResultString(wordFrequencyList);

        }

        private static void SortInputList(List<Word> inputList)
        {
            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);
        }

        private static string BuildResultString(List<Word> inputList)
        {
            return string.Join("\n", inputList.Select(w => $"{w.Value} {w.WordCount}"));
        }


    }
}
