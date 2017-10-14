using System;
using System.Linq;

namespace Zadatak2_Ishodi234
{
    class Purchase : Discount
    {
        public float FinalPrice { get; private set; }
        public bool Finalized { get; private set; } = false;

        public int NumItemsInBasket { get { return Products.Count; } }

        public void FinalizePurchase()
        {
            string cheapestProductOffer = $"{cheapestProductDiscountPercentage}% discount on cheapest product";
            string wholePriceOffer = $"{wholePriceDiscountPercentage}% discount on the whole price";
            string[] options;

            if (Products.Count >= cheapestProductFreeItemMinimum)
                options = new string[] { cheapestProductOffer, wholePriceOffer, "Cheapest product free" };
            else
                options = new string[] { cheapestProductOffer, wholePriceOffer };

            switch (Menu.PrintAndGetUserInput("Choose discount option", options))
            {
                case 1: //cheapest product discount
                    FinalPrice = CheapestProductDiscount();
                    break;
                case 2: //whole price discount
                    FinalPrice = WholePriceDiscount();
                    break;
                case 3: //cheapest product free
                    FinalPrice = CheapestProductFree();
                    break;
                default:
                    throw new Exception("Unknown option selected...");
            }

            Finalized = true;
            Shop.SetupNewPurchase();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProductAt(int productIndex)
        {
            Products.RemoveAt(productIndex);
        }

        public string[] ItemsInBasket()
        {
            return Products.Select(product => product.ToString()).ToArray();
        }
    }
}
