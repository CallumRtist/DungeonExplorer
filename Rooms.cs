using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Rooms
    {
        // Instantiate Room Class, creating all possible rooms that can be called
        public static readonly Room StartRoom = new Room("Starter Room", null, null);
        public static readonly Room CaveRoom = new Room("Cave", Items.GetRandom, Monsters.GetRandom);
        public static readonly Room PrisonRoom = new Room("Prison", Items.GetRandom, Monsters.GetRandom);
        public static readonly Room ShrineRoom = new Room("Shrine", Items.GetRandom, Monsters.GetRandom);
        public static readonly Room CryptRoom = new Room("Crypt", Items.GetRandom, Monsters.GetRandom);
        public static readonly Room LabRoom = new Room("Lab", Items.GetRandom, Monsters.GetRandom);
        public static readonly Room ArmouryRoom = new Room("Armoury", Items.GetRandom, Monsters.GetRandom);
        public static readonly Room BarracksRoom = new Room("Barracks", Items.GetRandom, Monsters.GetRandom);
        public static readonly Room LibraryRoom = new Room("Library", Items.GetRandom, Monsters.GetRandom);
        public static readonly Room ChasmRoom = new Room("Chasm", Items.GetRandom, Monsters.GetRandom);

        // Create a new array called 'All' to store created rooms
        public static Room[] All = new[] { CaveRoom, PrisonRoom, ShrineRoom, CryptRoom, LabRoom, ArmouryRoom, BarracksRoom, LibraryRoom, ChasmRoom };

        // Method that gets a random room from the array when called
        public static Room GetRandom()
        {
            var rand = new Random().Next(All.Length);
            return All[rand];
        }
    }
}
