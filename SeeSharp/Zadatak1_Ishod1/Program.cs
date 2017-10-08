using System;

namespace Zadatak1_Ishod1
{

    /*
     * Uzeto iz primjera ispitnih pitanja prikazanih na prvom predavanju
    == I1 ==

    "Napišite program koji simulira rad online foruma. Mogućnosti koje forum ima su: 
    • korisnik može pregledati postojeće teme i postove,
    • korisnik može pretraživati sve postove, 
    • korisnik može dodati ili obrisati post. 
        -> nije dovoljno informacija da se zna može li brisati bilo koji ili samo svoje

    Koristeći objektno orijentirani pristup, osmislite i implementirajte rješenje. Kreirajte barem 5 tema
    i barem 2 korisnika. Demonstrirajte tražene mogućnosti jednostavnim konzolnim programom. 

    ========

    Iz teksta se vidi koje klase (objekte) treba napraviti:
    == Obavezne
        • Korisnik (da znamo podatke određenog korisnika koji koristi forum)
    == Opcionalne
        • Post (ako želimo da ima više stvari, a ne samo sadržaj koji možemo jednostavno spremiti u string)
        • Forum (statična (od koje se ne mogu raditi objekti, nego se koristi za npr. grupiranje funkcija),
        da smjestimo unutra funkcionalnosti foruma, može se umjesto ovoga sve u ovoj klasi napraviti,
        ali to nije najbolje rješenje - Main bi trebao biti minimalne dužine, dovoljna je 1 linija)
        • Izbornik (s obzirom da radimo u konzoli, trebali bi ispisati mogućnosti korisniku; može se napraviti
        u ovoj klasi ili u klasi Forum ili u posebnoj klasi)
     */

    
    class Program
    {
        static void Main(string[] args)
        {
            //1) Izrada klase User i izrada barem 2 korisnika
            User andy = new User("Andy");
            User milo = new User("Milo");

            //2) Izrada statične klase Forum i klase Post i nakon toga dodavanje nekoliko postova na Forum
            Forum.AddPost(new Post("Post 1", "Sadržaj 1", andy, "Elektronika"));
            Forum.AddPost(new Post("Post 2", "Sadržaj 2", andy, "Hrana"));
            Forum.AddPost(new Post("Post 3", "Sadržaj 3", milo, "Elektronika"));
            Forum.AddPost(new Post("Post 4", "Sadržaj 4", andy, "Igrice"));
            Forum.AddPost(new Post("Post 5", "Sadržaj 5", milo, "Igrice"));
            Forum.AddPost(new Post("Post 6", "Sadržaj 6", milo, "Životni stil"));
            Forum.AddPost(new Post("Post 7", "Sadržaj 7", andy, "Posao"));

            //3) Izrada statične klase Menu koja se brine o izborniku i dovoljan je jedan poziv
            Menu.Print();

            //Opcionalna završna poruka
            Console.WriteLine("Hvala na posjeti! Ugodan ostatak dana.");
        }
    }
}
