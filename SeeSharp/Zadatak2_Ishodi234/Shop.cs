using System.Collections.Generic;
using System.Linq;

namespace Zadatak2_Ishodi234
{
    static class Shop
    {

        public static List<Purchase> Purchases { get; private set; } = new List<Purchase>();

        private static Purchase CurrentPurchase
        {
            get
            {
                return Purchases.Last();
            }
        }

        private static IEnumerable<Purchase> FinalizedPurchases
        {
            get
            {
                return Purchases.Where(purchase => purchase.Finalized);
            }
        }

        private static List<Product> products = new List<Product>()
        {
            new Racket(1, "Teniski reket 1", 15.99f, 5, RacketType.Tennis),
            new Racket(2, "Teniski reket 2", 18.99f, 7, RacketType.Tennis),
            new Racket(3, "Badminton reket 1", 9.99f, 1, RacketType.Badminton),
            new Racket(4, "Badminton reket 2", 14.99f, 2, RacketType.Badminton),

            new SoccerBall(5, "Nogometna lopta 1", 7.99f, BallSize.Four),
            new SoccerBall(6, "Nogometna lopta 2", 9.99f, BallSize.Five),
            new SoccerBall(7, "Košarkaška lopta 1", 11.99f, BallSize.Four),
            new SoccerBall(8, "Košarkaška lopta 2", 15.99f, BallSize.Five),
        };

        public static void SetupNewPurchase()
        {
            Purchases.Add(new Purchase());
        }

        public static void MainMenu()
        {
            switch (Menu.PrintAndGetUserInput("Main menu", "Shop", "Statistics", "Exit"))
            {
                case 1: //Shop

                    PrintShop();

                    return;

                case 2: //Statistics

                    if (FinalizedPurchases.Count() > 0)
                        Menu.Print("Statistics",
                            $"Biggest purchase: {FinalizedPurchases.Max(purchase => purchase.FinalPrice)} USD",
                            $"Smallest purchase: {FinalizedPurchases.Min(purchase => purchase.FinalPrice)} USD");
                    else
                        Menu.Print("Statistics", "There are currently no purchases...");

                    MainMenu();

                    return;

                case 3: //Exit

                    Menu.Exit();

                    return;
            }
        }

        private static void PrintShop()
        {

            switch (Menu.PrintAndGetUserInput("Shop", "View items in basket", "Add item to basket",
                "Remove item from basket", "Finalize purchase", "Back to Main Menu"))
            {

                case 1: //View items in basket

                    MessageWhenBasketIsEmpty(
                            "There is nothing in the basket, so there aren't any items to view.");

                    Menu.Print("Basket", CurrentPurchase.ItemsInBasket());

                    break;

                case 2: //Add item to basket

                    int choice = Menu.PrintAndGetUserInput("Products for sale",
                        products.Select(product => product.ToString()).ToArray());

                    CurrentPurchase.AddProduct(products[choice - 1]);

                    break;

                case 3: //Remove item from basket

                    MessageWhenBasketIsEmpty(
                        "There is nothing in the basket, so there aren't any items to remove.");

                    choice = Menu.PrintAndGetUserInput("Remove items", CurrentPurchase.ItemsInBasket());
                    CurrentPurchase.RemoveProductAt(choice - 1);

                    break;

                case 4: //Finalize purchase

                    MessageWhenBasketIsEmpty(
                        "You must have at least one item in the basket in order to finalize purchase.");

                    CurrentPurchase.FinalizePurchase();
                    MainMenu();

                    break;

                case 5: //Back to Main Menu

                    MainMenu();

                    break;
            }

            PrintShop();
        }

        /// <summary>
        /// If there are no items in the basket, don't proceed with the next step, but go back to the
        /// shop after displaying specified message
        /// </summary>
        private static void MessageWhenBasketIsEmpty(string message)
        {
            if (CurrentPurchase.NumItemsInBasket <= 0)
            {
                Menu.Print("Nothing in basket", message);
                PrintShop();
            }
        }

    }
}
