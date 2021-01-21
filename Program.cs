using System;
using System.Collections;

namespace TicTacToe_v2
{
    class Program
    {
        static void Main(string[] args)
        {           
            ArrayList tickedValues = new ArrayList();
            string userLetter;
            int welcome = 1;
            do
            {
                tickedValues.Clear();
                string[,] fields = new string[3, 3]
                {
                {"1","2","3"},
                {"4","5","6"},
                {"7","8","9"}
                };

                bool player1Turn = true;

                bool player1Win = false;
                bool player2Win = false;

                int input;

                //useful for a draw
                int moveCounter = 0;

                Console.Clear();
                do
                {
                    ShowBoard(fields);

                    ShowWelcomeMessage(welcome);

                    ShowPlayerInstructions(player1Turn);

                    do
                    {
                        input = DataValidation();
                        if (!tickedValues.Contains(input))
                        {
                            tickedValues.Add(input);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Field already marked. Please enter the other field.");
                        }
                    } while (true);

                    moveCounter++;

                    if (welcome == 1)
                    {
                        welcome = 0;
                    }

                    if (player1Turn)
                    {
                        switch (input)
                        {
                            case 1:
                                fields[0, 0] = "O";
                                break;
                            case 2:
                                fields[0, 1] = "O";
                                break;
                            case 3:
                                fields[0, 2] = "O";
                                break;
                            case 4:
                                fields[1, 0] = "O";
                                break;
                            case 5:
                                fields[1, 1] = "O";
                                break;
                            case 6:
                                fields[1, 2] = "O";
                                break;
                            case 7:
                                fields[2, 0] = "O";
                                break;
                            case 8:
                                fields[2, 1] = "O";
                                break;
                            case 9:
                                fields[2, 2] = "O";
                                break;
                        }
                    }       
                    else
                    {
                        switch (input)
                        {
                            case 1:
                                fields[0, 0] = "X";
                                break;
                            case 2:
                                fields[0, 1] = "X";
                                break;
                            case 3:
                                fields[0, 2] = "X";
                                break;
                            case 4:
                                fields[1, 0] = "X";
                                break;
                            case 5:
                                fields[1, 1] = "X";
                                break;
                            case 6:
                                fields[1, 2] = "X";
                                break;
                            case 7:
                                fields[2, 0] = "X";
                                break;
                            case 8:
                                fields[2, 1] = "X";
                                break;
                            case 9:
                                fields[2, 2] = "X";
                                break;
                        }
                    }               
                    if (player1Turn)
                    {
                        if (DidPlayer1Win(fields))
                        {
                            player1Win = true;
                        }
                        else
                        {
                            player1Turn = false;
                        }
                    }       
                    else
                    {
                        if (DidPlayer2Win(fields))
                        {
                            Console.WriteLine("\n\nWell done player 2! You have won!");
                            player2Win = true;
                        }
                        else
                        {
                            player1Turn = true;
                        }
                    }               
                    Console.Clear();

                    if (player1Win || player2Win)
                    {
                        ShowBoard(fields);
                        if (player1Win)
                        {
                            Console.WriteLine("Well done Player 1! You have won! Would you like to play again?" +
                            "\n'y' for yes" +
                            "\n'n' for no");
                        }
                        else
                        {
                            Console.WriteLine("Well done Player 2! You have won! Would you like to play again?" +
                            "\n'y' for yes" +
                            "\n'n' for no");
                        }
                    }

                    else if (moveCounter == 9)
                    {
                        ShowBoard(fields);
                        Console.WriteLine("Game finished as a draw. Would you like to play again?\n" +
                            "'y' for yes\n" +
                            "'n' for no");
                        player1Win = true;
                    }

                } while (!(player1Win || player2Win));
                do
                {
                    userLetter = Console.ReadLine();
                    if (!(userLetter.Equals("y") || userLetter.Equals("n")))
                    {
                        Console.WriteLine("You have entered wrong value. Please try again.");
                    }
                } while (!(userLetter.Equals("y") || userLetter.Equals("n")));
            } while (userLetter.Equals("y"));
        }

