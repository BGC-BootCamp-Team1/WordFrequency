using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency;

public class WordFrequencyGame
{
    private static string[] SplitInputString(string inputStr)
    {
        string[] arr = Regex.Split(inputStr, @"\s+");
        if (arr.Length == 1)
        {
            return new string[] { $"{arr[0]} 1" };
        }

        return arr;

    }
    public string GetResult(string inputStr)
    {

        
        
        string[] splitedInput = SplitInputString(inputStr);

        List<WordCount>wordCounts = splitedInput.Select(s => new WordCount(s, 1)).ToList(); ;

        
        // Get the map for the next step of sizing the same word
        Dictionary<string, int> wordCountMap = GetWordCountMap(wordCounts);

       
        List<WordCount> resultList = wordCountMap.Select(entry => new WordCount(entry.Key, entry.Value)).ToList();

        resultList.Sort((w1, w2) => w2.Count - w1.Count);

        List<string> strList = resultList.Select(wc => $"{wc.Word} {wc.Count}").ToList();

        return string.Join("\n", strList);

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



//namespace WordFrequency
//{
//    public class WordFrequencyGame
//    {
//        public string GetResult(string inputStr)
//        {
//            if (Regex.Split(inputStr, @"\s+").Length == 1)
//            {
//                return inputStr + " 1";
//            }
//            else
//            {
//                //split the input string with 1 to n pieces of spaces
//                string[] arr = Regex.Split(inputStr, @"\s+");

//                List<Input> inputList = new List<Input>();
//                foreach (var s in arr)
//                {
//                    Input input = new Input(s, 1);
//                    inputList.Add(input);
//                }

//                //get the map for the next step of sizing the same word
//                Dictionary<string, List<Input>> map = GetListMap(inputList);

//                List<Input> list = new List<Input>();
//                foreach (var entry in map)
//                {
//                    Input input = new Input(entry.Key, entry.Value);
//                    list.Add(input);
//                }

//                inputList = list;

//                inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

//                List<string> strList = new List<string>();

//                //stringJoiner joiner = new stringJoiner("\n");
//                foreach (Input w in inputList)
//                {
//                    string s = w.Value + " " + w.WordCount;
//                    strList.Add(s);
//                }

//                return string.Join("\n", strList.ToArray());
//            }
//        }

//        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
//        {
//            Dictionary<string, List<Input>> map = new Dictionary<string, List<Input>>();
//            foreach (var input in inputList)
//            {
//                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
//                if (!map.ContainsKey(input.Value))
//                {
//                    List<Input> arr = new List<Input>();
//                    arr.Add(input);
//                    map.Add(input.Value, arr);
//                }
//                else
//                {
//                    map[input.Value].Add(input);
//                }
//            }

//            return map;
//        }
//    }
//}
