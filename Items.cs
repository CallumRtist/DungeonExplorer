using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Items
    {
        // Instantiate Item Class, creating 3 new items that can be used to different effects
        public static readonly Item healthItem = new Item("Health Potion", 5);
        public static readonly Item moneyItem = new Item("Bag of Money", 25);
        public static readonly Item chestItem = new Item("Treasure Chest", 100);

        // Create a new array called 'All' to store created items
        public static Item[] All = new[] { healthItem, moneyItem, chestItem };

        // Method that gets a random item from the array when called
        public static Item GetRandom()
        {
            var rand = new Random().Next(All.Length);
            return All[rand];
        }
    }
}
