using System;

namespace Vjezbe_3_4
{
    class Program
    {

        /*
         * Ovdje sam dosta koristio svojstva (Properties), vrlo skraćen način korištenja varijabli
         * To su varijable koje pripadaju nekoj klasi, vrlo lagano se može definirati tko može čitati varijablu,
         * tko može, a tko ne može smjestiti novu vrijednost u nju (enkapsulacijom)
         * ovako bi radili u c++u
         *  private int broj;
            public int getBroj()
            {
                return broj;
            }
            public void setBroj(int noviBroj)
            {
                broj = noviBroj;
            }

            dakle, moram 2 funkcije napisati da dozvolim pristup broju, evo sad kako se rade Property-ji u C#-u

            napiše se prop i stisne se 2 put tab, dakle
            prop[TAB][TAB]

            izađe public int MyProperty { get; set; }

            time sam napravio ono što sam gore s jednom varijablom i dvije funkcije, samo trebam ime staviti u Broj
            (veliko b jer je praksa u C#-u velika početna slova public varijablama, a mala početna private varijablama)

            Netko bi sad rekao, pa zašto ne bi samo napravio public varijablu bez get i set? Stvar je u tome da se može
            kontrolirati tko može tu varijablu koristiti tako da pored get; ili pored set; (s lijeve strane) stavimo
            private (po defaultu su public na ovom primjeru iznad).           
         * Dakle ako želim da netko može samo čitati tu varijablu izvan klase,
         *  napravio bi public int MyProperty { get; private set; }, ili ako želim da se samo može postaviti vrijednost
         *  (vrlo rijetka upotreba), bilo bi public int MyProperty { private get; set; } 
         */

        /*
         * Osim toga, koristio sam fleksibilnost u C#u što svaka klasa koju napravimo ima ToString() metodu/funkciju
         * iako je nikad nismo definirali. Po defaultu, da je pozovemo, ispisala bi neke gluposti, npr. za Window
         * bi bilo Vjezbe_3_4.Window ili tako nešto, no mi to možemo promijeniti. Tu funkciju mijenjamo tako da
         * "pregazimo" originalnu, s ključnom riječi override, ako ja u klasi napišem override, bit će mi ponuđene
         * funkcije koje mogu "pregaziti" u IntelliSenseu, pregaziti ToString() je vrlo korisno kad trebamo ispisati
         * informacije o objektu. * Kad odaberemo u IntelliSensu da želimo override-ati funkciju ToString() i stisnemo 
         * enter, on će generirati kod koji vraća neki string. Za svaku klasu možemo vratiti drugačiji string, npr. za 
         * klasu Fraction (razlomak) želim da mi ispiše brojnik/razlomak kad god pozovim .ToString() na objektu koji je
         * instanca te klase. To radim tako da u funkciji ToString() u klasi Fraction jednostavno napišem 
         * return $"{Brojnik}/{Nazivnik}"; ako se varijable zovu Brojnik i Nazivnik (mi ćemo sve pisati na engleskom)
         */

        static void Main(string[] args)
        {
            TestWindow(); //Zadatak 1

            Console.WriteLine();

            TestStudent(); //Zadatak 2 a) - d)

            Console.WriteLine();

            TestFraction(); //Zadatak 2 e)
        }

        private static void TestFraction() //Zadatak 2 e)
        {
            Fraction fraction1 = new Fraction();
            Fraction fraction2 = new Fraction();

            //kada napišem $"{fraction1}", on zna da želim pozvati funkciju .ToString(), pa ne moram pisati
            //$"fraction1.ToString()"
            Console.WriteLine($"{fraction1} + {fraction2} = {fraction1.Add(fraction2)}");
            Console.WriteLine($"{fraction1} - {fraction2} = {fraction1.Subtract(fraction2)}");
            Console.WriteLine($"{fraction1} * {fraction2} = {fraction1.Multiply(fraction2)}");
            Console.WriteLine($"{fraction1} / {fraction2} = {fraction1.Divide(fraction2)}");
        }

        private static void TestStudent() //Zadatak 2 a) - d)
        {
            Student student1 = new Student();
            Student student2 = new Student("Petar Krešimir", "IV");

            student1.UniversityYear = 2;
            student1.Average = 2.34;

            student2.UniversityYear = 4;
            student2.Average = 4.32;

            student1.PrintInfo();
            student2.PrintInfo();
        }

        private static void TestWindow() //Zadatak 1
        {
            Window window1 = new Window();
            Window window2 = new Window("Window 2");

            window1.Active = true;
            window1.Label = "useless";

            Console.WriteLine(window1); //automatski se poziva ToString() metoda/funkcija objekta klase Window
            window1.PrintDimensions();
            window1.Draw('+', '.', 20, 10);

            Console.WriteLine();

            window2.UpperLeftCorner = new Point(50, 100);
            window2.LowerRightCorner = new Point(350, 200);
            window2.Label = "hornpub.com";

            Console.WriteLine(window2.ToString()); //pozvana funkcija, nepotrebno
            window2.PrintDimensions();
            window2.Draw('#', ' ', 35, 20);
        }
    }
}
