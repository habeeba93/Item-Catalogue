using System;
using System.Collections.Generic;
using System.Text;

/*
I want an app that will act as a simple way to catalogue the games/books/whatever I own that can be searched on in a DB
I want to be able to know when I purchased it, how much I purchase it for, some ID that be searched like barcode (in
case I want to know how much it currently goes for. edition (might be useless if I know the barcode)
*/

namespace Item_Catalogue
{
    enum IdentifierType  //This could be a list. A book could have both a barcode and ISBN. Could also just have a Barcode and ISBN prop
    {
        Barcode = 0
         , ISBN = 1
         , ASIN = 2
        // Other?
    }

    class ItemIdentifier
    {
        public string Identifier { get; set; } //not sure if this could contain non-numerics. will contain barcodes or isbn's
        public IdentifierType IDType { get; set; }

        public static int CompareByIDType(ItemIdentifier itemID1, ItemIdentifier itemID2)
        {
            return itemID1.IDType.ToString().CompareTo(itemID2.IDType.ToString());
            //return String.Compare(itemID1.IDType.ToString(), itemID2.IDType.ToString());
        }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        enum ProductType
        {
            Game = 0
            , Book = 1
            // Other?
        }

        private List<ItemIdentifier> ItemIdentifiers;
        public DateTime PurchaseDate { get; set; }
        public string PurchasedFrom { get; set; }
        public string Edition { get; set; }
        public bool IsDigital { get; set; }
        //Platform? (PS4, Steam, Kindle, Etc?)

        //constructor
        public Item(string name)
        {
            this.Name = name;
            ItemIdentifiers = new List<ItemIdentifier>();   //need to give this a default so we don't get null ref if a method using it is called before it's actually initialized
        }

        public Item(string name, decimal purchasePrice, DateTime purchaseDate, String purchasedFrom, string edition, bool isDigital)
        {
            Name = name;
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
            PurchasedFrom = purchasedFrom;
            Edition = edition;
            IsDigital = isDigital;

            ItemIdentifiers = new List<ItemIdentifier>();   //need to give this a default so we don't get null ref if a method using it is called before it's actually initialized
        }

        //methods
        public void addItemIdentifier(IdentifierType idType, string identifier)
        {
            ItemIdentifier newID = new ItemIdentifier();
            newID.IDType = idType;
            newID.Identifier = identifier;

            this.ItemIdentifiers.Add(newID);
        }

        //gets a list of the identifiers tied to this item
        private string getItemIdentifiers()
        {
            string returnString = "";

            if (this.ItemIdentifiers.Count > 0)
            {
                returnString += "Product Identifiers: \n";
                //thanks https://thedeveloperblog.com/comparison
                Comparison<ItemIdentifier> comparison = new Comparison<ItemIdentifier>(ItemIdentifier.CompareByIDType);

                //Sort the list before displaying for consistency
                //thanks LukeH (https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object)
                //Sort((x, y) => x.OrderDate.CompareTo(y.OrderDate));
                //this.ItemIdentifiers.Sort(x, y) => x.IDType.CompareTo(y.IDType);
                this.ItemIdentifiers.Sort(comparison);

                foreach (ItemIdentifier id in this.ItemIdentifiers)
                {
                    returnString += String.Format("\t{0}: {1}\n", id.IDType, id.Identifier);
                }
            }

            return returnString;
        }

        // Displays details on the items as well as any identifiers recorded for the item.
        public override string ToString()
        {

            string returnString = "";
            returnString = String.Format("Name: {0} \n" +
                "Purchase price: {1} \n" +
                "Purchase date: {2} \n" +
                "Purchased from: {3} \n" +
                "Edition: {4} \n" +
                "Is digital? {5} \n", this.Name, this.PurchasePrice, this.PurchaseDate.ToShortDateString(), this.PurchasedFrom, this.Edition, this.IsDigital);

            returnString += getItemIdentifiers();

            return returnString;

        }

    }
}
