using System;

namespace DungeonExplorer
{
    // Attributes
    // Description, itemGen Function, monsterGen Function

    // Methods
    // GetDescription

    public class Room
    {
        // Private Properties
        private string _description;
        private Func<Item> _itemGen;
        private Func<Monster> _monsterGen;

        // Public Properties
        public Item Item { get; private set; }
        public Monster Monster { get; private set; }

        // Room Constructor
        public Room(string description, Func<Item> itemGen, Func<Monster> monsterGen)
        {
            this._description = description;
            this.Item = itemGen != null ? itemGen() : null;
            this.Monster = monsterGen != null ? monsterGen() : null;
        }

        // When GetDescription is called, return the set description attribute (string)
        public string GetDescription()
        {
            return _description;
        }
    }
}