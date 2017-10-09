using System;

namespace Algoritmi
{
    class Program
    {
        static void Main(string[] args)
        {
            const int primeMin = 1000, primeMax = 1100;
            const int armstrongMin = 1, armstrongMax = 10000;
            const int factorialMin = 0, factorialMax = 69;

            Console.WriteLine($"Prosti brojevi [{primeMin}, {primeMax}]:");
            for (int i = primeMin; i <= primeMax; i++)
            {
                if(IsPrime(i))
                    Console.WriteLine($"{i} je prost broj.");
            }

            Console.WriteLine();

            Console.WriteLine($"Armstrongovi brojevi [{armstrongMin}, {armstrongMax}]:");
            for (int i = armstrongMin; i <= armstrongMax; i++)
            {
                if(IsArmstrong(i))
                    Console.WriteLine($"{i} je Armstrongov broj");
            }

            Console.WriteLine();

            Console.WriteLine($"Faktorijele [{factorialMin}, {factorialMax}]:");
            for (int i = factorialMin; i <= factorialMax; i++)
            {
                Console.WriteLine($"{i}! = {Factorial(i)}");
            }
        }

        private static bool IsPrime(int number)
        {
            //Broj je prost ako je djeljiv samo s 1 i sa samim sobom
            //Dakle, ako je djeljiv s bilo čim u intervalu [2, number - 1], znači da nije prost
            //dakle i ide od 2 do number - 1 
            for(int i = 2; i < number; i++) //(može se zapisati kao i = 2; i <= number - 1; i++)
            {
                if (number % i == 0) //je li djeljiv s trenutnim brojem u intervalu?
                    return false; //ako je, možemo odmah izaći iz funkcije jer znamo da nije prost
            }

            //ako je izašao iz fora, znači da nije djeljiv niti sa jednim brojem iz intervala, dakle - prost je
            return true;
        }

        private static bool IsArmstrong(int number)
        {
            //Broj je armstrongov ako je jednak sumi svojih znamenki^3, npr.:
            //153 = 1^3 + 5^3 + 3^3
            //Ovo je uzeto s vježbi, inače je algoritam da se znamenke stavi na potenciju dužine broja, npr
            //ako je četveroznamenkasti, u algoritmu je suma znamenki^4

            int sum = 0; //ovdje ćemo stavljati kubove znamenki, na kraju vraćamo je li to jednako broju koji smo dobili

            //Kako ne bi koristili nekakav algoritam, najlakše je pretvoriti broj u niz znakova (string),
            //pa jedan po jedan vraćati u int (još jedna prednost je što ne moramo raditi kopiju broja):
            string digits = number.ToString();

            //Prolazimo foreach petljom kroz svaku znamenku (s obzirom da radimo sa stringovima, to je skupina
            //charova, dakle za svaki char u njemu prvo ga trebamo pretvoriti u int, pa ga kubirati i nadodati sumi)
            //kad pretvaramo char u int, ne možemo koristiti npr. (int)digit jer bi to vratilo nešto kao 50 jer
            //su charovi zapravo organizirani po ASCII kodu, tako da trebamo koristiti char.GetNumericValue(digit);
            //što vraća double pa ga trebamo "cast"ati u int
            foreach(char digit in digits)
            {
                int digitValue = (int) char.GetNumericValue(digit);
                int digitCubed = (int) Math.Pow(digitValue, 3); //umjesto 3 bi stavili digits.Length za pravi algoritam

                sum += digitCubed;
            }
            
            //sad kad smo zbrojili sve znamenke^3, možemo vratiti je li taj zbroj jednak broju koji ispitujemo
            return sum == number;
        }

        private static ulong Factorial(int number)
        {
            //Faktorijela -> n! = 1 * 2 * 3 * ... * n
            //dakle početna vrijednost je 1, i množimo ju sa 2 pa sa 3 pa sa 4, ... pa sa n
            //to je for [2, n]

            ulong factorial = 1; //ulong je 64-bitni pozitivni cijeli broj (skraćeno od unsigned long)

            for(int i = 2; i <= number; i++)
            {
                factorial *= (ulong)i;
            }

            return factorial;
        }

    }
}
