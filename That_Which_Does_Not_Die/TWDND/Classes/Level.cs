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
            Item item2;

            #region Red Room
            ///////////////////
            //create the red Room
            ///////////////////
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
            #region Blue Room
            ///////////////////
            //create the Blue Room
            ///////////////////
            room = new Room();

            // Assign this room to location 1,0
            rooms[1, 0] = room;

            //set room properties
            room.Title = "Blue Room";
            room.Description = "You have entered the Blue room.";
            room.AddExits(Direction.West);
            room.AddExits(Direction.South);

            // create a new item
            item = new Item();
            item.Title = "Green Ball";
            item.PickupText = "You just picked up the Green Ball";
            
            //create a new item
            item2 = new Item();
            item2.Title = "Key";
            item2.PickupText = "You just picked up the Key.";
            
            // add item to room
            room.Items.Add(item);
            room.Items.Add(item2);
            #endregion
            #region Yellow Room
            ///////////////////
            //create the Yellow Room
            ///////////////////
            room = new Room();

            // Assign this room to location 1,1
            rooms[1, 1] = room;

            //set room properties
            room.Title = "Yellow Room";
            room.Description = "You have entered the Yellow room";
            room.AddExits(Direction.North);
            room.AddExits(Direction.West);

            // create a new item
            item = new Item();

            //setup the item
            item.Title = "Red Ball";
            item.PickupText = "You just picked up the Red Ball";
            room.Items.Add(item);
            #endregion
            #region Green Room
            ///////////////////
            //create the Green Room
            ///////////////////
            room = new Room();

            // Assign this room to location 0,1
            rooms[0, 1] = room;

            //set room properties
            room.Title = "Green Room";
            room.Description = "You have entered the Green room, There is a locked door to the North";
            room.AddExits(Direction.East);

            // create a new item
            item = new Item();

            //setup the item
            item.Title = "Yellow Ball";
            item.PickupText = "You just picked up the Yellow Ball";
            room.Items.Add(item);
            #endregion

            //place the player in the starting room
            Player.PosX = 0;
            Player.PosY = 0;


        }
    }
}
