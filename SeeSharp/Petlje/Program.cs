using System;

namespace Petlje
{
    class Program
    {
        static void Main(string[] args)
        {
            //do-while
            int uneseniBroj;
            //ovaj primjer garantira da će korisnik unijeti int u varijablu uneseniBroj
            do
            {
                Console.WriteLine("Unesite cijeli broj: ");
            } while (!int.TryParse(Console.ReadLine(), out uneseniBroj));

            //while
            int brojac = 0;
            while(brojac < 10)
            {
                Console.WriteLine("brojac = " + brojac++); //brojac++ može u poseban red, nije bitno
            }

            //u c++ bi bilo int* brojevi = new int[10]; i kasnije bi trebalo delete[] brojevi
            //C# sam briše za nas pa nam ne treba delete[] na kraju
            int[] brojevi = new int[10]; 
            //for
            for (int i = 0; i < brojevi.Length; i++) //Length je varijabla (preciznije - svojstvo (property)) koju svako polje ima i govori koliko to polje ima elemenata
            {
                brojevi[i] = i + 1;
            }

            //foreach
            //za svaki(tip_podatka ime_varijable u skupini_podataka)
            foreach(int broj in brojevi)
            {
                Console.Write(broj + ", ");
            }
            Console.WriteLine();

            //foreach je vrlo praktičan i napredan for (pojednostavljen for jer ne koristi indexe (i))
            //da zapišemo ovaj gore foreach u foru, to bi izgledalo ovako:
            for (int i = 0; i < brojevi.Length; i++) 
            {
                int broj = brojevi[i];

                Console.Write(broj + ", ");
            }
            Console.WriteLine();
        }
    }
}
