using System;

namespace Zadatak3_Ishodi56
{

    /*
     * Uzeto iz primjera ispitnih pitanja prikazanih na prvom predavanju
    == I5, I6 ==

    Napišite klasu TaskManager koji upravlja zadacima korisnika. Program treba omogućiti dodavanje
    i dohvaćanje zadataka prema zadanim kriterijima. Detaljniji opis pojmova:
    a) Svaki zadatak definiran je sljedećim karakteristikama: ID zadatka, Naziv, Datum i vrijeme, Kategorija zadatka
    b) Moguće kategorije : Obitelj, Posao, Hobi
    c) Datum i vrijeme zadatka prilikom kreiranja ili editiranja mogu biti isključivo u budućnosti;
        nemoguće je zadati vrijeme u prošlosti.
    d) ID-evi moraju biti jedinstveni. Ne morate taj uvjet validirati, samo pripazite kod unošenja tog podatka

    Opis funkcionalnosti: 

    Prilikom pokretanja aplikacije, provjerava se da li postoje spremljeni zadaci u određenoj datoteci (taskManagerDB.txt)
    Ako postoje, aplikacija ih učitava u memoriju. Na osnovu svih traženih funkcionalnost,
    odaberite kolekciju za koju mislite da najbolje odgovara zahtjevima zadatka. 

    U glavnom programu omogućite izbornik koji nudi sljedeće opcije: 
    • Kreiranje novog zadatka
    • Dohvaćanje i ispis svih zadatka za zadanu kategoriju
    • Dohvaćanje i ispis svih zadatka
    • Dohvaćanje i ispis postojećeg zadatka (za uneseni ID zadatka)
    • Provjera zadataka (*)

    (*) U metodi za provjeru zadataka, implementirajte sljedeću funkcionalnost: Ako neki od zadataka
    počinju za manje ili jednako 15 minuta, na konzoli u crvenoj boji treba ispisati poruku npr ""Naziv:
    Nazvati dragu, godišnjica je danas, ID: 1, počinje za 13 minuta"". Pri tome naziv i ID predstavljaju
    podatke o zadatku koji će uskoro početi. Rješenje treba implementirati korištenjem događaja
    (kreirati događaj u klasi TaskManager, pretplatnik je glavni program - konzola)

    Prlikom gašenja aplikacije, svi taskovi (ako postoje), spremaju se u datoteku (taskManagerDB.tx). 
    Obavezno obradite sve moguće ugrađene iznimke (npr. datoteka kod učitavanja ne postoji,
        krivo unesen datum i vrijeme, itd..)
    Kreirajte vlastitu iznimku WrongTaskDateTimeException kojom ćete riješiti zahtjev iz c) dijela zadatka*/

    class Program
    {
        private const string fileName = "taskManagerDB.txt";

        static void Main(string[] args)
        {
            TaskManager.LoadTasks(fileName);

            TaskManager.ImportantTaskFound += OnImportantTaskFound;

            MainMenu();
        }

        private static void OnImportantTaskFound(TaskManagerEventArgs e)
        {
            Console.Clear();

            if (e.ImportantTasks.Count == 0) Console.WriteLine("There are no tasks 15 minutes or less from now.");
            else
            {
                Console.WriteLine("Tasks 15 minutes or less from now:");

                var currentColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;

                e.ImportantTasks.ForEach(task => Console.WriteLine(task));

                Console.ForegroundColor = currentColor;
            }

            Menu.WaitBeforeProceeding();
        }

        static void MainMenu()
        {
            switch (Menu.PrintAndGetUserInput("Main menu", "Create new task", "List all tasks", "List all tasks of certain category",
                "List the task with certain ID", "Check tasks", "Exit"))
            {
                case 1:
                    TaskManager.CreateNewTask();
                    break;
                case 2:
                    TaskManager.PrintTasks();
                    break;
                case 3:
                    TaskManager.PrintTasks(Utilities.AskForTaskCategory());
                    break;
                case 4:
                    TaskManager.PrintTasks(Utilities.AskForInt("Enter task ID"));
                    break;
                case 5:
                    TaskManager.CheckTasks();
                    break;
                case 6:
                    TaskManager.SaveTasks(fileName);

                    TaskManager.ImportantTaskFound -= OnImportantTaskFound;
                    
                    Menu.Exit();
                    break;
            }

            MainMenu();
        }
    }
}
