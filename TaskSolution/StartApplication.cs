using System;
using System.Text.RegularExpressions;
using TaskSolution.Class;
using TaskSolution.Interface;

namespace TaskSolution
{
    public class StartApplication
    {
        Anagram anagram;
        ICustomIO customIO;

        public StartApplication(ICustomIO customIO, Anagram anagram)
        {
            this.customIO = customIO;
            this.anagram = anagram;
        }

        public StartApplication(ICustomIO customIO)
        {
            this.customIO = customIO;
        }


        /// <summary>Set up user's input word</summary> 
        public string SetUserInputWord()
        {
            string resultString = null;
            do
            {
                customIO.WriteString("Input string for anagram: ");
                string temp = customIO.ReadString();
                if (CheckString(temp))
                {
                    resultString = temp;
                }
                else
                {
                    customIO.WriteString("Not correct string. Please, write again!");
                }
            } while (resultString == null);
            return resultString;
        }


        /// <summary>Method for user's menu.</summary> 
        public void StartApp()
        {
            while (true)
            {
                string messageString = SetUserInputWord();

                Console.Write("Меню:\n1) Anagram pairs \n2) Count of anagram pairs  \n\nYour choice: ");
                int inputUserOperation = CheckSelectedOperation();

                switch (inputUserOperation)
                {
                    case 1:
                        anagram.ShowAnagramPairs(messageString);
                        break;
                    case 2:
                        anagram.GetCountOfAnagram(messageString);
                        break;
                    default:
                        customIO.WriteString("Not correct input...");
                        break;
                }
                customIO.WriteString("\nEnter something...");
                customIO.ReadString();

                Console.Clear();
            }
        }


        /// <summary>Method that gets and checks user's input for operation</summary> 
        int CheckSelectedOperation()
        {
            int result = 0;
            do
            {
                try
                {
                    int tempOperation = int.Parse(customIO.ReadString());
                    if (tempOperation == 1 || tempOperation == 2)
                    {
                        result = tempOperation;
                    }
                }
                catch
                {
                    customIO.WriteString("Not correct operation, try again");
                }
            } while (result == 0);
            return result;
        }


        /// <summary>Check user's input word.</summary> 
        /// <param><c>inputString</c> user's input word</param>
        public bool CheckString(string inputString)
        {
            return inputString.Length >= 3 && inputString.Length <= 100 && inputString.Equals(inputString.ToLower()) && IsAlphabets(inputString);
        }

        /// <summary>Check user's input word that it has only small characters</summary> 
        /// <param><c>inputString</c> user's input word</param>
        public bool IsAlphabets(string inputString)
        {
            Regex isSmallAlphabets = new Regex("^[a-z]+$");
            return (isSmallAlphabets.IsMatch(inputString));
        }
    }
}

