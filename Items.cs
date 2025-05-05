using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Items
    {
        // Instantiate Item Class, creating 3 new items that can be used to different effects
        public static readonly HealthItem healthItem = new HealthItem("Health Potion", 5);
        public static readonly MoneyItem moneyItem = new MoneyItem("Bag of Money", 25);
        public static readonly MoneyItem chestItem = new MoneyItem("Treasure Chest", 100);

        // Creates an empty(null) item class called no item so theres a chance of finding no items
        public static readonly Item NoItem = null;

        // Create a new array called 'All' to store created items
        public static Item[] All = new[] { healthItem, moneyItem, chestItem, NoItem };

        // Used LINQ queries to filter item list
        private static readonly List<Item> _itemsOfHealthItem = All.Where(item => item is HealthItem).Select(item => item).ToList();
        private static readonly List<Item> _itemsOfMoneyItem = All.Where(item => item is MoneyItem).Select(item => item).ToList();

        // Converts lists to appropriate item types
        private static List<HealthItem> ConvertItemsToHealth(List<Item> itemList)
        {
            return (from HealthItem item in itemList
                    select item).ToList();
        }
        private static List<MoneyItem> ConvertItemsToMoney(List<Item> itemList)
        {
            return (from MoneyItem item in itemList
                    select item).ToList();
        }

        // Converts filtered lists
        public static List<HealthItem> healthItems = ConvertItemsToHealth(_itemsOfHealthItem);
        public static List<MoneyItem> moneyItems = ConvertItemsToMoney(_itemsOfMoneyItem);

        // Instantiates the random class
        private static readonly Random rand = new Random();

        // Method that gets a random item from the array when called
        public static Item GetRandom()
        {
            var randIndex = rand.Next(All.Length);
            return All[randIndex];
        }
    }
}
    

