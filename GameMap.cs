using System;
using System.Collections.Generic;

namespace DungeonExplorer
{ 
	// Attributes
	// playerPosition, _map, initialRoom

	// Methods
	// GetCurrentRoom, GetRoom, Move, GenerateRoom

	public class GameMap
	{
		// Public Properties
        public (int, int) playerPosition { get; private set; }

		// Private Properties
		// Creates a new Dictionary called _map storing integers acting as 'coordinates' and a room class relating to these 'coordinates'
		private Dictionary<(int, int), Room> _map = new Dictionary<(int, int), Room>();

		// GameMap Constructor
		// Sets the players coordinates as 0,0 and sets this as the initial room, initial room is defined on instantiation
		public GameMap(Room initialRoom)
		{
			playerPosition = (0, 0);
			_map.Add(playerPosition, initialRoom);
		}

		// Method that returns the room that the player is currently in
		public Room GetCurrentRoom()
		{
			return GetRoom(playerPosition);
		}

		// Method that calls the GenerateRoom method when entering a new area
		public Room GetRoom((int, int) position)
		{
			if (_map.ContainsKey(position))
			{
				return _map[position];
			}
			else
			{
				return GenerateRoom(position);
			}
		}

		// Method that handles moving, changing strings of corresponding directions into values used as coordinates
		public void Move(string direction)
		{
			var (x, y) = playerPosition;

			if (direction == "up")
			{
				playerPosition = (x, y + 1);
			}
			else if (direction == "down")
			{
				playerPosition = (x, y - 1);
			}
			else if (direction == "right")
			{
				playerPosition = (x + 1, y);
			}
			else if (direction == "left")
			{
				playerPosition = (x - 1, y);
			}
			else
			{
				Console.WriteLine("Must be a direction");
			}
		}

		// Method that creates a new room when called
		public Room GenerateRoom((int, int) position)
		{
			var newRoom = Rooms.GetRandom();
			_map.Add(position, newRoom);
			return newRoom;
		}
	}
}