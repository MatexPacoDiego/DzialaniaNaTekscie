using System.Text;

namespace DzialaniaNaTekscie;

class Program
{
    static void Main(string[] args)
    {
        string text = Text();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Podstawowy tekst: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(text);
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("Ilość słów: "+HowManyWords(text));
        ResultPalindrom(text);
        Console.WriteLine("Ilość samogłosek: "+HowManyVowels(text));
        Console.WriteLine("Tekst bez polskich znaków: ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(PolishSigns(text));
    }

    static string Text()
    {
        
        StringBuilder sb=new StringBuilder();
        using (StreamReader sr = new StreamReader("text.txt"))
        {
            sb.Append(sr.ReadToEnd());
        }
        
        return sb.ToString();
    }

    static int HowManyWords(string text)
    {
        string[] words = text.Split(' ');
        int meter = 0;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 3)
            {
                meter++;
            }
        }
        
        return meter;
    }

    static bool Palindrom(string text)
    
    {
        
        string word = text.ToLower();
        for (int i = 0; i < word.Length / 2; i++)
        {
            if (word[i] != word[word.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    static void ResultPalindrom(string text)
    {
        string[] words = text.Split(' ');
        List<string> wordsPalindrom = new List<string>();
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 3)
            {
                wordsPalindrom.Add(words[i]);
            }
        }
        List<string> palindrom=new List<string>();

        foreach (string word in wordsPalindrom.ToArray())
        {
            if (Palindrom(word))
            {
                palindrom.Add(word);
                
            }
        }

        if (palindrom.Count > 0)
        {
            Console.WriteLine("Liczba palindromów: "+palindrom.Count);
            Console.WriteLine("Palindromy: ");
            for (int i = 0; i < palindrom.Count; i++)
            {
                Console.WriteLine(palindrom[i]);
            }
        }
        else
        {
            Console.WriteLine("Brak palindromów");
        }

        
    }

    static int HowManyVowels(string text)
    {
        char[] vowels = { 'a', 'ą', 'e', 'ę', 'i', 'o', 'ó', 'u', 'y' };
        int meter = 0;
        string mainText=text.ToLower();
        for (int i = 0; i < mainText.Length; i++)
        {
            for (int j = 0; j < vowels.Length; j++)
            {
                if (mainText[i] == vowels[j])
                {
                    meter++;
                }
            }
        }

        return meter;
    }

    static string PolishSigns(string text)
    {
        char[] polishSigns = { 'ą', 'ć', 'ę', 'ł', 'ń', 'ó', 'ś', 'ź', 'ż' };
        char[] signs = { 'a', 'c', 'e', 'l', 'n', 'o', 's', 'z', 'z' };
        StringBuilder mainText=new StringBuilder(text.ToLower());
        for (int i = 0; i < mainText.Length; i++)
        {
            for (int j = 0; j < polishSigns.Length; j++)
            {
                if (mainText[i] == polishSigns[j])
                {
                    mainText.Replace(polishSigns[j], signs[j]);
                }
            }
        }
        
        return mainText.ToString();
        
    }


}