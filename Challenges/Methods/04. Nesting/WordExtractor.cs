using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Methods.Nesting
{
    /// <summary>
    /// ID izazova je dostupan na web prikazu.
    /// 1. Razmotri sledeći kod i pojednostavi ga tako što ćeš izdvojiti složene celine u zasebne metode.
    /// </summary>
    public class WordExtractor
    {
        public static List<string> ExtractWordsAndSyntagms(string pascalCaseName)
        {
            var wordsSplitByCapitalLetters = Regex.Split(pascalCaseName, "[A-Z]");
            var capitalLetters = Regex.Matches(pascalCaseName, "[A-Z]");
            
            List<string> singleWords = new();
            for (int i = 0; i < capitalLetters.Count; i++)
            {
                singleWords.Add(capitalLetters[i] + wordsSplitByCapitalLetters[i + 1]);
            }

            // Syntagms are sets of more than 1 connected word
            if (singleWords.Count > 1)
            {
                List<string> syntagms = new List<string>();
                int startLength = 0;
                for (var i = 0; i <= singleWords.Count - 2; i++)
                {
                    int endLength = singleWords[i].Length;
                    for (var j = i + 1; j <= singleWords.Count - 1; j++)
                    {
                        endLength += singleWords[j].Length;
                        syntagms.Add(pascalCaseName.Substring(startLength, endLength));
                    }
                    startLength += singleWords[i].Length;
                }
                singleWords.AddRange(syntagms);
            }

            return singleWords;
        }
    }
}
