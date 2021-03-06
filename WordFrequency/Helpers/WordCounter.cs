﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordFrequency.Helpers
{
    public static class WordCounter
    {
        
        public static Dictionary<string, int> GetWordCount(string code)
        {
            var retDictionary = new Dictionary<string, int>();

            var words = Regex.Split(code, @"[\W]");
            foreach (string word in words)
            {
                if (word.Length <= 0) continue;
                if (int.TryParse(word,out _)) continue;
                
                if (retDictionary.ContainsKey(word))
                {
                    retDictionary[word]++;
                }
                else
                {
                    retDictionary.Add(word, 1);
                }

            }
            return retDictionary;
        }
    }
}
