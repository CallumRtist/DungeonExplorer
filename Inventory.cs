using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        // Create a list called _items to contain all added items
        private List<Item> _items = new List<Item>();

        public List<Item> Items { get => _items; private set => _items = value; }

        // Called by the player method PickUpItem, adds the item to the inventory list
        public void AddItem(Item item)
        {
            item.Quantity += 1;
            if (_items.Contains(item) == false)
            {
                _items.Add(item);
            }
        }

        // Called by the player method RemoveItem, removes the item from the inventory list
        public void RemoveItem(Item item)
        {
            item.Quantity -= 1;
            if (item.Quantity == 0)
            {
                _items.Remove(item);
            }
        }

        // When InventoryContents is called, call the method ShowItemStats to show the stats of each item, if the player has no items, say you have nothing
        public void InventoryContents()
        {
            Console.WriteLine("You have...");
            foreach (Item item in _items)
            {
                item.ShowItemStats();
            }   
            if (_items.Count == 0)
            {
                Console.WriteLine("...nothing...");
            }
        }

        // When GetItems is called, return the list _items
        public List<Item> GetItems()
        {
            return _items;
        }
    }
}
