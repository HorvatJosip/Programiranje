using System;

namespace UnosPodataka
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Unesite neki podatak: ");
            string unos = Console.ReadLine();

            int cijeliBroj;
            double realniBroj;

            //Testiramo što je uneseno pomoću TryParse metoda iz raznih
            //tipova podataka(int, double, decimal, char, bool, ...), ovisno o tome što nam treba
            
            //1) Unesen je cijeli broj?
            if (int.TryParse(unos, out cijeliBroj))
            {
                Console.WriteLine("Unijeli ste cijeli broj " + cijeliBroj);
            }
            //2) Unesen je realni broj?
            else if(double.TryParse(unos, out realniBroj))
            {
                //Ponekad će krivo ispisati na unos '.' ili ',' ovisno o regiji i načinu pisanja
                //npr. 23.3 će ispisati kao 233, a 23,3 kao 23,3 iako oba smatra realnim brojevima
                Console.WriteLine("Unijeli ste realni broj " + realniBroj);
            }
            //3) Nije broj, možemo dalje pitati bool.TryParse itd., ali obično nema potrebe
            else
            {
                Console.WriteLine("Unijeli ste niz znakova " + unos);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Morat ćemo se pobrinuti da korisnik unese ono što od njega zahtjevamo
            //time dolazi do potrebe izrade funkcije koja to radi za nas
            int pogresnihUnosa; //tek tako da se objasni kako radi ključna riječ out
            int broj = ForsirajUnosCijelogBroja(out pogresnihUnosa);
            Console.WriteLine($"Unijeli ste {broj} nakon {pogresnihUnosa} pogrešnih unosa.");
        }

        private static int ForsirajUnosCijelogBroja(out int pogresnihUnosa)//u c++ bi bilo (int& pogresnihUnosa)
        {
            int broj, brojacKrivihUnosa = 0;

            while (true) //beskonačna petlja
            {
                Console.Write("Unesite neki cijeli broj: ");
                string unos = Console.ReadLine();

                if(int.TryParse(unos, out broj)) //ako je uneseni broj uspješno pretvoren u int, vrati ga
                {
                    //ovo je "drugi return", postavljam referenciranu varijablu na iznos brojača
                    //da je ne postavim na neku vrijednost, program se ne bi mogao izvršiti 
                    //jer je obavezno prije izlaza iz funkcije dati vrijednost varijablama s ključnom riječi out
                    pogresnihUnosa = brojacKrivihUnosa; 

                    return broj; //ovime se prekida while petlja i vraća se vrijednost pozivatelju funkcije (metode)
                    //(drugi način da se beskonačna petlja prekine je sa break;)
                }
                else
                {
                    brojacKrivihUnosa++; //nije uspjela pretvorba, dakle imamo krivo uneseni podatak
                    //Console.Clear(); //u c++-u system("cls"); u cmd-u (komandnoj liniji) cls (skraćeno od clear screen)
                }
            }
        }
    }
}
