# Sudoku Solver

A C# implementation of a Sudoku solver using the **Backtracking Algorithm**. This solver supports both **9x9** and **16x16** Sudoku puzzles.

## Features
- Solves standard **9x9** and extended **16x16** Sudoku puzzles.
- Implements **Backtracking Algorithm** for efficient solving.
- Written in **C#** with a clean and simple structure.

## Installation
1. Clone the repository:
   ```
   git clone https://github.com/MuhammadAbdi42/Sudoku-Solver-With-Backtracking-Algorithm
   ```
2. Open the project in **Visual Studio** or any C# IDE of your choice.
3. Build and run the application.

## Usage
- Provide an input Sudoku puzzle (9x9 or 16x16) with the sudoku editor inside the app.
- The solver will find and display the solution if it exists.

## How It Works
1. The **Backtracking Algorithm** recursively places numbers in empty cells.
2. It ensures that each placed number follows Sudoku rules:
   - Each row must contain unique numbers.
   - Each column must contain unique numbers.
   - Each sub-grid must contain unique numbers.
3. If a number placement is invalid, it backtracks and tries a different number.
4. The process continues until the board is solved.

## Contributing
Feel free to fork the repository, create a new branch, and submit a pull request with improvements or new features.
