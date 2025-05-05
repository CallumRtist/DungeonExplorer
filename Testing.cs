using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Testing
    {
        public static void AssertPlayerHasName(Player player)
        {
            Debug.Assert(String.IsNullOrWhiteSpace(player.Name) == false);
        }

        public static void PrintCreaturesHealth(Player player, Monster monster)
        {
            Debug.WriteLine($"Player health: {player.Health} \nMonster health: {monster.Health}");
        }

        public static void PrintCurrentRoom(GameMap gameMap)
        {
            Debug.WriteLine(gameMap.GetCurrentRoom().GetDescription());
        }

        public static void AssertRoomHasMonster(GameMap gameMap)
        {
            Debug.Assert(gameMap.GetCurrentRoom().Monster != null || gameMap.GetCurrentRoom().Monster != Monsters.NoEncounter);
        }

        public static void AssertRoomDoesNotHaveMonster(GameMap gameMap)
        {
            Debug.Assert(gameMap.GetCurrentRoom().Monster == null || gameMap.GetCurrentRoom().Monster == Monsters.NoEncounter);
        }
    }
}
