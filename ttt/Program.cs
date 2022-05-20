namespace ttt
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {

        public void main(string[] args)
        {
            string player = nextPlayer("");
            var board = createBoard();
            while (!(hasWinner(board) || isADraw(board)))
            {
                displayBoard(board);
                makeMove(player, board);
                player = nextPlayer(player);
            }
            displayBoard(board);
            Console.WriteLine("Good game. Thanks for playing!");
        }

        public object createBoard()
        {
            List<object> board = new List<object>();
            foreach (int square in Enumerable.Range(0, 9))
            {
                board.Add(square + 1);
            }
            return board;
        }

        public void displayBoard(object board)
        {
            Console.WriteLine();
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine($"-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
            Console.WriteLine();
        }

        public static object isADraw(object board)
        {
            foreach (var square in Enumerable.Range(0, 9))
            {
                if (board[square] != "x" && board[square] != "o")
                {
                    return false;
                }
            }
            return true;
        }

        public void hasWinner(object board)
        {
            return (board[0] == board[1] == board[2] || board[3] == board[4] == board[5] || board[6] == board[7] == board[8] || board[0] == board[3] == board[6] || board[1] == board[4] == board[7] || board[2] == board[5] == board[8] || board[0] == board[4] == board[8] || board[2] == board[4] == board[6]);
        }

        public static void makeMove(object player, object board)
        {
            Console.WriteLine($"{player}'s turn to choose a square (1-9): ");
            var square = Convert.ToInt32(Console.ReadLine());
            board[square - 1] = player;
        }

        public static string nextPlayer(string current)
        {
            if (current == "" || current == "o")
            {
                return "x";
            }
            else if (current == "x")
            {
                return "o";
            }
            else
            {
                return "Not a valid input!";
            }
        }

    }
}