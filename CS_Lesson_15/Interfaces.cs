using System;
using System.Collections.Generic;
using System.Linq;

// Интерфейс для игровой доски
public interface IBoard
{
    void Initialize();
    void Draw();
    bool IsGameOver(out string winner);
    bool IsValidMove(int row, int col);
    void MakeMove(int row, int col, char symbol);
}

// Класс для игровой доски
public class Board : IBoard
{
    private char[,] board;
    private int movesCount;

    public Board()
    {
        board = new char[3, 3];
    }

    public void Initialize()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
            }
        }

        movesCount = 0;
    }

    public void Draw()
    {
        Console.WriteLine("  0 1 2");
        for (int row = 0; row < 3; row++)
        {
            Console.Write(row + " ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    public bool IsGameOver(out string winner)
    {
        winner = null;

        // Проверка строк
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2] && board[row, 0] != ' ')
            {
                winner = board[row, 0].ToString();
                return true;
            }
        }

        // Проверка столбцов
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] == board[1, col] && board[1, col] == board[2, col] && board[0, col] != ' ')
            {
                winner = board[0, col].ToString();
                return true;
            }
        }

        // Проверка диагоналей
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != ' ')
        {
            winner = board[0, 0].ToString();
            return true;
        }

        if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[2, 0] != ' ')
        {
            winner = board[2, 0].ToString();
            return true;
        }

        // Проверка на ничью
        if (movesCount == 9)
        {
            winner = "Ничья";
            return true;
        }

        return false;
    }

    public bool IsValidMove(int row, int col)
    {
        if (row < 0 || row >= 3 || col < 0 || col >= 3)
        {
            return false;
        }

        if (board[row, col] != ' ')
        {
            return false;
        }

        return true;
    }

    public void MakeMove(int row, int col, char symbol)
    {
        board[row, col] = symbol;
        movesCount++;
    }
}

// Класс для игрока
public class Player
{
    public string Name { get; set; }
    public char Symbol { get; set; }

    public void MakeMove(IBoard board)
    {
        Console.WriteLine($"{Name}, введите номер строки и столбца (через пробел):");
        string[] input = Console.ReadLine().Split(' ');
        int row = int.Parse(input[0]);
        int col = int.Parse(input[1]);

        if (board.IsValidMove(row, col))
        {
            board.MakeMove(row, col, Symbol);
        }
        else
        {
            Console.WriteLine("Некорректный ход. Попробуйте еще раз.");
            MakeMove(board);
        }
    }
}

// Класс для игры
public class Game
{
    private IBoard board;
    private Player player1;
    private Player player2;

    public Game()
    {
        board = new Board();
        player1 = new Player { Name = "Игрок 1", Symbol = 'X' };
        player2 = new Player { Name = "Игрок 2", Symbol = 'O' };
    }

    public void Start()
    {
        board.Initialize();

        Player currentPlayer = player1;
        string winner = null;

        while (!board.IsGameOver(out winner))
        {
            Console.Clear();
            board.Draw();
            currentPlayer.MakeMove(board);

            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }

        Console.Clear();
        board.Draw();
        Console.WriteLine("Игра окончена!");
        Console.WriteLine((winner != null) ? $"Победитель: {winner}" : "Ничья");
    }
}

// Главный класс программы
class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}