using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency;

public class WordFrequencyGame
{
    public string GetResult(string inputStr)
    {

        string[] splitedInput = Regex.Split(inputStr, @"\s+");

        List<WordCount> wordCounts = splitedInput.Select(s => new WordCount(s, 1)).ToList(); ;



        List<WordCount> resultList = TransformToOutputList(wordCounts);

        List<string> strList = resultList.Select(wc => $"{wc.Word} {wc.Count}").ToList();

        return string.Join("\n", strList);

    }

    

    private List<WordCount> TransformToOutputList(List<WordCount> wordCounts)
    {
        Dictionary<string, int> wordCountMap = GetWordCountMap(wordCounts);


        List<WordCount> resultList = wordCountMap.Select(entry => new WordCount(entry.Key, entry.Value)).ToList();

        resultList.Sort((w1, w2) => w2.Count - w1.Count);
        return resultList;
    }


    private Dictionary<string, int> GetWordCountMap(List<WordCount> wordCounts)
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        foreach (var wc in wordCounts)
        {
            if (!map.ContainsKey(wc.Word))
            {
                map[wc.Word] = 1;
            }
            else
            {
                map[wc.Word]++;
            }
        }

        return map;
    }
}



