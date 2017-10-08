using System;

namespace Zadatak1_Ishod1
{
    public static class Menu
    {

        public static void Print()
        {
            do
            {
                switch (PickMenuToPrint())
                {
                    case 1: //Popis tema
                        Console.WriteLine("Teme:");
                        Forum.PrintThemes(false);
                        break;
                    case 2: //Popis postova
                        Console.WriteLine("Postovi:");
                        Forum.PrintAllPosts(false, true);
                        break;
                    case 3: //Pretraživanje postova
                        Console.Write("Upišite riječ(i) po kojoj želite pretražiti postove: ");
                        Forum.PrintFilteredPosts(Console.ReadLine(), true);
                        break;
                    case 4: //Dodavanje postova
                        Forum.AddPost(CreatePost());
                        break;
                    case 5: //Uklanjanje postova
                        Forum.RemovePost(PostToDelete());
                        break;
                    case 6: //Izlaz iz aplikacije, dovoljno je vratiti se u Main() s return;
                        return;
                }
            } while (WaitForInput());
        }

        private static int PickMenuToPrint()
        {
            string input; //unos od korisnika
            int chosenMenu; //varijabla u koju će biti zapisan ispravan broj menija na koji korisnik želi otići

            do //ponavaljamo dok ne bude ispravan unos - treba biti int i broj od 1 do 6
            {
                //Ispis..
                Console.Clear();
                Console.WriteLine("Forum");
                Console.WriteLine("1 Popis tema");
                Console.WriteLine("2 Postovi na forumu");
                Console.WriteLine("3 Pretraži postove");
                Console.WriteLine("4 Dodaj post");
                Console.WriteLine("5 Obriši post");
                Console.WriteLine("6 Izlaz");
                Console.Write("Upišite broj zapisan pored željene opcije: ");

                input = Console.ReadLine(); //unos
            } while (!int.TryParse(input, out chosenMenu) || chosenMenu < 1 || chosenMenu > 6);

            Console.Clear();

            return chosenMenu;
        }

        /// <summary>
        /// Waits for the user input after some menu is printed to see if the user wants to
        /// continue (returns true in that case) or exit the program (returns false)
        /// </summary>
        private static bool WaitForInput()
        {
            Console.WriteLine();
            Console.Write("Pritisnite bilo koju tipku da se vratite na prošli meni ili Q za izlaz: ");

            //ReadKey() uzima samo tipku koju korisnik stisne i ne čeka da stisne enter, da bi dohvatili
            //char iz ove funkcije (koja vraća informacije o tome što je pritisnuto),
            //trebamo pristupiti varijabli KeyChar (iz klase ConsoleKeyInfo)
                //duža verzija:
                //ConsoleKeyInfo info = Console.ReadKey();
                //char input = info.KeyChar;
            //alternativa bi bila  do{ispis}while(!char.TryParse(Console.ReadLine(), out charVar));
            char input = Console.ReadKey().KeyChar; 

            if (input == 'q' || input == 'Q')
            {
                Console.Clear();
                return false;
            }
            else
                return true;
        }

        private static Post CreatePost()
        {
            Console.Clear();
            Console.WriteLine("Izrada posta");
            Console.WriteLine();

            Console.Write("Naslov posta: ");
            string title = Console.ReadLine();

            Console.Write("Sadržaj posta: ");
            string content = Console.ReadLine();

            //nije zadano tko koristi Forum niti da treba biti Login sustav
            User user = new User("Korisnik");

            Console.WriteLine();
            Console.WriteLine("Moguće teme:");

            string input; //unos od korisnika
            int themeChosen; //tema koja će biti odabrana 
            int numThemes = Forum.GetNumberOfThemes(); //da znamo do koliko moramo ograničiti unos

            do
            {
                Console.Clear();
                Forum.PrintThemes(true);
                Console.Write("Odaberite temu posta (upišite broj zapisan pored željene opcije): ");

                input = Console.ReadLine();
            } while (!int.TryParse(input, out themeChosen) || themeChosen < 1 || themeChosen > numThemes);

            Console.WriteLine("Post uspješno izrađen!");

            return new Post(title, content, user, Forum.GetThemeAt(themeChosen - 1)); //-1 jer želimo index
        }

        /// <summary>
        /// Returns the index of the post user wants to delete
        /// </summary>
        private static int PostToDelete()
        {
            int numPosts = Forum.GetNumberOfPosts(); //da znamo do koliko moramo ograničiti unos
            int postToDelete;
            do
            {
                Console.Clear();
                Forum.PrintAllPosts(true, false);

                Console.Write("Upišite broj zapisan pored posta koji želite obrisati: ");
            } while (!int.TryParse(Console.ReadLine(), out postToDelete) || postToDelete < 1 || postToDelete > numPosts);

            Console.WriteLine("Post uspješno izbrisan!");

            return postToDelete - 1; //vraćamo s -1 jer želimo index posta
        }

    }
}
