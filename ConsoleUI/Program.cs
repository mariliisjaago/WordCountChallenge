using System;

namespace ConsoleUI
{
    class Program
    {
        private static string[] tests = new string[]
        {
            @"The test of the 
            best way to handle

multiple lines,   extra spaces and more.",
            @"Using the starter app, create code that will 
loop through the strings and identify the total 
character count, the number of characters
excluding whitespace (including line returns), and the
number of words in the string. Finally, list each word, ensuring it
is a valid word."
        };

        static void Main(string[] args)
        {
            

            var manipulator = new StringManipulator();

            foreach (var item in tests)
            {
                var results = manipulator.GetStringStatistics(item);

                Console.WriteLine($"Total chars: { results.TotalCharacters }");
                Console.WriteLine($"Chars without whitespace: { results.CharactersWithoutWhitespace }");
                Console.WriteLine($"Total words: { results.WordCount }");
                Console.WriteLine($"Most used word: { results.MostUsedWord }");
                Console.WriteLine($"Most used character: { results.MostUsedCharacter }");
            }


        }


    }
}
