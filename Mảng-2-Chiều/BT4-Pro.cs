using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKII_KTLT2
{
    class BT4_Pro
    {
        static string currentPlayer = "o";
        static int currentRow = 0;
        static int currentColumn = 0;

        static string[,] board = new string[3, 3]
        {
            {"-", "-", "-" },
            {"-", "-", "-" },
            {"-", "-", "-" },
        };

        static void printBoard()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Mời " + currentPlayer.ToUpper() + " chọn nước đi!!!\n");
            Console.ResetColor();

            for (int i = 0; i < 3; i++)
            {
                //in ra các cột
                for (int j = 0; j < 3; j++)
                {
                    //in ra cột
                    if (i == currentRow && j == currentColumn)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(board[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(board[i, j] + " ");
                    }

                }

                //Ngắt dòng
                Console.WriteLine();
            }
        }

        //thắng = 2 hòa = 1 không có gì = 0
        static int checkWin(string player)
        {
            int result = 0;
            //dòng
            if (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player)
            {
                result = 2;
            }

            if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player)
            {
                result = 2;
            }

            if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player)
            {
                result = 2;
            }
            //dòng

            //cột
            if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player)
            {
                result = 2;
            }

            if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player)
            {
                result = 2;
            }

            if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player)
            {
                result = 2;
            }

            //chéo
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                result = 2;
            }

            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                result = 2;
            }

            //Hòa

            //Nếu như result = 0 và đã hết nước đi thì hòa
            if (result == 0 && getRemainStep() == 0)
            {
                return 1;
            }


            return result;
        }

        static int getRemainStep()
        {
            int count = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == "-")
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Reset các state về mặc định
        /// </summary>
        static void reset()
        {
            currentRow = 0;
            currentColumn = 0;
            board = new string[3, 3]
            {
                {"-", "-", "-" },
                {"-", "-", "-" },
                {"-", "-", "-" },
            };
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool flag = true;

            while (flag)
            {
                //Chọn x và o để đi trước
                bool continute = false;
                do
                {
                    Console.WriteLine("Ai là người đi trước?");
                    Console.WriteLine("1. O");
                    Console.WriteLine("2. X");

                    string strChoise = Console.ReadLine();

                    if (strChoise.Trim().Equals("1"))
                    {
                        currentPlayer = "o";
                    }
                    else if (strChoise.Trim().Equals("2"))
                    {
                        currentPlayer = "x";
                    }
                    else
                    {
                        Console.WriteLine("Lựa chọn của bạn không hợp lệ! Vui lòng chọn lại.");
                        continute = true;
                    }
                } while (continute);

                reset();

                while (true)
                {
                    Console.Clear();
                    printBoard();

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        currentColumn++;
                        currentColumn = (currentColumn >= 3) ? 0 : currentColumn;
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        currentColumn--;
                        currentColumn = (currentColumn < 0) ? 2 : currentColumn;
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        currentRow--;
                        currentRow = (currentRow < 0) ? 2 : currentRow;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        currentRow++;
                        currentRow = (currentRow >= 3) ? 0 : currentRow;
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        string value = board[currentRow, currentColumn];
                        if (value == "-")
                        {
                            board[currentRow, currentColumn] = currentPlayer;

                            int result = checkWin(currentPlayer);

                            if (result == 2)
                            {
                                Console.Clear();
                                printBoard();
                                Console.WriteLine(currentPlayer + " thắng!");
                            }
                            else if (result == 1)
                            {
                                Console.Clear();
                                printBoard();
                                Console.WriteLine("Hòa");
                            }
                            else
                            {
                                currentPlayer = (currentPlayer == "o") ? "x" : "o";
                                continue;
                            }

                            Console.WriteLine("Bạn có muốn tiếp tục chơi nữa không?");
                            Console.WriteLine("1. Có");
                            Console.WriteLine("2. Không");
                            string strChoiseContinute = Console.ReadLine();
                            if (strChoiseContinute.Equals("2"))
                            {
                                flag = false;
                            }
                            else
                            {
                                Console.Clear();
                            }
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ô đánh phải là ô trống");
                            Console.ResetColor();
                            Task.Delay(2000).Wait();
                        }
                    }
                }
            }
        }
    }
}
