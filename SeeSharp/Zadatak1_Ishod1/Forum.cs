using System;
using System.Collections.Generic;

namespace Zadatak1_Ishod1
{
    public static class Forum
    {
        //Naming convention - public varijable počinju velikim slovom, private malim slovom

        //#region služi za grupiranje koda radi bolje čitljivosti i omogućava skupljanje svog koda do
        //#endregion i prikazuje samo naziv regije/skupine/grupe

        #region Themes

        private static List<string> themes = new List<string>() //sve teme dostupne na forumu
        {
            "Elektronika", "Hrana", "Igrice", "Životni stil", "Posao", "Ostalo"
        };

        public static int GetNumberOfThemes()
        {
            return themes.Count;
        }

        public static string GetThemeAt(int index)
        {
            return themes[index];
        }

        /// <summary>
        /// Checks if the given theme exists in the theme list
        /// </summary>
        /// <param name="theme">Name of the theme</param>
        public static bool ValidTheme(string theme)
        {
            return themes.Contains(theme);
        }

        /// <summary>
        /// Prints the list of themes in the console
        /// </summary>
        public static void PrintThemes(bool printThemeNumber)
        {
            for (int i = 0; i < themes.Count; i++)
            {
                if (printThemeNumber)
                {
                    Console.Write(i + 1 + " ");
                }

                Console.WriteLine(themes[i]);
            }
        }

        #endregion

        #region Posts

        private static List<Post> posts = new List<Post>(); //svi postovi na forumu

        public static void AddPost(Post post)
        {
            posts.Add(post);
        }

        public static void RemovePost(int postIndex)
        {
            posts.RemoveAt(postIndex);
        }

        public static int GetNumberOfPosts()
        {
            return posts.Count;
        }

        /// <summary>
        /// Prints the list of posts in the console
        /// </summary>
        public static void PrintAllPosts(bool printPostNumber, bool printPostContents)
        {
            for (int i = 0; i < posts.Count; i++)
            {
                if (printPostNumber)
                    PrintPost(posts[i], i + 1, printPostContents);
                else
                    PrintPost(posts[i], 0, printPostContents);
            }
        }

        /// <summary>
        /// Prints posts filtered by the given search word(s)
        /// </summary>
        /// <param name="searchWord">Word(s) used to filter the posts</param>
        public static void PrintFilteredPosts(string searchWord, bool printPostContents)
        {
            /*
             * Foreach petlja je puno čitljivija i praktičnija u večini slučajeva nego for
             * Bilo bi dobro što prije se naviknuti na nju jer je lakše kad se ne mora misliti na indexe, a i
             * varijabla na indexu i je odma dostupna, ne trebamo joj pristupati sa varijabla[i]
             * For petlja koja odgovara foreach petlji ispod:
              
            for (int i = 0; i < posts.Count; i++)
            {
                Post post = posts[i];

                PrintPost(post, 0);
            }
            */

            foreach (Post post in posts)
            {
                if (post.Search(searchWord))
                {
                    PrintPost(post, 0, printPostContents);
                }
            }
        }

        /// <summary>
        /// Prints the given post to the console
        /// </summary>
        /// <param name="post">Post to print to the console</param>
        private static void PrintPost(Post post, int postNumber, bool printPostContents)
        {
            if (postNumber > 0) //koristimo pri brisanju da korisnik može odabrati što želi obrisati
            {
                Console.Write(postNumber + " ");
            }

            Console.WriteLine($"[{post.Theme}] {post.Title} by: {post.Author.Name} ({post.CreationDate})");

            if (printPostContents)
                Console.WriteLine(post.Contents);

            Console.WriteLine();
        }

        #endregion
    }
}
