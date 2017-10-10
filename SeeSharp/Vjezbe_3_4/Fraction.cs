using System;

namespace Vjezbe_3_4
{
    class Fraction
    {
        public int Numerator { get; private set; } //brojnik
        public int Denominator { get; private set; } //nazivnik

        //bool varijable da znamo treba li stavljati minus u ispisu i da se može primijeniti algoritam koji radi
        //samo s pozitivnim brojevima (jer se koriste brojevi kao ograničenje u foru koji ne ide u negativne brojeve)
        //ovo i algoritam nisu navedeni u zadatku, ovo je čisto za praksanje još nekog algoritma, što više prakse,
        //to će sve ići lakše kasnije
        private bool numeratorNegative = false;
        private bool denominatorNegative = false;

        public Fraction() //ako nije inicijaliziran razlomak, prvo ga učitaj od korisnika
        {
            Load();
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            ProcessNumbers(); //skrati brojeve ako je potrebno
        }

        private void Load()
        {
            while (true)
            {
                Console.Write("Unesite razlomak u obliku brojnik/nazivnik (npr. 8/9): ");

                string input = Console.ReadLine();

                if (input.Contains("/"))
                {
                    int slashIndex = input.IndexOf('/'); // '/' nam je sredina, znamo da su brojevi lijevo i desno
                    string first = input.Remove(slashIndex).Trim(); //maknemo sve od slasha nadalje
                    string second = input.Remove(0, slashIndex + 1).Trim(); //maknemo sve od početka do slasha (i slash)
                    //Trim() uklanja whitespace (poput razmaka, to omogućava da upis bude "    2    /   3   ")

                    int numerator, denominator; //sad testiramo jesu li oba stringa zapravo brojevi
                    if (int.TryParse(first, out numerator) &&
                        int.TryParse(second, out denominator))
                    {
                        if (denominator != 0) //ne smije se dijeliti s 0
                        {
                            //svi uvjeti su zadovoljeni, imamo oba broja i nazivnik nije 0
                            Numerator = numerator;
                            Denominator = denominator;

                            ProcessNumbers(); //skrati brojeve ako je potrebno

                            Console.WriteLine();
                            Console.WriteLine($"Uspješno unesen razlomak ({ToString()})"); //ovdje se može reći this.ToString(), ali Visual Studiju se ne sviđa kad pišemo višak
                            Console.WriteLine();

                            return; //izađi iz petlje, može i break; pa će se funkcija sama vratiti
                        }
                    }
                }
            }
        }

        #region Basic Operations

        //Ovo je najbolje rješiti crtanjem na papiru

        public Fraction Multiply(Fraction other) //Množi trenutni s proslijeđenim i vraća novi kao rezultat
        {
            return new Fraction(
                Numerator * other.Numerator,
                Denominator * other.Denominator
            );
        }

        public Fraction Divide(Fraction other) //Dijeli (dijeljenje je kao množenje drugog recipročnog)
        {
            if (other.Numerator == 0)
            {
                Console.WriteLine("Ne smije se dijeliti s 0!");
                return null; //null znači da objekt nema referencu (ne pokazuje nikamo, nije inicijaliziran), to je defaultna vrijednost bilo kojeg novog objekta kojeg ne inicijaliziramo sa ključnom riječi new
            }

            return new Fraction(
                Numerator * other.Denominator,
                Denominator * other.Numerator
            );
        }

        public Fraction Add(Fraction other) //Zbraja
        {
            if (Denominator == other.Denominator) //zajednički nazivnik
            {
                return new Fraction(
                    Numerator + other.Numerator,
                    Denominator
                );
            }
            else //svodi na zajednički nazivnik
            {
                return new Fraction(
                    (Numerator * other.Denominator) + (other.Numerator * Denominator),
                    Denominator * other.Denominator
                );
            }
        }

        public Fraction Subtract(Fraction other) //Oduzima
        {
            if (Denominator == other.Denominator) //zajednički nazivnik
            {
                return new Fraction(
                    Numerator - other.Numerator,
                    Denominator
                );
            }
            else //svodi na zajednički nazivnik
            {
                return new Fraction(
                    (Numerator * other.Denominator) - (other.Numerator * Denominator),
                    Denominator * other.Denominator
                );
            }
        }

        #endregion

        private void ProcessNumbers()
        {
            //gleda koji su negativni a koji pozitivni i olakšava posao optimizacije 
            //(omogućuje rad sa Math.Min a da ne izađe iz for petlje)
            if (Numerator < 0)
            {
                numeratorNegative = true;
                Numerator = -Numerator;
            }

            if (Denominator < 0)
            {
                denominatorNegative = true;
                Denominator = -Denominator;
            }

            Optimize(); //skraćuje razlomak

            //vraćamo vrijednosti natrag u početno stanje
            if (denominatorNegative) Denominator = -Denominator;
            if (numeratorNegative) Numerator = -Numerator;
        }

        private void Optimize() //izvršava se sve dok postoje brojevi dijeljivi i s brojnikom i nazivnikom (nisam siguran može li se ovo napraviti s petljom (i bi li bilo jednostavnije))
        {
            for (int i = 2; i <= Math.Min(Numerator, Denominator); i++)
            {
                if (Numerator % i == 0 && Denominator % i == 0)
                {
                    Numerator /= i;
                    Denominator /= i;

                    //s obzirom da odavde radimo s novim brojevima, treba proći na isti način kroz nove brojeve
                    //ova rekurzija će završiti čim ne bude više brojeva s kojim su i brojnik i nazivnik dijeljivi
                    //jer se više neće rekurzivno pozivati funkcija
                    Optimize(); 
                }
            }
        }

        public override string ToString() //ovo je super-duper-ultra fancy napravljeno, nikako nije potrebno ovakve finese pokušavat, to ak se ima viška vremena pa da se probavaju sve kombinacije.....
        {

            bool resultNegative = (!numeratorNegative &&  denominatorNegative) ||
                                  ( numeratorNegative && !denominatorNegative);

            string minus = resultNegative ? "-" : "";

            //sa gornjim upitom testiramo jesu li negativni rezultati i ako jesu dodajemo,
            //tako da možemo ostale samo zapisati kao pozitivne (apsolutne -> |-3| == |3| == 3)
            int absNumerator = Math.Abs(Numerator);
            int absDenominator = Math.Abs(Denominator);
            
            if      (Numerator == 0)                    return "0";
            else if (absDenominator == 1)               return $"{minus}{absNumerator}";
            else if (absNumerator == absDenominator)    return $"{minus}1";
            else                                        return $"{minus}{absNumerator}/{absDenominator}";

        }
    }
}
