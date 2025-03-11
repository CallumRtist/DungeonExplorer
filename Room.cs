namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = description;
        }

        // When GetDescription is called, return the set description attribute (string)
        public string GetDescription()
        {
            return description;
        }
    }
}