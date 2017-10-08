using System;

namespace IspisPodataka
{
    class Program
    {
        static void Main(string[] args)
        {
            //Postoje tri načina uređivanja stringova
            
            int br1 = 16, br2 = 28;
            int zbroj = br1 + br2;

            //1) kao u c++ (+ umjesto <<)
            //najlošije radi nepreglednosti, praktično ako samo treba nadodati nešto samo na početak ili kraj
            string ispis1 = "Zbroj brojeva " + br1 + " i " + br2 + " iznosi " + zbroj + ".";

            //2) format s poljima, u vitičastim zagradama brojevi moraju početi od 0 i završiti s
            //brojem varijabli koje želimo ispisati minus 1 ( [0, n - 1] )
            //može uzrokovati pogreške ako se ne poštuje pravilo [0, n - 1] ili se stavi manje od n varijabli
            //odvojenih zarezima nakon stringa
            //(ako se ne ispisuje direktno u konzolu, mora se koristiti string.Format(), u konzoli ne treba
            //navoditi string.Format() nego se može odmah ovo dolje u zagradi staviti u Console.WriteLine())
            string ispis2 = string.Format("Zbroj brojeva {0} i {1} iznosi {2}.", br1, br2, zbroj);

            //3) Direktno ispisujemo u vitičastim zagradama što želimo i ne trebamo koristiti string.Format()
            //izvan Console.WriteLine()a
            //najpraktičnije jer nemre doći do pogrešaka i pregledno je
            string ispis3 = $"Zbroj brojeva {br1} i {br2} iznosi {zbroj}.";

            Console.WriteLine(ispis1);

            Console.WriteLine(ispis2);
            Console.WriteLine("Zbroj brojeva {0} i {1} iznosi {2}.", br1, br2, zbroj);

            Console.WriteLine(ispis3);
        }
    }
}
