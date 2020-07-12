using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        private Random rand;
        private Move[] board;
        private Move playerSign;
        private Move computerSign;

        public Board()
        {
            rand = new Random();
            board = new Move[9];
            CreateBoard();
        }
        public Move GetPlayerSign()
        {
            return playerSign;
        }
        public Move GetComputerSign()
        {
            return computerSign;
        }
        public void CreateBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = Move.none;
            }
        }

        public void PrintBoard()
        {
            int lp = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[lp] == Move.circle)
                        Console.Write(" O |");
                    else if (board[lp] == Move.cross)
                        Console.Write(" X |");
                    else
                        Console.Write("   |");
                    lp++;
                }
                Console.Write("\n");
                Console.Write("- + - + - \n");
            }

            Console.WriteLine();
        }
        public void PrintPositions()
        {
            int lp = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[lp] == Move.circle)
                        Console.Write(" O |");
                    else if (board[lp] == Move.cross)
                        Console.Write(" X |");
                    else
                        Console.Write(" " + lp + " |");
                    lp++;
                }
                Console.Write("\n");
                Console.Write("- + - + - \n");
            }

            Console.WriteLine();
        }

        public void ChoseSignPlayer()
        {
            while (true)
            {
                Console.WriteLine("Wybierz znak X lub O");
                var znakgracza = Console.ReadLine();
                if (znakgracza == "X")
                {
                    playerSign = Move.cross;
                    computerSign = Move.circle;
                    return;
                }
                if (znakgracza == "O")
                {
                    playerSign = Move.circle;
                    computerSign = Move.cross;
                    return;
                }
            }
        }
        public void PlayerMove()
        {
            Console.WriteLine("Runda gracza");
            Console.WriteLine("Wybierz liczbe z tablicy");
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    int index = int.Parse(input);
                    if ( index < 9 && index >= 0 && board[index] == Move.none)
                    {
                        board[index] = playerSign;
                        return;
                    }
                    else
                        Console.WriteLine("Podaj prawidłową liczbe");
                }
                catch
                {
                    Console.WriteLine("Podaj prawidłową liczbe");
                }
            }
        }
        public void ComputerMove()
        {
            Console.WriteLine("Runda Komputera");
            List<int> temp = new List<int>();
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == Move.none)
                    temp.Add(i);
            }

            int index = rand.Next(temp.Count);
            board[temp[index]] = computerSign;
        }

        public bool IsDraw()
        {
            return board.All(sign => sign != Move.none);
        }

        public bool IsWin(Move sign)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == sign && board[i + 3] == sign && board[i + 6] == sign)
                    return true;
            }
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] == sign && board[i + 1] == sign && board[i + 2] == sign)
                    return true;
            }
            if (board[0] == sign && board[4] == sign && board[8] == sign)
                return true;

            if (board[2] == sign && board[4] == sign && board[6] == sign)
                return true;

            return false;
        }

        public bool IsAnyWin()
        {
            return IsWin(playerSign) || IsWin(computerSign);
        }

    }
}
