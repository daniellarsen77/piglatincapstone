using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Pig Latin Translator!");
        char choice;
        do
        {
            Console.Write("\nEnter a line to be translated: ");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = TranslateToPigLatin(words[i]);
            }
            string output = string.Join(" ", words);
            Console.WriteLine(output);
            Console.Write("\nTranslate another line? (y/n): ");
            choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
        } while (char.ToLower(choice) == 'y');
    }

    static bool IsVowel(char ch)
    {
        return "AEIOUaeiou".IndexOf(ch) != -1;
    }

    static int FindFirstVowelIndex(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (IsVowel(word[i]))
            {
                return i;
            }
        }
        return -1;
    }

    static string TranslateToPigLatin(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
        {
            return "";
        }

        word = word.ToLower();

        if (IsVowel(word[0]))
        {
            return word + "way";
        }
        else
        {
            int firstVowelIndex = FindFirstVowelIndex(word);
            if (firstVowelIndex == -1)
            {
                // Special case for words with no vowels
                return word + "ay";
            }
            if (firstVowelIndex > 0 && word[firstVowelIndex] == 'u' && word[firstVowelIndex - 1] == 'q')
            {
                // Special case for 'qu' followed by a vowel
                firstVowelIndex++;
            }
            return word.Substring(firstVowelIndex) + word.Substring(0, firstVowelIndex) + "ay";
        }
    }
}
