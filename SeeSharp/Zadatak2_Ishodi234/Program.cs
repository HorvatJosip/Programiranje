namespace Zadatak2_Ishodi234
{

    /*
     * Uzeto iz primjera ispitnih pitanja prikazanih na prvom predavanju
    == I2, I3, I4 ==

    I2 = Primijeniti princip nasljeđivanja u programskom jeziku (polymorphism & inheritance)
    I3 = Primijeniti sučelja i apstraktne klase u programskom jeziku (interfaces & abstract classes)
    I4 = Primijeniti kolekcije i generičke strukture u programskom jeziku (generics & collections)

    Tvrtka „Sportsman“ bavi se prodajom sportske opreme. S obzirom na nadolazeće blagdane, odlučili su neke proizvode ponuditi po akcijskim cijenama. Proizvodi koji će se prodavati po akcijskim cijenama su: teniski i badmintonski reketi, te nogometne lopte. Za sve te proizvode tvrtka vodi sljedeće informacije: kataloška oznaka proizvoda (id), naziv i osnovna cijena (float). Dodatno, za lopte se čuva informacija o veličini lopte (4 ili 5), dok se za rekete dodatno čuvaju sljedeće informacije: nategnutost žica (u kg) i tip (badminton ili tenis) 
    -> inheritance (više proizvoda s istim karakteristikama, a neki imaju još neke dodatne informacije koje sami čuvaju)

    Tvrtka je odlučila kreirati web stranicu na kojoj kupcima nudi mogućnost kupnje proizvoda. Kupac prije nego zaključi kupnju ima mogućnost dodavanja proizvoda u košaricu i micanja proizvoda iz košarice. Kupcu se nakon zaključivanja izračunava konačna cijena koja se dobije tako da se na osnovne cijene proizvoda primijeni i trenutno važeći popust
    -> klasa Purchase (omogućava čuvanje List<Product> koje želi kupiti određeni kupac)

    Trenutno postoje 3 varijante izračuna popusta za kupca:
    • 50% popusta na cijenu najjeftinijeg proizvoda
    • 20% na cjelokupni iznos
    • Ako je kupljeno barem 3 proizvoda, najjeftiniji je gratis
    -> Discount klasa s virtual funkcijama za izračun tako da se mogu lako promijeniti

    Tvrtka vodi evidencije o svim kupnjama koje su zaključene.

    Predložite klase potrebne za vođenje poslovanja tvrtke. Odredite hijerarhije klasa te ih implementirajte.

    Omogućite jednostavnu promjenu strategije izračuna popusta, kad ju uprava tvrtke poželi promijeniti.
    -> izračuni idu svaki u svoju funkciju s parametrima (50%, 20%, 3)

    Omogućite ispis najveće i najmanje kupnje (kupnje u kojoj je konačni iznos bio najveći, odnosno najmanji) sortiranjem svih zaključenih kupnji.
    -> klasa Purchase omogućava manipulaciju s košaricom, nakon toga čuvamo List<Purchase> i nađemo min.i max. ukupnu cijenu vrlo jednostavno
     */

    class Program
    {        

        static void Main(string[] args)
        {
            Shop.SetupNewPurchase();
            Shop.MainMenu();
        }        

    }
}
