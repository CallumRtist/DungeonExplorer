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

        // Called by the player method PickUpItem
        public void AddItem(Item item)
        {
            item.Quantity += 1;
            if (_items.Contains(item) == false)
            {
                _items.Add(item);
            }
        }

        // Called by the player method RemoveItem
        public void RemoveItem(Item item)
        {
            item.Quantity -= 1;
            if (item.Quantity == 0)
            {
                _items.Remove(item);
            }
        }

        // When InventoryContents is called, display the name, quantity and value of each item added to the Inv
        public void InventoryContents()
        {
            Console.WriteLine("You have...");
            foreach (Item item in _items)
            {
                Console.WriteLine($"{item.Name} x{item.Quantity}: {item.Value}");
            }
        }
    }
}
