using System.Text;
using System.Text.RegularExpressions;

namespace TextFilter;

public class FileProcessor
{
    char[] _vowels = {'a', 'e', 'i', 'o', 'u'};

    public string FilterFile(string filePath)
    {
        StringBuilder filteredResult = new StringBuilder();
        Parallel.ForEach(File.ReadLines(filePath), line =>
        {
            ProcessLine(line, filteredResult);
        });
        return filteredResult.ToString().Trim();
    }

    private void ProcessLine(string line, StringBuilder filteredResult)
    {
        string[] words = Regex.Split(line, @"\s+|(?!^)(?=\p{P})|(?<=\p{P})(?!$)");
        foreach (var word in words)
        {
            if (word.Length == 0)
            {
                continue;
            }
            if (ContainsMiddleVowel(word) || word.Length < 3 ||
                word.ToLower().Contains('t'))
                continue;
            filteredResult.Append(word);
            filteredResult.Append(" ");
        }
    }
    
    private bool ContainsMiddleVowel(string input)
    {
        int middleIndex = input.Length / 2;
        StringBuilder middleLetters = new StringBuilder();
        if (input.Length % 2 == 0)
        {
            middleLetters.Append(input[middleIndex-1]);
            middleLetters.Append(input[middleIndex]);
        }
        else
        {
            middleLetters.Append(input[middleIndex]);
        }

        return _vowels.Any(vowel => middleLetters.ToString().ToLower().Contains(vowel));
    }
    
}