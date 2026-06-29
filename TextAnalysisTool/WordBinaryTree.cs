using System;
using System.Collections.Generic;

public class WordBinaryTree
{
    private TreeNode root;

    public void Insert(string word, int lineNumber)
    {
        root = InsertRecursive(root, word, lineNumber);
    }

    private TreeNode InsertRecursive(TreeNode node, string word, int lineNumber)
    {
        if (node == null)
            return new TreeNode(new WordInfo(word, lineNumber));

        int comparison = string.Compare(word, node.Data.Word, StringComparison.OrdinalIgnoreCase);
        if (comparison < 0)
            node.Left = InsertRecursive(node.Left, word, lineNumber);
        else if (comparison > 0)
            node.Right = InsertRecursive(node.Right, word, lineNumber);
        else
            node.Data.AddOccurrence(lineNumber);

        return node;
    }

    public void DisplayInOrder()
    {
        InOrderTraversal(root);
    }

    private void InOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.WriteLine($"{node.Data.Word}: {node.Data.Frequency} [Lines: {string.Join(",", node.Data.LineNumbers)}]");
            InOrderTraversal(node.Right);
        }
    }
    public int CountUniqueWords()
    {
        return CountNodes(root);
    }
    public WordInfo Search(string word)
    {
        return SearchRecursive(root, word.ToLower());
    }

    private WordInfo SearchRecursive(TreeNode node, string word)
    {
        if (node == null)
            return null;

        int comparison = string.Compare(word, node.Data.Word, StringComparison.OrdinalIgnoreCase);

        if (comparison == 0)
            return node.Data;
        else if (comparison < 0)
            return SearchRecursive(node.Left, word);
        else
            return SearchRecursive(node.Right, word);
    }


    private int CountNodes(TreeNode node)
    {
        if (node == null)
            return 0;
        return 1 + CountNodes(node.Left) + CountNodes(node.Right);
    }
    public WordInfo FindLongestWord()
    {
        return FindLongestWordRecursive(root, null);
    }

    private WordInfo FindLongestWordRecursive(TreeNode node, WordInfo currentLongest)
    {
        if (node == null)
            return currentLongest;

        if (currentLongest == null || node.Data.Word.Length > currentLongest.Word.Length)
            currentLongest = node.Data;

        currentLongest = FindLongestWordRecursive(node.Left, currentLongest);
        currentLongest = FindLongestWordRecursive(node.Right, currentLongest);

        return currentLongest;
    }
    public WordInfo FindMostFrequentWord()
    {
        return FindMostFrequentWordRecursive(root, null);
    }

    private WordInfo FindMostFrequentWordRecursive(TreeNode node, WordInfo currentMostFrequent)
    {
        if (node == null)
            return currentMostFrequent;

        if (currentMostFrequent == null || node.Data.Frequency > currentMostFrequent.Frequency)
            currentMostFrequent = node.Data;

        currentMostFrequent = FindMostFrequentWordRecursive(node.Left, currentMostFrequent);
        currentMostFrequent = FindMostFrequentWordRecursive(node.Right, currentMostFrequent);

        return currentMostFrequent;
    }



}

