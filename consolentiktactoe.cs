using System;
using System.Linq;

namespace KonsolenTicTacToe
{
    internal class Program
    {
        // Spielfeld definieren
        static char[] spielfeld = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag = 0;

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                ZeichneSpielfeld();
                Console.WriteLine("\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn (O): ");
                }
                else
                {
                    Console.WriteLine("Player 1's turn (X): ");
                }

                choice = int.Parse(Console.ReadLine());

                if (choice >= 1 && choice <= 9 && spielfeld[choice - 1] != 'X' && spielfeld[choice - 1] != 'O')
                {
                    spielfeld[choice - 1] = (player % 2 == 0) ? 'O' : 'X';
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry, the row {0} is already marked with a {1}.", choice, spielfeld[choice - 1]);
                    Console.WriteLine("Please wait 2 seconds before trying again.");
                    System.Threading.Thread.Sleep(2000);
                }

                flag = CheckWin();

            } while (flag != 1 && flag != -1); 

            Console.Clear();
            ZeichneSpielfeld();

            if (flag == 1)
            {
                Console.WriteLine("Player {0} has won!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

            Console.ReadLine();
        }

        // Spielfeld zeichnen
        static void ZeichneSpielfeld()
        {
            Console.WriteLine(" {0} | {1} | {2} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {3} | {4} | {5} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {6} | {7} | {8} ");
        }

        // Überprüfen auf Gewinn
        static int CheckWin()
        {
            // Gewinnkombinationen
            int[,] winningCombinations = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, // Horizontal
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Vertikal
                {0, 4, 8}, {2, 4, 6}  // Diagonal
            };

            // Überprüfen der Gewinnkombinationen
            for (int i = 0; i < winningCombinations.GetLength(0); i++)
            {
                if (spielfeld[winningCombinations[i, 0]] == spielfeld[winningCombinations[i, 1]] &&
                    spielfeld[winningCombinations[i, 1]] == spielfeld[winningCombinations[i, 2]])
                {
                    return 1; // Ein Spieler hat gewonnen
                }
            }

            // Überprüfen auf ein Unentschieden
            if (spielfeld.All(c => c == 'X' || c == 'O'))
            {
                return -1; // Unentschieden
            }

            return 0; // Spiel geht weiter
        }
    }
}



