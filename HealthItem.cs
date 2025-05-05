using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // Attributes
    // Name, Restoration, Quantity

    // Methods
    // ShowItemStats

    public class HealthItem : Item
    {
        // Private Properties
        private readonly int _restoration;

        // Public Properties
        public int Restoration { get; private set; }

        // HealthItem Constructor
        public HealthItem(string name, int restoration, int quantity = 0) : base(name, quantity)
        {
            Name = name;
            Restoration = restoration;
            Quantity = quantity;
        }

        // When called runs the base method and also displays the value of the variable Restoration
        public override void ShowItemStats()
        {
            base.ShowItemStats();
            Console.WriteLine($": Restore health by {Restoration}");
        }
    }
}
