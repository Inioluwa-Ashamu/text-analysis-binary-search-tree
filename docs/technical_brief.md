# Technical Brief

## What This Shows

This project demonstrates data-structure implementation, recursion, text tokenisation, and console application design in C#.

## Technical Decisions

- A binary search tree makes ordered traversal part of the index structure.
- `WordInfo` owns frequency and line-number state.
- Recursive search and traversal keep the implementation compact and easy to inspect.
- Regex filtering removes punctuation and keeps word handling deterministic.
- A command-line path argument makes the app usable on arbitrary text files.

## Strongest Evidence

- Full custom implementation of the index structure.
- Frequency counting and line tracking handled during insertion.
- Alphabetical output generated from in-order traversal.
- Small sample included for immediate execution.

## Engineering Direction

- Add unit tests for insertion, lookup, traversal, and line tracking.
- Add a benchmark comparing BST, sorted dictionary, and hash dictionary approaches.
- Add optional export of index results to CSV or JSON.
