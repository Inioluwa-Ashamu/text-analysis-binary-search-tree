using System.Collections.Generic;

public class WordInfo
{
    public string Word { get; set; }
    public int Frequency { get; set; }
    public List<int> LineNumbers { get; set; }

    public WordInfo(string word, int lineNumber)
    {
        Word = word;
        Frequency = 1;
        LineNumbers = new List<int> { lineNumber };
    }

    public void AddOccurrence(int lineNumber)
    {
        Frequency++;
        LineNumbers.Add(lineNumber);
    }
}
