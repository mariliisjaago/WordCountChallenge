using System.Collections.Generic;

namespace ConsoleUI
{
    public class ResultModel
    {
        public int TotalCharacters { get; set; }
        public int CharactersWithoutWhitespace { get; set; }
        public int WordCount { get; set; }
        public List<string> Words { get; set; } = new List<string>();
        public List<string> UniqueWords { get; set; } = new List<string>();
        public string MostUsedWord { get; set; }
        public List<char> UniqueAlphaCharacters { get; set; } = new List<char>();
        public char MostUsedCharacter { get; set; }
    }
}
