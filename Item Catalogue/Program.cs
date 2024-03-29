﻿using System;
using ExtensionMethods;

namespace Item_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var newItemName = "Gravity Rush Remastered - PlayStation 4";
            var newItemPurchasePrice = 29.99m;
            var newItemPurchaseDate = new DateTime(2016, 1, 25);
            var newItemPurchasedFrom = "Amazon";
            var newItemEdition = "Standard";
            var newItemIsDigital = false;
            var newItemProductType = ProductType.VideoGame;

            Item newItem = new Item(newItemName, newItemPurchasePrice, newItemPurchaseDate, newItemPurchasedFrom, newItemEdition, newItemIsDigital, newItemProductType);

            newItem.addItemIdentifier(IdentifierType.Barcode, "7 11719 50379 8".removeSpaces());
            newItem.addItemIdentifier(IdentifierType.ASIN, "B017Y97NHM".removeSpaces());

            Console.WriteLine(newItem);

            //Console.WriteLine(t.Name);
            //Console.WriteLine("Hello World!");
        }
    }
}
