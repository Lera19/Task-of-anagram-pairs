using System;
using System.Collections.Generic;
using System.Linq;
using TaskSolution.Interface;

namespace TaskSolution.Class
{
    /// <summary>Class <c>Anagram</c> is a utility class that calculate anagram pairs.
    /// </summary>
    public class Anagram
    {
        List<String> resultList = new List<String>();
        ICustomIO customIO;

        public Anagram(ICustomIO customIO)
        {
            this.customIO = customIO;
        }

        /// <summary>Calculation of anagram pairs.</summary> 
        /// <param><c>word</c> represents the input string.</param>
        /// <param><c>soFar</c> represents a new string.</param>
        void GetAnagram(string soFar, string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                resultList.Add(soFar);
                return;
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    string resultString = word.Substring(0, i) + word.Substring(i + 1);
                    GetAnagram(soFar + word[i], resultString);
                }
            }
        }

        /// <summary>Write in console anagram pairs.</summary><param><c>input</c> represents the input string.</param>
        public void ShowAnagramPairs(string input)
        {
            GetAnagram("", input);
            foreach (string str in resultList)
            {
                customIO.WriteString(str);
            }
            resultList.Clear();
        }

        /// <summary>Get count of anagram pairs.</summary><param><c>input</c> represents the input string.</param>
        public void GetCountOfAnagram(string input)
        {
            GetAnagram("", input);

            customIO.WriteString(resultList.Count());
            resultList.Clear();
        }
    }
}