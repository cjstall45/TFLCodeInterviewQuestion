///In the programming language of your choice, write a program that parses a sentence and replaces each word with the following: 
///first letter, number of distinct characters between first and last character, and last letter. For example, Smooth would become S3h. 
///Words are separated by spaces or non-alphabetic characters and these separators should be maintained in their original form and location in the answer. 
///A few of the things we will be looking at is accuracy, efficiency, solution completeness.

using System;
using System.Collections.Generic;

namespace TFLCodeInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sentence: ");

            string input = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine(Program.AddChar(input));
        }

        /// <summary>
        /// a method that takes a string and returns it with each word printed as the first character, number of 
        /// unique characters, and last character
        /// </summary>
        /// <param name="sentence">input string that we addup chars in</param>
        /// <returns>formated string</returns>
        public static string AddChar(string sentence) 
        {
            var outputList = new List<char>();
            var seenChars = new List<char>();
            char firstLetter = ' ';
            char lastLetter = ' ';
            int loops = 1;
            //loop through each character in the string and determine first if it is a letter or not then evaluate cases based on that.
            foreach(var character in sentence)
            {
                if (Char.IsLetter(character))
                {
                    //three cases if it is a letter:
                    //1. it is the first letter of a word, we add it to output and store
                    //2. it is the last character in the string and we need to add our seen chars count and it to output
                    //3. it is a char in the middle of the word and needs to be added if we havent seen it to the seen chars list
                    if (firstLetter == ' ')
                    {
                        firstLetter = character;
                        outputList.Add(character);

                    }
                    else if (loops == sentence.Length)
                    {
                        var count = seenChars.Count.ToString();
                        foreach (var digit in count)
                        {
                            outputList.Add(digit);
                        }
                        outputList.Add(lastLetter);
                        break;
                    }
                    else if(!seenChars.Contains(character) && Char.IsLetter(sentence[loops]))
                    {
                        seenChars.Add(character);
                    }
                      
                    lastLetter = character;
                }
                else
                {
                    //if the character is not a letter it means we have 2 cases:
                    //1. we are in between words where a punctuation and space meet
                    //2. we have arrived at the end of a word and need to add our seen chars count and the last letter 
                    //either way we add the non letter character and add to the loop count for use in senerio 3 above
                    if (firstLetter != ' ')
                    {
                        var count = (seenChars.Count).ToString();
                        foreach (var digit in count)
                        {
                            outputList.Add(digit);
                        }
                        outputList.Add(lastLetter);
                        firstLetter = ' ';
                        lastLetter = ' ';
                        seenChars.Clear();
                    }
                    outputList.Add(character);
                }
                loops++;
            }
            return new string(outputList.ToArray());
        }
        
    }
}