        private static void ShowBoard(string[,] fields)
        {
            Console.WriteLine
                (
                "|-----|-----|-----|\n" +
                "|  {0}  |  {1}  |  {2}  |\n" +
                "|  {3}  |  {4}  |  {5}  |\n" +
                "|  {6}  |  {7}  |  {8}  |\n" +
                "|-----|-----|-----|\n", fields[0,0], fields[0,1], fields[0,2], fields[1,0], fields[1,1], fields[1,2], fields[2,0], fields[2,1], fields[2,2]);
        }
        private static void ShowPlayerInstructions(bool player1)
        {
            if (player1)
            {
                Console.WriteLine("Player 1. Write number from 1 to 9 to mark.");
            }
            else
            {
                Console.WriteLine("Player 2. Write number from 1 to 9 to mark.");
            }
        }
        private static int DataValidation()
        {
            int input;
            bool intChecker;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Please, enter the number!");
                    intChecker = false;
                }
                else
                {
                    if (input > 9 || input < 1)
                    {
                        Console.WriteLine("Number must be between 1 and 9\n");
                        intChecker = false;
                    }
                    else
                    {
                        intChecker = true;
                    }
                }
            } while (!intChecker);
            return input;
        }
        private static bool DidPlayer1Win(string[,] fields)
        {
            if (fields[0,0].Equals("O") && fields[0, 1].Equals("O") && fields[0, 2].Equals("O"))
            {
                return true;
            }
            else if (fields[1, 0].Equals("O") && fields[1, 1].Equals("O") && fields[1, 2].Equals("O"))
            {
                return true;
            }
            else if (fields[2, 0].Equals("O") && fields[2, 1].Equals("O") && fields[2, 2].Equals("O"))
            {
                return true;
            }
            else if (fields[0, 0].Equals("O") && fields[1, 0].Equals("O") && fields[2, 0].Equals("O"))
            {
                return true;
            }
            else if (fields[0, 1].Equals("O") && fields[1, 1].Equals("O") && fields[2, 1].Equals("O"))
            {
                return true;
            }
            else if (fields[0, 2].Equals("O") && fields[1, 2].Equals("O") && fields[2, 2].Equals("O"))
            {
                return true;
            }
            else if (fields[0, 0].Equals("O") && fields[1, 1].Equals("O") && fields[2, 2].Equals("O"))
            {
                return true;
            }
            else if (fields[2, 0].Equals("O") && fields[1, 1].Equals("O") && fields[0, 2].Equals("O"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private static bool DidPlayer2Win(string[,] fields)
        {
            if (fields[0, 0].Equals("X") && fields[0, 1].Equals("X") && fields[0, 2].Equals("X"))
            {
                return true;
            }
            else if (fields[1,0].Equals("X") && fields[1,1].Equals("X") && fields[1,2].Equals("X"))
            {
                return true;
            }
            else if (fields[2,0].Equals("X") && fields[2,1].Equals("X") && fields[2,2].Equals("X"))
            {
                return true;
            }
            else if (fields[0,0].Equals("X") && fields[1,0].Equals("X") && fields[2,0].Equals("X"))
            {
                return true;
            }
            else if (fields[0,1].Equals("X") && fields[1,1].Equals("X") && fields[2,1].Equals("X"))
            {
                return true;
            }
            else if (fields[0,2].Equals("X") && fields[1,2].Equals("X") && fields[2,2].Equals("X"))
            {
                return true;
            }
            else if (fields[0,0].Equals("X") && fields[1,1].Equals("X") && fields[2,2].Equals("X"))
            {
                return true;
            }
            else if (fields[2,0].Equals("X") && fields[1,1].Equals("X") && fields[0,2].Equals("X"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void ShowWelcomeMessage(int moveCounter)
        {
            if (moveCounter == 1)
            {
                Console.WriteLine("Welcome to TicTacToe game!");
            }
        }
    }
}
