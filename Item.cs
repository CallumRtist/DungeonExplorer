using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Attributes
    // Name, Quantity

    // Methods
    // ShowItemStats

    public abstract class Item
    {
        // Public Properties
        public String Name;
        public int Quantity;

        // Item Constructor
        public Item(string name, int quantity = 0)
        {
            Name = name;
            Quantity = quantity;
        }

        // When called returns the Items name and quantity attributes, can be expanded upon in subclasses
        public virtual void ShowItemStats()
        {
            Console.Write($"{Name} x{Quantity}");
        }
    }
}
