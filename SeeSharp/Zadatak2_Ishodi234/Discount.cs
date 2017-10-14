using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadatak2_Ishodi234
{
    class Discount
    {
        protected List<Product> Products = new List<Product>();

        /// <summary>
        /// Percentage to discount from cheapest product,
        /// must be 0-100 (inclusive)
        /// </summary>
        protected float cheapestProductDiscountPercentage = 50;

        /// <summary>
        /// Percentage to discount from total, must be 0-100 (inclusive)
        /// </summary>
        protected float wholePriceDiscountPercentage = 20;

        /// <summary>
        /// Minimal number of products to qualify for this discount
        /// </summary>
        protected int cheapestProductFreeItemMinimum = 3;

        /// <summary>
        /// Calculates the price after discount on the cheapest item in the product list
        /// </summary>
        /// <returns>Discounted price</returns>
        protected virtual float CheapestProductDiscount()
        {
            return FullPrice() - (PercentageMultiplier(cheapestProductDiscountPercentage) * CheapestProductPrice());
        }

        /// <summary>
        /// Calculates the price with the discount on the full price
        /// </summary>
        /// <returns>Discounted price</returns>
        protected virtual float WholePriceDiscount()
        {
            return PercentageMultiplier(wholePriceDiscountPercentage) * FullPrice();
        }

        /// <summary>
        /// Calculates the price when the cheapest product is given free of charge.
        /// </summary>
        /// <returns>Discounted price</returns>
        protected virtual float CheapestProductFree()
        {
            return FullPrice() - CheapestProductPrice();
        }

        private float CheapestProductPrice()
        {
            return Products.Min(product => product.Price);
        }

        /// <summary>
        /// Sums all the prices in the Product list
        /// </summary>
        private float FullPrice()
        {
            return Products.Sum(product => product.Price);
        }

        private float PercentageMultiplier(float percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new Exception($"Invalid percentage ({percentage} %)");

            return percentage / 100;
        }
    }
}
