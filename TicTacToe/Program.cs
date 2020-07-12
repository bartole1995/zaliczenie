using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Action[] funcs = new Action[2];
            Board board = new Board();
            Console.WriteLine("Welcome to the tic-tac-toe game created by Bartłomiej Frasik");
            board.ChoseSignPlayer();

            if (board.GetPlayerSign() == Move.cross)
            {
                funcs[0] = board.PlayerMove;
                funcs[1] = board.ComputerMove;
            }
            else
            {
                funcs[1] = board.PlayerMove;
                funcs[0] = board.ComputerMove;
            }

            for (int i = 0; i < 9 && !board.IsAnyWin(); i++)
            {
                board.PrintPositions();
                funcs[i % 2]();
            }
            board.PrintBoard();
            if (board.IsDraw())
                Console.WriteLine("Remis");

            if (board.IsWin(board.GetPlayerSign()))
                Console.WriteLine("Wygrał Gracz");
            else
                Console.WriteLine("Wygrał Komputer");

            Console.ReadKey();
        }
    }
}
