using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    public class StringManipulator
    {
        public ResultModel GetStringStatistics(string input)
        {
            var output = new ResultModel();

            string modifiedInput = input.Replace(Environment.NewLine, " ");

            // Total characters
            output.TotalCharacters = modifiedInput.Length;

            // Non-whitespace, non-line return characters
            string nonWhitespaceInput = modifiedInput.Replace(" ", "");

            output.CharactersWithoutWhitespace = modifiedInput.Where(x => x != ' ').Count();

            // Words
            output.Words = GetSeparateWords(modifiedInput);

            // word count
            output.WordCount = output.Words.Count;

            // list of unique words
            output.UniqueWords = output.Words.Distinct().ToList();


            // most used word
            output.MostUsedWord = FindMostUsedWord(output.Words);

            // list of unique (a-z) chars
            output.UniqueAlphaCharacters = GetUniqueCharacters(modifiedInput);

            // most used char
            output.MostUsedCharacter = FindMostUsedCharacter(modifiedInput);


            return output;
        }

        private char FindMostUsedCharacter(string modifiedInput)
        {
            Regex alphaCheck = new Regex("[^a-z]");

            string cleanedInput = alphaCheck.Replace(modifiedInput.ToLower(), "");

            List<char> chars = new List<char>();

            for (int i = 0; i < cleanedInput.Length; i++)
            {
                chars.Add(cleanedInput[i]);
            }

            var charsAndCounts = chars.GroupBy(x => x).Select(grouping => (Character: grouping.Key, CharCount: grouping.Count()));

            return charsAndCounts.OrderByDescending(x => x.CharCount).FirstOrDefault().Character;
        }

        private string FindMostUsedWord(List<string> words)
        {
            var wordsAndCounts = words.GroupBy(x => x).Select((word) => (Word: word.Key, WordCount: word.Count()) );

            return wordsAndCounts.OrderByDescending(x => x.WordCount).FirstOrDefault().Word;
        }

        private List<char> GetUniqueCharacters(string modifiedInput)
        {
            Regex alphaCheck = new Regex("[^a-z]");

            string cleanedInput = alphaCheck.Replace(modifiedInput.ToLower(), "");

            List<char> chars = new List<char>();

            for (int i = 0; i < cleanedInput.Length; i++)
            {
                chars.Add(cleanedInput[i]);
            }

            return chars.Distinct().ToList();
        }

        private List<string> GetSeparateWords(string modifiedInput)
        {
            List<string> output;

            Regex alphaCheck = new Regex("[^a-zA-Z ]");

            string cleanedInput = alphaCheck.Replace(modifiedInput, "");
            
            output = cleanedInput.Split(' ').Where(x => !String.IsNullOrWhiteSpace(x)).Select(x => x.ToLower()).ToList();

            return output;
        }
    }
}
