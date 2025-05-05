using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonExplorer
{
    // Attributes
    // Name, MoneyAdd, Quantity

    // Methods
    // ShowItemStats

    class MoneyItem : Item
    {
        // Private Properties
        private readonly int _moneyAdd;

        // Public Properties
        public int MoneyAdd { get; private set; }

        // MoneyItem Constructor
        public MoneyItem(string name, int moneyAdd, int quantity = 0) : base(name, quantity)
        {
            Name = name;
            MoneyAdd = moneyAdd;
            Quantity = quantity;
        }

        // When called runs the base method and also displays the value of the variable AddMoney
        public override void ShowItemStats()
        {
            base.ShowItemStats();
            Console.WriteLine($": Add {MoneyAdd} gold");
        }
    }
}
