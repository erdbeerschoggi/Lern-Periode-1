using System.Diagnostics.Metrics;

namespace KonsolenTicTacToe
{
    internal class Program
    {




        // Spielfeld definieren
        static char[] spielfeld = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        static void Main(string[] args)
        {
            char aktuellerSpieler = 'X';

            ZeichneSpielfeld();

            Console.WriteLine($"Spieler {aktuellerSpieler}, wähle eine Position (1-9): ");
            string eingabe = Console.ReadLine();

            // Überprüfen,ob Eingabe eine Zahl ist
            {
                if (int.TryParse(eingabe, out int position) && position >= 1 && position <= 9)
                {
                    // Überprüfen,ob Position frei ist
                    if (spielfeld[position - 1] != 'X' && spielfeld[position - 1] != 'O')
                    {
                        spielfeld[position - 1] = aktuellerSpieler;
                        
                        Console.Clear();
                        ZeichneSpielfeld();

                        //spielerwechsel
                        aktuellerSpieler = (aktuellerSpieler == 'X') ? 'O' : 'X';
                    }
                    else
                    {
                        Console.WriteLine("Dieses Feld ist schon belegt!");
                    }
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe! Bitte wähle eine Position von 1 bis 9.");
                }
            }
            

            // Spielfeld
            static void ZeichneSpielfeld()
            {
                Console.WriteLine("1 |2 |3 ");
                Console.WriteLine("-------");
                Console.WriteLine("4 |5 |6 ");
                Console.WriteLine("-------");
                Console.WriteLine("7 |8 |9");


            }


        }
    }
}


          





            



        













           

        
    

