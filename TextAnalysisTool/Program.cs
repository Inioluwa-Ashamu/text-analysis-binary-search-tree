using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        WordBinaryTree tree = new WordBinaryTree();
        string filePath = args.Length > 0 ? args[0] : Path.Combine("samples", "sample_text.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File not found: {filePath}");
            Console.WriteLine("Pass a text file path as the first argument, or run from the repository root to use the bundled sample.");
            return;
        }

        // Read and insert words into the tree
        string[] linesInFile = File.ReadAllLines(filePath);
        char[] delimiters = { ' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*', '\t' };
        int lineNumber = 0;

        foreach (string line in linesInFile)
        {
            lineNumber++;
            string[] wordsInLine = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in wordsInLine)
            {
                if (IsWord(word))
                    tree.Insert(word.ToLower(), lineNumber);
            }
        }

        // Interactive menu
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("--- Text Analysis Tool ---");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display total number of unique words");
            Console.WriteLine("2. Display all words in alphabetical order");
            Console.WriteLine("3. Display the longest word");
            Console.WriteLine("4. Display the most frequent word");
            Console.WriteLine("5. Search for a word");
            Console.WriteLine("0. Exit");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("--- Total Unique Words ---\n");
                    Console.WriteLine($"Total number of unique words: {tree.CountUniqueWords()}");
                    Pause();
                    break;

                case "2":
                    Console.WriteLine("--- Words in Alphabetical Order ---\n");
                    tree.DisplayInOrder();
                    Pause();
                    break;

                case "3":
                    Console.WriteLine("--- Longest Word ---\n");
                    WordInfo longest = tree.FindLongestWord();
                    if (longest != null)
                        Console.WriteLine($"Longest word: '{longest.Word}' ({longest.Word.Length} characters), occurred {longest.Frequency} time(s)");
                    else
                        Console.WriteLine("No words found.");
                    Pause();
                    break;

                case "4":
                    Console.WriteLine("--- Most Frequent Word ---\n");
                    WordInfo mostFrequent = tree.FindMostFrequentWord();
                    if (mostFrequent != null)
                        Console.WriteLine($"Most frequent word: '{mostFrequent.Word}' occurred {mostFrequent.Frequency} time(s)");
                    else
                        Console.WriteLine("No words found.");
                    Pause();
                    break;

                case "5":
                    Console.WriteLine("--- Search for a Word ---\n");
                    Console.Write("Enter word to search: ");
                    string searchWord = Console.ReadLine();
                    WordInfo result = tree.Search(searchWord.ToLower());
                    if (result != null)
                        Console.WriteLine($"'{result.Word}' found {result.Frequency} time(s) on lines: {string.Join(", ", result.LineNumbers)}");
                    else
                        Console.WriteLine($"'{searchWord}' not found.");
                    Pause();
                    break;

                case "0":
                    Console.WriteLine("Exiting program...");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Pause();
                    break;
            }
        }
    }

    static bool IsWord(string str)
    {
        return Regex.IsMatch(str, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase);
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to return to the menu...");
        Console.ReadKey();
    }
}
