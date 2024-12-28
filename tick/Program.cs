using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tick
{
    internal class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag;
        /// <summary>
        /// Draws the gameboard
        /// </summary>
        static void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");
        }

        /// <summary>
        /// Check if the games is win or not
        /// </summary>
        /// <returns></returns>
        static int CheckWin()
        {
            if (spaces[0] == spaces[1] &&
               spaces[1] == spaces[2] || //row1
               spaces[3] == spaces[4] &&
               spaces[4] == spaces[5] || //row2
               spaces[6] == spaces[7] &&
               spaces[7] == spaces[8] || //row3
               spaces[0] == spaces[3] &&
               spaces[3] == spaces[6] || //column1
               spaces[1] == spaces[4] &&
               spaces[4] == spaces[7] || //column2
               spaces[2] == spaces[5] &&
               spaces[5] == spaces[8] || //column3
               spaces[0] == spaces[4] &&
               spaces[4] == spaces[8] || //diagonal1
               spaces[2] == spaces[4] &&
               spaces[4] == spaces[6] //diagonal2
               )
            {
                return 1;
            }
            else if (spaces[0] == '1' &&
                    spaces[1] == '2' &&
                    spaces[2] == '3' &&
                    spaces[3] == '4' &&
                    spaces[4] == '5' &&
                    spaces[5] == '6' &&
                    spaces[6] == '7' &&
                    spaces[7] == '8' &&
                    spaces[8] == '9'
                    )
            {
                return -1;
            }
            else if ((spaces[0] == 'X' || spaces[0] == 'O') &&
                     (spaces[1] == 'X' || spaces[1] == 'O') &&
                     (spaces[2] == 'X' || spaces[2] == 'O') &&
                     (spaces[3] == 'X' || spaces[3] == 'O') &&
                     (spaces[4] == 'X' || spaces[4] == 'O') &&
                     (spaces[5] == 'X' || spaces[5] == 'O') &&
                     (spaces[6] == 'X' || spaces[6] == 'O') &&
                     (spaces[7] == 'X' || spaces[7] == 'O') &&
                     (spaces[8] == 'X' || spaces[8] == 'O'))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// This will draw the X in the board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawX(int pos)
        {
            spaces[pos] = 'X';
        }

        /// <summary>
        /// This will draw the O in the board
        /// </summary>
        /// <param name="pos"></param>
        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 : X and Player 2 : O " + "\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }

                Console.WriteLine("\n");
                DrawBoard();
                choice = int.Parse(Console.ReadLine()) - 1;

                if (spaces[choice] != 'X' &&
                   spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry the row{0} is already marked with {1} \n ", choice, spaces[choice]);
                    Console.WriteLine("please wait for 2 seconds board is loading again");
                    Thread.Sleep(2000);

                }
                flag = CheckWin();
            } while (flag != 1 && flag != -1 && flag !=2);

            Console.Clear();
            DrawBoard();


            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else if (flag == 2)
            {
                Console.WriteLine("Tie Game");
            }
            else
            {
                Console.WriteLine(flag);
            }
        }
    }
}
