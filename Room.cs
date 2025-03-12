using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string _description;
        private Item _item;

        public Item Item
        {
            get { return _item; }
            set { _item = value; }
        }

        // Room Class Attributes
        public Room(string description, Item item)
        {
            this._description = description;
            this.Item = item;
        }


        // When GetDescription is called, return the set description attribute (string)
        public string GetDescription()
        {
            return _description;
        }
    }
}