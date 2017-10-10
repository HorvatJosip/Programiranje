using System;

namespace Vjezbe_3_4
{

    //Neke klase (ili strukture) su toliko kratke da ih je OK pisati tamo gdje ih mislimo koristiti, ne treba
    //ih u posebnoj datoteci pisati

    /// <summary>
    /// 2D Point with ungsinged integers x and y
    /// </summary>
    class Point
    {
        //uint = unsigned int (samo pozitivne vrijednosti i 0)
        public uint X { get; private set; }
        public uint Y { get; private set; }

        public Point(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    /// <summary>
    /// Color with red, green and blue values ranging from 0 to 255
    /// </summary>
    class Color
    {
        public int R { get; private set; }
        public int G { get; private set; }
        public int B { get; private set; }
        
        public Color(int red, int green, int blue)
        {
            R = red;
            G = green;
            B = blue;

            //trebaju sve biti u intervalu [0, 255] (zato ih spajamo s &&), ako bilo koja nije (!), bacamo grešku
            //opširnije - logička operacija && vraća true samo ako su svi uvjeti ispunjeni, ako to obrnemo (s !), vraća
            //false samo kada su sva tri ispunjena, što nama treba, u svim ostalim slučajevima znači da je krivi unos.
            //kada bi to čitali s lijeva na desno bilo bi "ako nisu sve 3 brojke u intervalu [0, 255], greška!!!!!!"
            if (!(InRange(red) && InRange(green) && InRange(blue)))
            {
                throw new Exception("Color value(s) out of range.");
            }
        }

        private bool InRange(int color)
        {
            //[0, 255]
            return color >= 0 && color <= 255;
        }

        public override string ToString()
        {
            return $"Color RGB[{R}, {G}, {B}]";
        }
    }

    class Window
    {
        public string Title { get; set; } //naslov
        public string Label { get; set; } //oznaka?

        public bool Active { get; set; } //da znamo koji prozor je aktivan, a koji nije

        //trebaju nam dvije točke kako bi znali nacrtati pravokutnik i izračunati širinu i visinu
        public Point UpperLeftCorner { get; set; }
        public Point LowerRightCorner { get; set; }

        public Color Color { get; set; } //boja?

        public Window() //default constructor
        {
            Title = "Window1";

            UpperLeftCorner = new Point(0, 0);
            LowerRightCorner = new Point(80, 25);
        }

        public Window(string title)
        {
            Title = title;
        }

        public Window(string title, Point upperLeftCorner, Point lowerRightCorner, Color color)
        {
            Title = title;

            UpperLeftCorner = upperLeftCorner;
            LowerRightCorner = lowerRightCorner;

            Color = color;
        }

        public long Width()
        {
            return Math.Abs(LowerRightCorner.X - UpperLeftCorner.X);
        }

        public long Height()
        {
            return Math.Abs(LowerRightCorner.Y - UpperLeftCorner.Y);
        }

        public long Area() //površina
        {
            return Width() * Height();
        }

        public long Perimeter() //opseg
        {
            return (2 * Width()) + (2 * Height());
        }

        /// <summary>
        /// Draws the window with the given characters (maximums that you specify for the width and height
        /// are to ensure the correct output)
        /// </summary>
        /// <param name="borderChar">Character that will represent the border of the window</param>
        /// <param name="emptyChar">Character that will be drawn inside the bounds of the window</param>
        /// <param name="maxWidth">Maximum value for the window's width</param>
        /// <param name="maxHeight">Maximum value for the window's height</param>
        public void Draw(char borderChar, char emptyChar, int maxWidth, int maxHeight)
        {
            //Math.Min vraća manji od dviju vrijednosti - ne želimo da ode više od max
            int width = Math.Min(maxWidth, (int)Width());
            int height = Math.Min(maxHeight, (int)Height());

            //Gornji obrub
            for (int i = 0; i < width; i++) { Console.Write(borderChar); }
            Console.WriteLine();

            //Sredina (oduzimamo 2 od visine za gornji i donji obrub
            //u 2D crtanju (ili prolazu kroz 2D polje), vanjski for uvijek ide po visini, a unutarnji po širini
            for(int i = 0; i < height - 2; i++)
            {
                for(int j = 1; j <= width; j++)
                {
                    if (j == 1 || j == width)
                        Console.Write(borderChar);
                    else
                        Console.Write(emptyChar);
                }
                Console.WriteLine();
            }

            //Donji obrub
            for (int i = 0; i < width; i++) { Console.Write(borderChar); }
            Console.WriteLine();

            //alternativa za oba obruba bi bila Console.WriteLine(new string(wallChar, width));
        }

        public override string ToString()
        {
            //? (ternary) operator služi da skrati jednostavne if-else situacije, što je ovdje idealno
            //ako je Active true, pohrani vrijednost "active", inače pohrani "inactive" (u string activityStatus)
            string activityStatus = Active ? "active" : "inactive";

            //C# je dovoljno pametan da pozove ToString() metodu iz klase Point bez da to napišemo
            return $"{Title} ({Label}) - {activityStatus} [P1: {UpperLeftCorner}] [P2: {LowerRightCorner}]";
        }

        public void PrintDimensions()
        {
            Console.WriteLine($"Width = {Width()}, Height = {Height()}");
        }
    }
}
