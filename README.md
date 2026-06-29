# Text Analysis Binary Search Tree

C# console application demonstrating algorithms and data-structure fundamentals through text indexing.

## Overview

The app reads a text file, tokenises words, stores unique terms in a binary search tree, and provides an interactive menu for exploring the indexed text.

## Features

- Count unique words.
- Display words in alphabetical order.
- Find the longest word.
- Find the most frequent word.
- Search for a word and list occurrence lines.

## Methods

- Binary search tree insertion and lookup.
- Recursive in-order traversal.
- Recursive max-frequency and max-length search.
- Regex-based word filtering.
- Line-number tracking for indexed terms.

## Repository Structure

```text
.
├── TextAnalysisTool.sln
├── TextAnalysisTool/
│   ├── Program.cs
│   ├── TextAnalysisTool.csproj
│   ├── TreeNode.cs
│   ├── WordBinaryTree.cs
│   └── WordInfo.cs
├── docs/
│   └── portfolio_notes.md
└── README.md
```

## How to Run

Install .NET 8, then run the bundled sample:

```bash
dotnet run --project TextAnalysisTool/TextAnalysisTool.csproj
```

Or pass a custom text file:

```bash
dotnet run --project TextAnalysisTool/TextAnalysisTool.csproj -- path/to/file.txt
```

## Portfolio Value

This is a compact algorithms repo. It is useful for showing software fundamentals alongside AI/ML projects, especially for junior AI engineering roles where general coding ability still matters.

## Limitations

- The tree is not self-balancing, so worst-case lookup/insertion can degrade to linear time.
- The console interface is intentionally simple and designed for demonstration.
