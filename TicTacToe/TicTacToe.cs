using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// This class when initialized creates a board game,
    /// The board game has function to play it, or display it's board
    /// </summary>
    class TicTacToe
    {
        private const int BOARDSIZE = 3; // size of the board
        private int[,] board; // board representation

        /// <summary>
        /// Constructor, initializes the attribute board
        /// a 2D array representing the tic-tac-toe board.
        /// </summary>
        public TicTacToe()
        {
            board = new int[BOARDSIZE, BOARDSIZE];
            int num = 1;
            for (int i = 0; i < BOARDSIZE; i++)
            {
                for (int j = 0; j < BOARDSIZE; j++)
                {
                    board[i, j] = num;
                    num++;
                }
            }

        }

        /// <summary>
        /// goes through basic game logic of having the player whose
        ///  turn it is to select, then check if they've won and if they have print statement
        /// </summary>
        public void Play()
        {
            bool KeepGoing = true;
            bool PlayerTurn = true;
            int TieFlag = 0;

            do
            {
                if (TieFlag == BOARDSIZE * BOARDSIZE)
                {
                    break;
                }
                Console.Write("Player 1:X Player 2: O\n");
                if (PlayerTurn) //X's Turn Player 1's chance
                {
                    Console.WriteLine("Player 1's chance");
                    playerSelect(PlayerTurn);
                    KeepGoing = CheckWin();
                    if (!KeepGoing)
                    {
                        Console.WriteLine("Player 1 won");
                    }

                    PlayerTurn = false;
                }
                else //O's Turn Player 2's chance
                {
                    Console.WriteLine("Player 2's chance");
                    playerSelect(PlayerTurn);
                    KeepGoing = CheckWin();
                    if (!KeepGoing)
                    {
                        Console.WriteLine("Player 2 Won");
                    }
                    PlayerTurn = true;
                }

                PrintBoard();
                TieFlag++;
            } while (KeepGoing);
            if (KeepGoing)
            {
                Console.WriteLine("It's a Tie.");
            }
            Console.ReadKey();


        }

        /// <summary>
        /// prints the current state of the board.
        /// </summary>
        /// <remarks>
        /// Is hardcoded to work only in the scope of the assignment
        /// which is BOARDSIZE == 3
        /// </remarks>
        public void PrintBoard()
        {
            Console.WriteLine("   |   |   \n" +
                " {0} | {1} | {2} \n" +
                "___|___|___\n" +
                "   |   |   \n" +
                " {3} | {4} | {5} \n" +
                "___|___|___\n" +
                "   |   |   \n" +
                " {6} | {7} | {8} \n" +
                "   |   |   \n",
                interpret(board[0, 0]), interpret(board[0, 1]), interpret(board[0, 2]),
                interpret(board[1, 0]), interpret(board[1, 1]), interpret(board[1, 2]),
                interpret(board[2, 0]), interpret(board[2, 1]), interpret(board[2, 2]));

        }

        /// <summary>
        /// checks the win state of the board
        /// </summary>
        /// <remarks>
        /// Is hardcoded to work only in the scope of the assignment
        /// which is BOARDSIZE == 3
        /// </remarks>
        /// <returns></returns>
        private bool CheckWin()
        {
            //board[0,0],board[0,1],board[0,2],
            //board[1,0],board[1,1],board[1,2],
            //board[2,0],board[2,1],board[2,2],



            return !(((board[0, 0] == board[0, 1]) && (board[0, 1] == board[0, 2])) || //Horizontal
                    ((board[1, 0] == board[1, 1]) && (board[1, 1] == board[1, 2])) ||
                    ((board[2, 0] == board[2, 1]) && (board[2, 1] == board[2, 2])) ||
                    ((board[0, 0] == board[1, 0]) && (board[1, 0] == board[2, 0])) || //Vertical
                    ((board[0, 1] == board[1, 1]) && (board[1, 1] == board[2, 1])) ||
                    ((board[0, 2] == board[1, 2]) && (board[1, 2] == board[2, 2])) ||
                    ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2])) || //Diagonal
                    ((board[0, 2] == board[1, 1]) && (board[1, 1] == board[2, 0])));
        }

        /// <summary>
        /// Has player select a space in the tic tac toe board
        /// </summary>
        /// <param name="playerTurn"></param>
        private void playerSelect(bool playerTurn)
        {
            bool validPlace = false;
            int place;
            Console.WriteLine("Where would you like to place");
            while (!validPlace)
            {
                place = Convert.ToInt32(Console.ReadLine());
                if(place <= BOARDSIZE * BOARDSIZE)
                {
                    if(board[calcX(place),calcY(place)] > 0)
                    {
                        validPlace = true;
                        if (playerTurn)
                        {
                            board[calcX(place), calcY(place)] = -1;
                            return;
                        }
                        else
                        {
                            board[calcX(place), calcY(place)] = -2;
                            return;
                        }
                    }
                }        
            }
        }

        /// <summary>
        /// Converts the index used for the game into a number usable
        /// as the first index for the 2D array
        /// </summary>
        /// <param name="index"></param>
        /// <returns>
        /// first index of 2D array 
        /// </returns>
        private int calcX(int index)
        {
            return Convert.ToInt32((index - 1) / BOARDSIZE);
        }

        /// <summary>
        /// Converts the index used for the game into a number usable
        /// as the second index for the 2D array
        /// </summary>
        /// <param name="index"></param>
        /// <returns>
        /// second index of 2D array 
        /// </returns>
        private int calcY(int index)
        {
            return (index - 1) % BOARDSIZE;
        }


        /// <summary>
        /// Interprets spaces taken by either X or Y
        /// determined by their respective flags -1 and -2
        /// </summary>
        /// <param name="input"></param>
        /// <returns>"X" for -1 "Y" for -2, an int.toString if anything else</returns>
        private string interpret(int input)
        {
            if(input == -1)
            {
                return "X";
            }
            if(input == -2)
            {
                return "O";
            }
            return input.ToString();
          
        }
    }
}
