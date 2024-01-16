﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    public class Bakery
    {
        private List<(string SKU, double Price, Product.ProdType Type, string Variant)> _products;
        private int _basketCapacity = 12;
        private List<Basket> _customers = new List<Basket>();
        public Bakery() 
        {
            _products = new List<(string, double, Product.ProdType, string)>
            {
                ("BGLO", 0.49d, Product.ProdType.Bagle, "Onion"),
                ("BGLP", 0.39d, Product.ProdType.Bagle, "Plain"),
                ("BGLE", 0.49d, Product.ProdType.Bagle, "Everything"),
                ("BGLS", 0.49d, Product.ProdType.Bagle, "Sesame"),
                ("COFB", 0.99d, Product.ProdType.Coffee, "Black"),
                ("COFW", 1.19d, Product.ProdType.Coffee, "White"),
                ("COFC", 1.29d, Product.ProdType.Coffee, "Cappuccino"),
                ("COFL", 1.29d, Product.ProdType.Coffee, "Latte"),
                ("FILB", 0.12d, Product.ProdType.Filling, "Bacon"),
                ("FILE", 0.12d, Product.ProdType.Filling, "Egg"),
                ("FILC", 0.12d, Product.ProdType.Filling, "Cheese"),
                ("FILX", 0.12d, Product.ProdType.Filling, "Cream Cheese"),
                ("FILS", 0.12d, Product.ProdType.Filling, "Smoked Salmon"),
                ("FILH", 0.12d, Product.ProdType.Filling, "Ham")
            };

            _customers.Add(new Basket(_basketCapacity));
        }

        public bool AddToBasket(string sku, int customer = 0)
        {
            if (_products.Exists(x => x.SKU == sku))
            {
                int index = _products.IndexOf(_products.Find(x => x.SKU == sku));
                return _customers[customer].AddProduct(new Product(_products[index].SKU, _products[index].Price, _products[index].Type, _products[index].Variant));
            }
            return false;
        }

        public int RemoveFromBasket(string sku, int customer = 0)
        {
            return _customers[customer].Remove(sku);
        }

        public int ChangeCapacity(int amount)
        {
            if (amount < 0)
                return _basketCapacity;
            _basketCapacity = amount;
            foreach (var item in _customers)
            {
                item.ChangeCapacity(_basketCapacity);
            }
            return _basketCapacity;
        }

        public double BagleCost(string sku)
        {
            throw new NotImplementedException();

        }

    }
}
