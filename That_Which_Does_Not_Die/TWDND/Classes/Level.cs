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
            rooms = new Room[2, 2];
            Room room;
            Item item;

            #region Room[0,0]
                
            room = new Room();

            // Assign this room to location 0,0
            rooms[0, 0] = room;

            //set room properties
            room.Title = "Red Room";
            room.Description = "You have entered the red room, There is a locked door to the South";
            room.AddExits(Direction.East);

            // create a new item
            item = new Item();
            
            //setup the item
            item.Title = "Blue Ball";
            item.PickupText = "You just picked up the Blue Ball";

            // add item to room
            room.Items.Add(item);
            #endregion

            //place the player in the starting room
            Player.PosX = 0;
            Player.PosY = 0;


        }
    }
}
