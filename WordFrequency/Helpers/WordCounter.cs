using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordFrequency.Helpers
{
    public static class WordCounter
    {
        private static readonly char[] codeSplitters = new [] {',', ' ', '{', '}', '[', ']', '(', ')',';','=','<','>','!','\n','+','-'};
        
        public static Dictionary<string, int> GetWordCount(string code)
        {
            var retDictionary = new Dictionary<string, int>();
            int dummyOut;

            //var words = code.Split(codeSplitters, StringSplitOptions.RemoveEmptyEntries);
            var words = Regex.Split(code, @"[\W]");
            foreach (string word in words)
            {
                if (word.Length <= 0) continue;
                if (int.TryParse(word,out dummyOut)) continue;
                
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
