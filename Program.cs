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

                
                bool validInput = int.TryParse(Console.ReadLine(), out choice);
                if (!validInput || choice < 1 || choice > 9)
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte eine Zahl zwischen 1 und 9 eingeben.");
                    System.Threading.Thread.Sleep(2000);
                    continue;
                }

                // Überprüfen, ob das Feld bereits markiert ist
                if (spielfeld[choice - 1] != 'X' && spielfeld[choice - 1] != 'O')
                {
                    spielfeld[choice - 1] = (player % 2 == 0) ? 'O' : 'X';
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry, das Feld {0} ist bereits mit einem {1} belegt.", choice, spielfeld[choice - 1]);
                    Console.WriteLine("Bitte warte 2 Sekunden, bevor du es erneut versuchst.");
                    System.Threading.Thread.Sleep(2000);
                }

                flag = CheckWin();

            } while (flag != 1 && flag != -1);

            Console.Clear();
            ZeichneSpielfeld();

            if (flag == 1)
            {
                Console.WriteLine("Spieler {0} hat gewonnen!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Es ist ein Unentschieden!");
            }

            Console.ReadLine();
        }

        
        static void ZeichneSpielfeld()
        {
            Console.WriteLine("{0} | {1} | {2}", spielfeld[0], spielfeld[1], spielfeld[2]);
            Console.WriteLine("--+---+--");
            Console.WriteLine("{0} | {1} | {2}", spielfeld[3], spielfeld[4], spielfeld[5]);
            Console.WriteLine("--+---+--");
            Console.WriteLine("{0} | {1} | {2}", spielfeld[6], spielfeld[7], spielfeld[8]);
        }

        
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
                    return 1; 
                }
            }

            // Überprüfen auf ein Unentschieden
            if (spielfeld.All(c => c == 'X' || c == 'O'))
            {
                return -1;
            }

            return 0; 
        }
    }
}






























