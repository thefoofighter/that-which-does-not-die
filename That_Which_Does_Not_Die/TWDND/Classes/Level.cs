using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twdnd
{
    static class Level
    {
        private static Room[,] rooms;
        #region properties
        public static Room[,] Rooms
        {
            get { return rooms; }
        }
        #endregion
        //Initialize()
        public static void Initialize()
        {
            BuildLevel();
        }
     


        //BuildLevel()
        private static void BuildLevel()
        {

            rooms = new Room[10, 10];
            Room room;
            Item item;

            #region Starting Room (Hospital bed - Room 1) [0,0]

            room = new Room();
            // Assign this room to location 0,0
            rooms[0, 0] = room;
            room.Title = "Hospital Bedroom";
            room.Description = "You awake in a hospital Bedroom, bleary eyed and confused, You find it hard to focus on anything in particular, you stumble out of the bed and fall to your knees.'Where am I?', 'How did i get here?'.";
            room.AddExits(Direction.East);

            // create a new item
            item = new Item();
            item.Title = "PDA";
            item.PickupText = "You picked up a PDA, the SD card slot is empty.";

            room.Items.Add(item);
            #endregion

            #region Room 2 [1,0]
            room = new Room();
            // Assign this room to location 0,0
            rooms[1,0] = room;
            room.Title = "Room 2";
            room.Description = "You now find yourself in room 2 after struggling to gain the strength to walk there. The light is flickering and irritates your eyes.";
            room.AddExits(Direction.East);
            room.AddExits(Direction.South);

            // create a new item
            item = new Item();
            item.Title = "Apple";
            item.PickupText = "You picked up an Apple, Its not exactly fresh but still edible.";

            room.Items.Add(item);
            #endregion


            //place the player in the starting room
            Player.PosX = 0;
            Player.PosY = 0;
        } 
    }
}
