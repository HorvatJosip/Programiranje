namespace Zadatak1_Ishod1
{
    public class User
    {
        //Naming convention - public varijable počinju velikim slovom, private malim slovom

        public string Name; //ime koje se prikazuje kada napiše post
        
        private string username; //korisničko ime za login
        private string password; //lozinka za login

        //raznorazne mogućnosti varijabli poput DateJoined, PostsWritten, ...

        //s 3 crte stavljam komentar koji mogu vidjeti kada pređem mišem preko objekta iznad kojeg sam napisao taj
        //komentar (npr. prelazak preko riječi User ispod), može se staviti iznad klasa, funkcija, enuma, varijabli, ...
        //vrlo korisno kada se radi s projektima s više od jedne klase/datoteke jer znam što radi, ne moram otići
        //pogledati tamo gdje je napisano da saznam što radi i pomaže drugima koji rade s kodom kasnije
        /// <summary>
        /// Creates a user without login information
        /// </summary>
        /// <param name="name">User's full name</param>
        public User(string name) //bez registracije
        {
            Name = name;
        }

        //konstruktor 2 - simulira Sign Up (registraciju) na forumu
        public User(string username, string password, string name)
        {
            this.username = username;
            this.password = password;

            Name = name;
        }
    }
}
