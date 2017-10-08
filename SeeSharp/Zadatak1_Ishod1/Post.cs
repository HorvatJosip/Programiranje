using System;

namespace Zadatak1_Ishod1
{
    public class Post
    {
        //Naming convention - public varijable počinju velikim slovom, private malim slovom

        public string Title; //naslov
        public string Contents; //sadržaj napisan u postu
        public User Author; //korisnik koji je napisao post
        public string Theme; //na koju je temu post napisan

        //dodano čisto iz fore jer je obično praksa na forumima imati datum kad je napravljen post
        public DateTime CreationDate;

        public Post(string title, string contents, User author, string theme)
        {
            Title = title;
            Contents = contents;
            Author = author;

            //ovo nije najbolje rješenje, zato što moramo koristiti temu "Ostalo" jer korisnik može vrlo lagano
            //krivo unijeti naziv teme (a stringovima je isto tako važno poklapaju li se i velika i mala slova,
            //dakle ako upiše "elektronika", a tema je zapisana kao "Elektronika", strpat će ju u "Ostalo")
            //najbolje rješenje je koristiti enum, ali sintaksa za ispis enum-a je dosta zbunjujuća
            //i mora se koristiti jer se ne može proći kroz njih petljom kao kroz npr. polje
            if (Forum.ValidTheme(theme))
                Theme = theme;
            else
                Theme = "Ostalo";

            CreationDate = DateTime.Now; //uzima s računala informaciju o trenutnom datumu i vremenu
        }

        /// <summary>
        /// Used to search this post by the given search word(s).
        /// Returns true if the post contains the given word(s).
        /// Searches through the theme, title, contents and author's name.
        /// </summary>
        /// <param name="searchWord">Word(s) to use in searching</param>
        public bool Search(string searchWord)
        {
            return
                Title.Contains(searchWord) ||
                Author.Name.Contains(searchWord) ||
                Contents.Contains(searchWord) ||
                Theme.Contains(searchWord);
        }
    }
}
