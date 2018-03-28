using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenChallengeSolution
{
    public class Backpack
    {
        public string function1;
        public string function2;
        public int function3;
        public int function4;

        public Backpack(string category, string type, int souls, int gold) {
            function1 = category;
            function2 = type;
            function3 = souls;
            function4 = gold;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            List<Backpack> itemsList = new List<Backpack>();
            populateData(itemsList);

      
            Console.WriteLine("There are {0} items inside merchants backpack.\n", itemsList.Count);

  
            List<Backpack> swordsList = itemsList.FindAll(FindSwords);
            Console.WriteLine("There are {0} swords inside merchants backpack.\n", swordsList.Count);


            Backpack mostValItem = null;
            int highValue = 0;
            foreach (Backpack c in itemsList) {
                if (c.function4 > highValue) {
                    mostValItem = c;
                    highValue = c.function4;
                }
            }
            Console.WriteLine("The most valuable item is a {2} at {3} gold\n",
                mostValItem.function3, mostValItem.function1, mostValItem.function2, mostValItem.function4);


            int totalValue = 0;
            foreach (Backpack c in itemsList) {
                totalValue += c.function4;
            }
            Console.WriteLine("Merchants items are worth of {0} gold\n", totalValue);


            Dictionary<string, bool> makes = new Dictionary<string, bool>();
            foreach (Backpack c in itemsList) {
                try {
                    makes.Add(c.function1, true);
                }
                catch (Exception) { }
            };
            Console.WriteLine("Marchants collection contains {0} different item types.\n", makes.Keys.Count);


            Console.WriteLine("\nHit Enter to exit...");
            Console.ReadLine();
        }

        static bool FindSwords(Backpack item) {
            if (item.function1 == "Swords")
                return true;
            return false;
        }

        static void populateData(List<Backpack> theList) {
            theList.Add(new Backpack("Swords", "Wooden Sword", 2, 1250));
            theList.Add(new Backpack("Swords", "Iron Sword", 5, 2500));
            theList.Add(new Backpack("Swords", "Felsteel Sword", 10, 4000));

            theList.Add(new Backpack("Shields", "Wooden Shield", 3, 1500));
            theList.Add(new Backpack("Shields", "Iron Shield", 6, 3250));
            theList.Add(new Backpack("Shields", "Felsteel Shield", 11, 4500));
            theList.Add(new Backpack("Shields", "Titansteel Shield", 20, 9200));

            theList.Add(new Backpack("Staves", "Wooden Staff", 4, 1500));
            theList.Add(new Backpack("Staves", "Corrupted Staff", 9, 3900));
            theList.Add(new Backpack("Staves", "Magic Staff", 6, 2500));

            theList.Add(new Backpack("Bows", "Wooden Bow", 4, 1500));
            theList.Add(new Backpack("Bows", "Fel Longbow", 8, 4000));
            theList.Add(new Backpack("Bows", "Corrupted Bow", 6, 3250));
            theList.Add(new Backpack("Bows", "Recurve Bow", 9, 4400));
        }
    }
}
