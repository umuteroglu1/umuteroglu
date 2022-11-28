using System;

namespace UmutEroglutry2
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameStatus = 0;
            int currentPlayer = -1;
            char[] umutGame = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Console.Title = " You will Lost ";

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            do
            {
                Console.Clear();

                currentPlayer = GetNextPlayer(currentPlayer);

                HeadsUpDisplay(currentPlayer);
                DrawGameboard(umutGame);

                GameEngine(umutGame, currentPlayer);

             
                gameStatus = CheckWinner(umutGame);

            } while (gameStatus.Equals(0));

            Console.Clear();
            HeadsUpDisplay(currentPlayer);
            DrawGameboard(umutGame);


            if (gameStatus.Equals(2))
            {
                Console.WriteLine($"The game is a draw!");
            }
        }

        private static int CheckWinner(char[] umutGame)
        {
            
            if (IsGameWinner(umutGame))
            {
                return 1;
            }

           
            if (IsGameDraw(umutGame))
            {
                return 2;
            }
            
            return 0;
        }

        private static bool IsGameDraw(char[] umutGame)
        {
            return umutGame[0] != '1' &&
                   umutGame[1] != '2' &&
                   umutGame[2] != '3' &&
                   umutGame[3] != '4' &&
                   umutGame[4] != '5' &&
                   umutGame[5] != '6' &&
                   umutGame[6] != '7' &&
                   umutGame[7] != '8' &&
                   umutGame[8] != '9';
        }

        private static bool IsGameWinner(char[] umutGame)
        {
            if (IsumutGameTheSame(umutGame, 0, 1, 2))
            {
                return true;
            }

            if (IsumutGameTheSame(umutGame, 3, 4, 5))
            {
                return true;
            }

            if (IsumutGameTheSame(umutGame, 6, 7, 8))
            {
                return true;
            }

            if (IsumutGameTheSame(umutGame, 0, 3, 6))
            {
                return true;
            }

            if (IsumutGameTheSame(umutGame, 1, 4, 7))
            {
                return true;
            }

            if (IsumutGameTheSame(umutGame, 2, 5, 8))
            {
                return true;
            }

            if (IsumutGameTheSame(umutGame, 0, 4, 8))
            {
                return true;
            }

            if (IsumutGameTheSame(umutGame, 2, 4, 6))
            {
                return true;
            }

            return false;
        }

        private static bool IsumutGameTheSame(char[] testumutGame, int pos1, int pos2, int pos3)
        {
            return testumutGame[pos1].Equals(testumutGame[pos2]) && testumutGame[pos2].Equals(testumutGame[pos3]);
        }

        private static void GameEngine(char[] umutGame, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {
               
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {

                    int.TryParse(userInput, out var gamePlacementMarker);

                    char currentMarker = umutGame[gamePlacementMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select anotyher placement.");
                    }
                    else
                    {
                        umutGame[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);

                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select anotyher placement.");
                }
            } while (notValidMove);
        }

        private static char GetPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }

        static void HeadsUpDisplay(int PlayerNumber)
           
        {
            
            Console.WriteLine("********************************");
            Console.WriteLine("Welcome to the Umut Eroglu Game!");
            Console.WriteLine("********************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            
            Console.WriteLine("********************************");
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();
            Console.WriteLine("********************************");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Player {PlayerNumber} to move, select 1 thorugh 9 from the game board.");
            Console.WriteLine();
        }

        static void DrawGameboard(char[] umutGame)
        {
          

            Console.WriteLine($"         {umutGame[0]} | {umutGame[1]} | {umutGame[2]}        ");
            Console.WriteLine("         ---+---+---                                           ");
            Console.WriteLine($"         {umutGame[3]} | {umutGame[4]} | {umutGame[5]}        ");
            Console.WriteLine("         ---+---+---    ");
            Console.WriteLine($"         {umutGame[6]} | {umutGame[7]} | {umutGame[8]}        ");
            Console.WriteLine("--------------------------------------------");
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }
    }
}
