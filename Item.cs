using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        public String Name;

        public int Value;

        public int Quantity;

        // Item Class Attributes
        public Item(string name, int value, int quantity = 0)
        {
            Name = name;
            Value = value;
            Quantity = quantity;
        }
    }
}
