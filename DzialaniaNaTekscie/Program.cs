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

    /* Funkcja Text
    Parametr: brak
    Zwracany typ: string
    Opis: Funkcja wczytuje zawartość pliku tekstowego o nazwie text.txt przy pomocy StreamReader i 
    zwraca całą jego zawartość jako jeden ciąg znaków (string). Zawartość pliku jest zbierana do StringBuilder, 
    a następnie konwertowana na zwykły tekst.*/
    static string Text()
    {
        
        StringBuilder sb=new StringBuilder();
        using (StreamReader sr = new StreamReader("text.txt"))
        {
            sb.Append(sr.ReadToEnd());
        }
        
        return sb.ToString();
    }
    
    /*Funkcja HowManyWords
Parametr: text typu string, który przyjmuje tekst, w którym będziemy liczyć słowa.
    Zwracany typ: int
    Opis:Funkcja dzieli tekst na pojedyncze słowa rozdzielając je spacjami i liczy, ile 
    z nich ma długość większą niż 3 znaki. Zwraca liczbę takich słów
    */

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
    
    /*Funkcja Palindrom
Parametr:text typu string, który przyjmuje słowo, które ma być sprawdzone pod kątem bycia palindromem.
    Zwracany typ: bool
    Opis: Funkcja sprawdza, czy dane słowo jest palindromem, 
    czyli czy czytane od przodu jest takie samo jak od tyłu. 
    Funkcja ignoruje wielkość liter, zamieniając tekst na małe litery przed analizą. Zwraca true, jeśli tekst jest palindromem, w przeciwnym razie false.*/

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
    
    /*Funkcja ResultPalindrom
    Parametr:text typu string, który przyjmuje tekst, w którym mają być znalezione palindromy.
    Zwracany typ: brak
    Opis:Funkcja najpierw dzieli tekst na słowa. Następnie tworzy listę słów, które 
    mają więcej niż 3 litery. Dla tych słów sprawdza, czy są palindromami, a następnie wypisuje 
    je na ekranie, łącznie z liczbą palindromów. Jeśli nie znajdzie żadnego palindromu, wypisuje odpowiedni komunikat.*/
    

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
    
    /*Funkcja HowManyVowels
    Parametr:text typu string, który przyjmuje tekst, w którym mają być liczone samogłoski.
    Zwracany typ: int
    Opis:Funkcja liczy samogłoski w danym tekście, uwzględniając polskie 
    samogłoski. Funkcja konwertuje tekst na małe litery,aby ignorować wielkość liter, a następnie zlicza samogłoski.
     Zwraca liczbę samogłoskowych znaków w tekście.*/

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
    
    /*Funkcja PolishSigns
    Parametr:text typu string, który przyjmuje tekst zawierający polskie znaki diakrytyczne.
    Zwracany typ: string
    Opis:Funkcja zamienia polskie znaki. Funkcja przechodzi przez tekst i wykonuje odpowiednie zamiany, zwracając zmodyfikowany tekst. 
    Wykorzystuje StringBuilder do modyfikacji ciągu znaków.*/

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