using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFrequency.Helpers
{
    public static class WordCounter
    {
        private static readonly char[] codeSplitters = new [] {',', ' ', '{', '}', '[', ']', '(', ')',';','=','<','>','!','\n','+','-'};
        
        public static Dictionary<string, int> GetWordCount(string code)
        {
            var retDictionary = new Dictionary<string, int>();
            var words = code.Split(codeSplitters, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (retDictionary.ContainsKey(word))
                {
                    retDictionary[word] ++ ;
                }
                else
                {
                    retDictionary.Add(word,1);
                }
            }
            return retDictionary;
        }
    }
}
